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
    public GameObject portalCube = null;

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

        if (!isEnabled || !linkedPortal.isEnabled || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("PortalCubeCollider")|| collision.gameObject.CompareTag("PortalCube") || collision.gameObject.CompareTag("PortalSurface") || portalCube != null) {
            return; 
        }


        if (!used || !collision.gameObject.CompareTag("Player"))
        {

            GetComponent<AudioSource>().Play();

            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerController.isGrounded = false;
                Quaternion rot = linkedPortal.transform.rotation;
                MouseLook.yRotation = rot.eulerAngles.y + Mathf.DeltaAngle(transform.localEulerAngles.y, playerCam.transform.localEulerAngles.y) + 180;
                collision.gameObject.transform.position = (linkedPortal.transform.position);
                linkedPortal.used = true;
                used = false;
            }
            else {
                collision.gameObject.transform.position = (linkedPortal.transform.position) + linkedPortal.transform.forward * 1f;
                Vector3 fw = linkedPortal.portalCam.transform.forward.normalized;
                collision.gameObject.GetComponent<Rigidbody>().velocity = (fw * collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude);
            }

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
        if (portalCube != null)
        {
            transform.position = portalCube.transform.position;
            transform.rotation = portalCube.transform.rotation;
        }

        if (!isEnabled || !linkedPortal.isEnabled)
        {
            if(viewTexture != null)
                viewTexture.Release();
            return;
        }

        portalWindow.enabled = false;

        CreateViewTexture();

        Quaternion rot = transform.rotation;
        rot = Quaternion.Euler(new Vector3(rot.eulerAngles.x, rot.eulerAngles.y + Mathf.DeltaAngle(linkedPortal.transform.localEulerAngles.y, playerCam.transform.localEulerAngles.y) + 180f, rot.eulerAngles.z));

        portalCam.transform.SetPositionAndRotation(transform.position, rot);

        portalCam.Render();

        portalWindow.enabled = true;
    }
}
