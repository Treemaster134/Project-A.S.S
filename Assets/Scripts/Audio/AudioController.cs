using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class AudioController : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] private AudioClip moveSFX, idleSFX ;
    private AudioClip clip;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && (clip != moveSFX || !audio.isPlaying))
        {
            audio.clip = moveSFX;
            audio.Play();
        }
        else if (clip != idleSFX || !audio.isPlaying)
        {
            audio.clip = idleSFX;
            audio.Play();
        }
    }
}
