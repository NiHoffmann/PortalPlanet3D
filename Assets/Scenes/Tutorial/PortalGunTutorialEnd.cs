using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunTutorialEnd : MonoBehaviour
{
    [SerializeField] DialogTutorial dt;
    [SerializeField] GameObject player;
    bool isEnabled = true;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals(player.name))
        {
            if (isEnabled)
            {
                dt.incrementCounter();
            }

            isEnabled = false;
        }
    }
}
