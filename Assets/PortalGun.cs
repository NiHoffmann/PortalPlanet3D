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


    public void placePortal(GameObject portalToPlace, GameObject otherPortal) {
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out hit, maxPortalDist, LayerMask.GetMask("PortalSurface")))
        {
            portalToPlace.transform.position = hit.point;
            portalToPlace.transform.rotation = hit.collider.gameObject.transform.rotation;

            if (Vector3.Distance(portalToPlace.transform.position , otherPortal.transform.position) < 2)
            {
                otherPortal.transform.position = new Vector3(-999, -999, -999);
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

        if (Physics.Raycast(ray, out hit, maxPortalDist, ~24))
        {
            if (hit.collider.gameObject.layer != 6 && hit.collider.gameObject.layer != 7)
            {
                crosshair.SetActive(false);
                return;
            }
            crosshair.SetActive(true);
        }
        else
        {
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
