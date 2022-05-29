using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;
    public MeshRenderer screen;
    public string playerName;
    Camera playerCam;
    Camera portalCam;
    RenderTexture viewTexture;


    void Awake()
    {
        playerCam = Camera.main;
        portalCam = GetComponentInChildren<Camera>();
        portalCam.enabled = false;
    }

    void OnTriggerEnter(Collider collision)
    {

        Vector3 position = (linkedPortal.transform.position) + (playerCam.transform.forward.normalized * 1f);
        //this doesnt work propperly with player
        if(!collision.gameObject.name.Equals(playerName))
            position += Vector3.ProjectOnPlane((collision.gameObject.transform.position - this.transform.position), linkedPortal.transform.position.normalized);
        
        collision.gameObject.transform.position = position;

    }

    void CreateViewTexture() 
    {

        if (viewTexture == null || viewTexture.width != Screen.width || viewTexture.height != Screen.height) {
            if (viewTexture != null) {
                viewTexture.Release();
            }
            viewTexture = new RenderTexture(Screen.width, Screen.height, 0);
            portalCam.targetTexture = viewTexture;
            linkedPortal.screen.material.SetTexture("_MainTex", viewTexture);
        }
    
    }

    public void Update()
    {
        screen.enabled = false;

        //portalCam.nearClipPlane = Vector3.Distance(portalCam.transform.position, this.transform.position) - 1f;

        CreateViewTexture();

        var matrix = transform.localToWorldMatrix * linkedPortal.transform.worldToLocalMatrix * playerCam.transform.localToWorldMatrix;

        portalCam.transform.SetPositionAndRotation((matrix).GetColumn(3), matrix.rotation);

        portalCam.Render();

        screen.enabled = true;
    }
}
