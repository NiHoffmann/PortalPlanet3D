using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel2ColliderScritp : MonoBehaviour
{
    [SerializeField] DialogLevel2 dl2;
    bool trig = false;
    float timer = 0;

    private void Update()
    {
        if (trig) {
            timer += Time.deltaTime;
            if (timer > 5) {
                dl2.incrementCounter();
                timer = 0;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trig = true;
        }
    }
}
