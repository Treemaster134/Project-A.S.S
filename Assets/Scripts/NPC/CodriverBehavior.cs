using UnityEngine;

public class CodriverBehavior : MonoBehaviour
{
    [SerializeField] private AudioSource negativeClips;
    
    public void PlayCrashReaction()
    {
        negativeClips.Play();
    }
}
