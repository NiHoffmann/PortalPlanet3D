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
            source.clip = clips[(int)Random.Range(0, clips.Length - 0.1f)];
            source.Play();
        }
        firstCollision = false;
    }
}
