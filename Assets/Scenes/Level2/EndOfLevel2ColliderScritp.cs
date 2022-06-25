using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel2ColliderScritp : MonoBehaviour
{
    [SerializeField] DialogLevel2 dl2;
    bool trig = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !trig)
        {
            trig = true;
            dl2.incrementCounter();
        }
    }
}
