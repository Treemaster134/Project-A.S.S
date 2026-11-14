using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class AudioController : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] private AudioClip moveForwardSFX, moveBackWardSFX ;
    private AudioClip clip;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && clip != moveForwardSFX ||(Input.GetKey(KeyCode.W) && !audio.isPlaying))
        {
            clip = moveForwardSFX;
            audio.PlayOneShot(clip);
        }

        if (Input.GetKey(KeyCode.S) && clip != moveBackWardSFX ||Input.GetKey(KeyCode.S)&&!audio.isPlaying)
        {
            clip = moveBackWardSFX;
            audio.PlayOneShot(clip);
        }
    }

    public void PlayAudio(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            
        }
    }
}
