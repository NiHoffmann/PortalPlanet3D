using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform door;
    float startingPosition;
    public float speed;
    bool open = false;
    bool moving = false;
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

            if (door.transform.position.x > startingPosition + dist)
            {
                if (!moving)
                {
                    source.PlayOneShot(soundOpen);
                    moving = true;
                }
                door.transform.Translate(-speed * Time.deltaTime, 0f, 0f);
            }
            else
            {
                moving = false;
            }

        }
        else
        {
            if (door.transform.position.x < startingPosition)
            {
                if (!moving)
                {
                    source.PlayOneShot(soundClose);
                    moving = true;
                }

                door.transform.Translate(speed * Time.deltaTime, 0f, 0f);
            }
            else
            {
                moving = false;
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
