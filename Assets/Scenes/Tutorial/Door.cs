using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform door;
    public float startingPosition = -12.71f;
    public float endPosition = -15.00f;
    public float speed;
    bool open = false;



    private void Update()
    {
        if (open)
        {
            if (door.transform.position.x > endPosition)
            {
                door.transform.Translate(-speed * Time.deltaTime, 0f, 0f);
            }
        }
        else
        {
            if (door.transform.position.x < startingPosition)
            {
                door.transform.Translate(speed * Time.deltaTime, 0f, 0f);
            }
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        open = true;
    }

    void OnTriggerExit(Collider collision)
    {
        open = false;
    }
}
