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
    [SerializeField] public bool isEnabled;
    [SerializeField] GameObject portal1;
    [SerializeField] GameObject portal2;
    [SerializeField] WeaponSelection weaponSelection;
    //tutorial fields
    public bool tutorial = false;
    public bool tutorialTaskCompleted = false;
    [SerializeField] DialogTutorial dt;

    public GameObject grabbedObject = null;

    // Update is called once per frame
    void Update()
    {
        if (grabbedObject) {
            grabbedObject.GetComponent<BoxCollider>().enabled = false;
            if (grabbedObject.CompareTag("PortalCubeCollider")) {
                if (portal1.GetComponent<Portal>().portalCube)
                {
                    portal1.GetComponent<Portal>().portalCube = null;
                    portal1.transform.position = new Vector3(-999, -999, -999);
                }
                if (portal2.GetComponent<Portal>().portalCube)
                {
                    portal2.GetComponent<Portal>().portalCube = null;
                    portal2.transform.position = new Vector3(-999, -999, -999);
                }
            }
        }

        if (grabbedObject && grabbedObject.GetComponent<Rigidbody>() && (grabbedObject.CompareTag("Throwable") || grabbedObject.CompareTag("PortalCubeCollider")))
        {
            grabbedObject.GetComponent<Rigidbody>().MovePosition(objectHolder.transform.position);

            if (Input.GetMouseButtonDown(0) && isEnabled) {
                grabbedObject.GetComponent<BoxCollider>().enabled = true;
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                if (grabbedObject.CompareTag("PortalCubeCollider"))
                {
                    grabbedObject.GetComponent<PortalCubeScript>().smallCollider.enabled = true;
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                }
                grabbedObject.GetComponent<Rigidbody>().AddForce(cam.transform.forward * force, ForceMode.VelocityChange);
                //collision with player now enabled

                grabbedObject = null;
                if (tutorial && !tutorialTaskCompleted) {
                    tutorialTaskCompleted = true;
                    dt.incrementCounter();
                }
            }
        }

        if ((Input.GetMouseButtonDown(1) && isEnabled) || (weaponSelection.portalGun.isEnabled && grabbedObject))
        {
            if (grabbedObject && grabbedObject.GetComponent<Rigidbody>() && (grabbedObject.CompareTag("Throwable") || grabbedObject.CompareTag("PortalCubeCollider")))
            {
                grabbedObject.GetComponent<BoxCollider>().enabled = true;
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                if (grabbedObject.CompareTag("PortalCubeCollider")) {
                    grabbedObject.GetComponent<PortalCubeScript>().smallCollider.enabled = true;
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                }
                grabbedObject = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

                if (Physics.Raycast(ray, out hit, maxGrabDist))
                {
                    if (hit.collider.gameObject.GetComponent<Rigidbody>() && (hit.collider.gameObject.CompareTag("Throwable") || hit.collider.gameObject.CompareTag("PortalCubeCollider")))
                    {
                        //ignore collision with player 
                        grabbedObject = hit.collider.gameObject;
                        grabbedObject.GetComponent<BoxCollider>().enabled = false;
                        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                        if (grabbedObject.CompareTag("PortalCubeCollider"))
                        {
                            grabbedObject.GetComponent<PortalCubeScript>().smallCollider.enabled = false;
                            grabbedObject.GetComponent<PortalCubeScript>().portal = null;
                            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                        }
                    }
                }

            }
        }
    }

}
