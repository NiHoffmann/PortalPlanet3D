using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    [SerializeField] public PortalGun portalGun;
    [SerializeField] public GravityGun gravityGun;
    public bool portalGunUnlocked = false;
    public bool gravityGunUnlocked = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gravityGun.isEnabled = true;
            portalGun.isEnabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gravityGun.isEnabled = false;
            portalGun.isEnabled = true;
        }

        if (!portalGunUnlocked)
            portalGun.isEnabled = false;

        if (!gravityGunUnlocked)
            gravityGun.isEnabled = false;
        
    }
}

