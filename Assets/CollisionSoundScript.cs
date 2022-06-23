using UnityEngine;

public class CollisionSoundScript : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip[] clips;
    bool firstCollision = true;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!firstCollision)
        {
            source.PlayOneShot(clips[(int)Random.Range(0, clips.Length - 0.1f)]);
        }
        firstCollision = false;
    }
}
