using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCubeScript : MonoBehaviour
{
    [SerializeField] public BoxCollider smallCollider;
    public GameObject portal = null;


    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground")))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<BoxCollider>());
        }
    }

    private void OnDestroy()
    {
        if (portal != null)
        {
            portal.transform.position = new Vector3(-999, -999, -999);
            portal.GetComponent<Portal>().isEnabled = false;
            portal.GetComponent<Portal>().used = false;
            portal.GetComponent<Portal>().portalCube = null;
        }
    }
}
