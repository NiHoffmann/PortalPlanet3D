using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] public Portal linkedPortal;
    [SerializeField] public MeshRenderer portalWindow;
    [SerializeField] public bool isEnabled;
    [SerializeField] MouseLook ml;
    [SerializeField] float jumpDist = 0.75f;
    [SerializeField] float jumpPush = 0.5f;
    Camera playerCam;
    Camera portalCam;
    RenderTexture viewTexture;

    void Awake()
    {
        playerCam = Camera.main;
        portalCam = GetComponentInChildren<Camera>();
        portalCam.nearClipPlane = 1.75f;
        portalCam.enabled = false;
    }

    void OnTriggerEnter(Collider collision)
    {

        if (!isEnabled || !linkedPortal.isEnabled) {
            return; 
        }

        Quaternion rot = linkedPortal.transform.rotation;

        collision.gameObject.transform.position = (linkedPortal.transform.position) + (linkedPortal.transform.forward.normalized * jumpDist) - (linkedPortal.transform.up.normalized*jumpPush);

        MouseLook.xRotation = rot.eulerAngles.x;
        //what ever the fuck this is but it works 
        MouseLook.yRotation = rot.eulerAngles.y + Mathf.DeltaAngle(transform.rotation.eulerAngles.y, playerCam.transform.rotation.eulerAngles.y) + 180;

    }
    
    void CreateViewTexture() 
    {

        if (viewTexture == null || viewTexture.width != Screen.width || viewTexture.height != Screen.height) {
            if (viewTexture != null) {
                viewTexture.Release();
            }
            viewTexture = new RenderTexture(Screen.width, Screen.height, 0);
            portalCam.targetTexture = viewTexture;
            linkedPortal.portalWindow.material.SetTexture("_MainTex", viewTexture);
        }
    
    }

    public void Update()
    {
        if (!isEnabled || !linkedPortal.isEnabled)
        {
            if(viewTexture != null)
                viewTexture.Release();
            return;
        }

        portalWindow.enabled = false;

        CreateViewTexture();

        portalCam.transform.SetPositionAndRotation(transform.position, (transform.localToWorldMatrix * playerCam.transform.localToWorldMatrix * playerCam.transform.localToWorldMatrix).rotation);

        portalCam.Render();

        portalWindow.enabled = true;
    }
}
