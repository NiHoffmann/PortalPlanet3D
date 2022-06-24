using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel1Collider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            storySlideState.state = storySlideState.STATES.BOSSLEVEL;
            SManager.loadScene("story");
        }
    }
}
