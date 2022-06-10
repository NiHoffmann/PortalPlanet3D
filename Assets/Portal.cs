using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] public Portal linkedPortal;
    [SerializeField] public MeshRenderer portalWindow;
    [SerializeField] public string playerName;
    [SerializeField] Camera playerCam;
    [SerializeField] Camera portalCam;
    [SerializeField] RenderTexture viewTexture;
    [SerializeField] public bool isEnabled;


    void Awake()
    {
        playerCam = Camera.main;
        portalCam = GetComponentInChildren<Camera>();
        portalCam.enabled = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (!isEnabled || !linkedPortal.isEnabled) {
            return; 
        }

        Vector3 position = (linkedPortal.portalCam.transform.position) + (linkedPortal.portalCam.transform.forward * 1f);
        //this doesnt work propperly with player
        //if(!collision.gameObject.name.Equals(playerName))
        //   position += Vector3.ProjectOnPlane((collision.gameObject.transform.position - this.transform.position), linkedPortal.transform.position.normalized);
        
        collision.gameObject.transform.position = position;
        //collision.gameObject.transform.rotation = (linkedPortal.portalCam.transform.rotation * collision.transform.rotation);
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

        portalCam.nearClipPlane = Vector3.Distance(portalCam.transform.position, this.transform.position) + 0.2f;

        CreateViewTexture();

        var matrix = transform.localToWorldMatrix * linkedPortal.transform.worldToLocalMatrix * playerCam.transform.localToWorldMatrix;

        portalCam.transform.SetPositionAndRotation((matrix).GetColumn(3), matrix.rotation);

        portalCam.Render();

        portalWindow.enabled = true;
    }
}
