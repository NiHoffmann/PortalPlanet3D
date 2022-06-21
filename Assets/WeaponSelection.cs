using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    [SerializeField] public PortalGun portalGun;
    [SerializeField] public GravityGun gravityGun;
    [SerializeField] GameObject textField;
    public bool portalGunUnlocked = false;
    public bool gravityGunUnlocked = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && gravityGunUnlocked)
        {
            gravityGun.isEnabled = true;
            portalGun.isEnabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && portalGunUnlocked)
        {
            gravityGun.isEnabled = false;
            portalGun.isEnabled = true;
        }

        TextMeshProUGUI tmp = textField.GetComponent<TextMeshProUGUI>();

        if (gravityGun.isEnabled == false && portalGun.isEnabled == false)
        {
            tmp.SetText("");
        }
        else
        {
            if (portalGun.isEnabled)
                tmp.SetText("Portal Gun");
            if (gravityGun.isEnabled)
                tmp.SetText("Gravity Gun");
        }

        if (!portalGunUnlocked)
            portalGun.isEnabled = false;

        if (!gravityGunUnlocked)
            gravityGun.isEnabled = false;
        
    }
}

