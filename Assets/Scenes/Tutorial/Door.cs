using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform door;
    float startingPosition;
    public float speed;
    bool open = false;
    bool opening = false;
    bool closing = true;
    [SerializeField] float dist = 2.3f;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip soundOpen;
    [SerializeField] AudioClip soundClose;

    void Start()
    {
        startingPosition = door.transform.position.x;
    }



    private void Update()
    {
        if (open)
        {
            if (!opening) {
                source.PlayOneShot(soundOpen);
                opening = true;
                closing = false;
            }
            if (door.transform.position.x > startingPosition + dist)
            {
                door.transform.Translate(-speed * Time.deltaTime, 0f, 0f);
            }
            
        }
        else
        {
            if (!closing) {
                source.PlayOneShot(soundClose);
                opening = false;
                closing = true;
            }
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
