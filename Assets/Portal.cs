using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] public Portal linkedPortal;
    [SerializeField] public MeshRenderer portalWindow;
    [SerializeField] public bool isEnabled;
    [SerializeField] float jumpDist = 0.5f;
    Camera playerCam;
    Camera portalCam;
    RenderTexture viewTexture;
    public bool used = false;

    void Awake()
    {
        playerCam = Camera.main;
        portalCam = GetComponentInChildren<Camera>();
        portalCam.nearClipPlane = 0.75f;
        portalCam.enabled = false;
    }

    void OnTriggerEnter(Collider collision)
    {

        if (!isEnabled || !linkedPortal.isEnabled) {
            return; 
        }

        if (!used)
        {
            GetComponent<AudioSource>().Play();

            if (collision.gameObject.name.Equals("PlayerCharacter"))
            {
                Quaternion rot = linkedPortal.transform.rotation;
                MouseLook.yRotation = rot.eulerAngles.y + Mathf.DeltaAngle(transform.localEulerAngles.y, playerCam.transform.localEulerAngles.y) + 180;
            }

            linkedPortal.used = true;
            collision.gameObject.transform.position = (linkedPortal.transform.position) + (linkedPortal.transform.forward.normalized * 0.25f);
            used = false;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        used = false;
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

        Quaternion rot = transform.rotation;
        rot = Quaternion.Euler(new Vector3(rot.eulerAngles.x, rot.eulerAngles.y + Mathf.DeltaAngle(linkedPortal.transform.localEulerAngles.y, playerCam.transform.localEulerAngles.y) + 180, rot.eulerAngles.z));

        portalCam.transform.SetPositionAndRotation(transform.position, rot);

        portalCam.Render();

        portalWindow.enabled = true;
    }
}
