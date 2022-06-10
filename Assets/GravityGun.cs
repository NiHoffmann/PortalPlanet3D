using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera cam;
    [SerializeField] float maxGrabDist = 10f;
    [SerializeField] float force = 10f;
    [SerializeField] Transform objectHolder;
    [SerializeField] bool isEnabled;

    GameObject grabbedObject = null;

    // Update is called once per frame
    void Update()
    {
        if (!isEnabled) { return; }

        if (grabbedObject && grabbedObject.GetComponent<Rigidbody>())
        {

            grabbedObject.GetComponent<Rigidbody>().MovePosition(objectHolder.transform.position);

            if (Input.GetMouseButtonDown(0)) {
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                grabbedObject.GetComponent<Rigidbody>().AddForce(cam.transform.forward * force, ForceMode.VelocityChange);
                //collision with player now enabled
                Physics.IgnoreCollision(grabbedObject.GetComponent<Collider>(), GetComponent<Collider>(), false);

                grabbedObject = null;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (grabbedObject && grabbedObject.GetComponent<Rigidbody>())
            {
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                grabbedObject = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

                if (Physics.Raycast(ray, out hit, maxGrabDist))
                {
                    grabbedObject = hit.collider.gameObject;
                    if (grabbedObject.GetComponent<Rigidbody>())
                    {
                        //ignore collision with player 
                        Physics.IgnoreCollision(grabbedObject.GetComponent<Collider>(), GetComponent<Collider>(), true);
                        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }

            }
        }
    }

}
