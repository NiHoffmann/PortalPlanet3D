using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundScript : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip[] clips;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(clips[(int)Random.Range(0,clips.Length -0.1f)]);
    }
}
