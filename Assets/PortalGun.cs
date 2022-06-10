using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    [SerializeField] GameObject portal1;
    [SerializeField] GameObject portal2;
    [SerializeField] Camera cam;
    [SerializeField] float maxPortalDist;
    [SerializeField] bool isEnabled;
    [SerializeField] GameObject crosshair;


    public void placePortal(GameObject portalToPlace, GameObject otherPortal) {
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out hit, maxPortalDist, LayerMask.GetMask("PortalSurface")))
        {
            portalToPlace.transform.position = hit.point;
            otherPortal.transform.rotation = hit.collider.transform.rotation;
            portalToPlace.GetComponent<Portal>().isEnabled = true;

            if (Vector3.Distance(portalToPlace.transform.position , otherPortal.transform.position) < 3)
            {
                otherPortal.transform.position = new Vector3(-999, -999, -999);
                otherPortal.GetComponent<Portal>().isEnabled = false;
                portalToPlace.GetComponent<Portal>().isEnabled = false;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out hit, maxPortalDist, LayerMask.GetMask("PortalSurface"))) {
            crosshair.SetActive(true);
        }
        else
        {
            crosshair.SetActive(false);
        }

        if (!isEnabled) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            placePortal(portal1, portal2);
        }

        if (Input.GetMouseButtonDown(1)) {
            placePortal(portal2, portal1);
        }

    }
}
