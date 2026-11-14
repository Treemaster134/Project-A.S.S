using UnityEngine;

public class CodriverBehavior : MonoBehaviour
{
    [SerializeField] private AudioSource negativeClips;
    [SerializeField] private AudioSource monologue;

    public void PlayMonologue()
    {
        monologue.Play();
    }
    
    public void PlayCrashReaction()
    {
        negativeClips.Play();
    }
}
