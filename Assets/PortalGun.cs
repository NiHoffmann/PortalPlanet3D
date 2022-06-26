using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    [SerializeField] GameObject portal1;
    [SerializeField] GameObject portal2;
    [SerializeField] Camera cam;
    [SerializeField] float maxPortalDist;
    [SerializeField] public bool isEnabled;
    [SerializeField] GameObject crosshair;
    [SerializeField] AudioClip placePortalSound;
    [SerializeField] AudioSource playerAudioSource;
    


    public void placePortal(GameObject portalToPlace, GameObject otherPortal) {
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out hit, maxPortalDist, ~(LayerMask.GetMask("Portal") | LayerMask.GetMask("PortalCubeCollider"))) && (hit.collider.gameObject.layer == 7))
        {
            playerAudioSource.PlayOneShot(placePortalSound);

            if (portalToPlace.GetComponent<Portal>().portalCube) {

                portalToPlace.GetComponent<Portal>().portalCube.transform.parent.gameObject.GetComponentInParent<PortalCubeScript>().portal = null;
            }

            portalToPlace.GetComponent<Portal>().portalCube = null;
            portalToPlace.transform.localScale = new Vector3(1.2f, 1.7f, 0.1f);

            portalToPlace.transform.position = hit.point;
            portalToPlace.transform.rotation = hit.collider.gameObject.transform.rotation;

            if (Vector3.Distance(portalToPlace.transform.position , otherPortal.transform.position) < 2)
            {
                otherPortal.transform.position = new Vector3(-999, -999, -999);
                if (otherPortal.GetComponentInParent<Portal>().portalCube) {
                    otherPortal.GetComponentInParent<Portal>().portalCube.transform.parent.gameObject.GetComponentInParent<PortalCubeScript>().portal = null;
                }
                otherPortal.GetComponentInParent<Portal>().portalCube = null;
            }

            if (otherPortal.transform.position.Equals(new Vector3(-999, -999, -999)) || portalToPlace.transform.position.Equals(new Vector3(-999, -999, -999)))
            {
                otherPortal.GetComponent<Portal>().isEnabled = false;
                portalToPlace.GetComponent<Portal>().isEnabled = false;
            }
            else {
                portalToPlace.GetComponent<Portal>().isEnabled = true;
                otherPortal.GetComponent<Portal>().isEnabled = true;
            }

            portal1.GetComponent<Portal>().used = false;
            portal2.GetComponent<Portal>().used = false;

            RaycastHit hit2;
            if (Physics.Raycast(ray, out hit2, maxPortalDist,  ~(LayerMask.GetMask("Portal") | LayerMask.GetMask("PortalSurface") | LayerMask.GetMask("PortalCubeCollider")))){
                print(hit2.collider.gameObject.name);
                if (hit2.collider.gameObject.CompareTag("PortalCube"))
                {
                    portalToPlace.GetComponent<Portal>().portalCube = hit.collider.gameObject;
                    print(hit.collider.gameObject.name);
                    portalToPlace.transform.localScale = new Vector3(1, 1, 0.1f);
                    if (portalToPlace.GetComponent<Portal>().portalCube)
                    {
                        portalToPlace.GetComponent<Portal>().portalCube.transform.parent.gameObject.GetComponentInParent<PortalCubeScript>().portal = portalToPlace;
                    }
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnabled) {
            crosshair.SetActive(false);
            return; 
        }

        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out hit, maxPortalDist, ~(LayerMask.GetMask("Portal") | LayerMask.GetMask("PortalCubeCollider"))) && hit.collider.gameObject.layer == 7)
        {
            crosshair.SetActive(true);
        }
        else
        {
            crosshair.SetActive(false);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            placePortal(portal1, portal2);
        }

        if (Input.GetMouseButtonDown(1)) {
            placePortal(portal2, portal1);
        }

    }
}
