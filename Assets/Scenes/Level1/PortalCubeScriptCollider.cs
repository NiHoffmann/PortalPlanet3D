using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCubeScriptCollider: MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground")))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<BoxCollider>());
        }
    }
}

