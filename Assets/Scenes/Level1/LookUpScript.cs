using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpScript : MonoBehaviour
{
    [SerializeField] MouseLook mouseLook;
    [SerializeField] GameObject lootAtThis;
    bool activated = false;
    float timer = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {  
        timer += Time.deltaTime;
        if (!activated && timer > 90) {
            mouseLook.lookAt(lootAtThis.transform);
            activated = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        activated = true;
    }
}
