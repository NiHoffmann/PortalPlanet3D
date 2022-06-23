using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicScript : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        play(clip);       
    }

    private void play(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
