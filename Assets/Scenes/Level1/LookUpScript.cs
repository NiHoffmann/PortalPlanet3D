using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookUpScript : MonoBehaviour
{
    [SerializeField] GameObject objective;
    
    bool activated = false;
    float timer = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {  
        timer += Time.deltaTime;
        if (!activated && timer > 90) {
            TextMeshProUGUI tmp = objective.GetComponent<TextMeshProUGUI>();
            tmp.SetText("Tip: sometimes the answer is above you");
            activated = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        activated = true;
    }
}
