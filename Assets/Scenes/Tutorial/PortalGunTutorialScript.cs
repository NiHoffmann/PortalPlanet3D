using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunTutorialScript : MonoBehaviour
{
    public bool isEnabled = false;
    [SerializeField] Camera playerCamer;
    [SerializeField] WeaponSelection weaponSelection;
    [SerializeField] DialogTutorial dt;

    // Update is called once per frame
    void Update()
    {
        if (!isEnabled) return;

        if (Physics.Raycast(playerCamer.transform.position, playerCamer.transform.forward, out var hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.name.Equals(name)) {
                if (Input.GetKeyDown(KeyCode.E))
                {

                    weaponSelection.portalGunUnlocked = true;
                    weaponSelection.portalGun.isEnabled = true;
                    weaponSelection.gravityGun.isEnabled = false;
                    dt.incrementCounter();
                    isEnabled = false;
                    gameObject.SetActive(false);
                }
            }          
        }
    }
}
