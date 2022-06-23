using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_over_script : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) {
            SManager.loadScene("main_menu");
        }
    }
}
