using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;

    bool isIdle;


    [SerializeField] private AudioClip moveSFX, idleSFX;
    private AudioClip clip;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = idleSFX;
        audio.Play();

    }

    private void Update()
    {
        isIdle = !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S);
        
        if (isIdle && (audio.clip != idleSFX || !audio.isPlaying))
        {
            audio.volume = 0.3f;
            Debug.Log("IT IS IDLE");
            audio.clip = idleSFX;
            audio.Play();

        }
        else if (!isIdle && (audio.clip != moveSFX || !audio.isPlaying))
        {
            audio.volume = 0.7f;
            Debug.Log("IT IS MOVING");
            audio.clip = moveSFX;
            audio.Play();

        }
    }
}
