using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class CollisionController : MonoBehaviour
{
    [SerializeField] private int MaxHitsPerCollision;
    [SerializeField] private int componentsLeft = 0;
    [SerializeField] private int minimumComponentsLeft = 0;
    [SerializeField] private int heavyDamageThreshold;
    [SerializeField] private int mildDamageThreshold;
    [SerializeField] private string GameOverSceneName;
    [SerializeField] private GameObject MildDamageSmoke;
    [SerializeField] private GameObject HeavyDamageFire;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private AudioSource crashAudioSource;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioClip explosionSound;
    
    private CarComponent[] components;
    private int registrations = 0;
    private CodriverBehavior codriver;

    private void Start()
    {
        components = new CarComponent[MaxHitsPerCollision];
        codriver = GetComponent<CodriverBehavior>();
    }

    void Update()
    {
        if (registrations > 0)
        {
            bool pieceFellOff = false;
            
            for (int i = 0; i < registrations; i++)
            {
                if (components[i].Hit())
                {
                    //component broke
                    componentsLeft--;
                    pieceFellOff = true;
                    explosion.transform.position = components[i].transform.position;

                    if (componentsLeft <= minimumComponentsLeft)
                    {
                        SceneManager.LoadScene(GameOverSceneName);
                        return;
                    }
                }
            }

            if (pieceFellOff)
            {
                explosion.Stop();
                crashAudioSource.PlayOneShot(explosionSound);
                explosion.Play();
            }
            else
            {
                crashAudioSource.PlayOneShot(crashSound);
            }
            
            codriver.PlayCrashReaction();

            registrations = 0;
        }

        if (componentsLeft <= heavyDamageThreshold)
        {
            HeavyDamageFire.SetActive(true);
            MildDamageSmoke.SetActive(false);
        }
        else if (componentsLeft <= mildDamageThreshold)
        {
            HeavyDamageFire.SetActive(false);
            MildDamageSmoke.SetActive(true);
        }
        else
        {
            HeavyDamageFire.SetActive(false);
            MildDamageSmoke.SetActive(false);
        }
        
    }

    public void RegisterCollision(CarComponent component)
    {
        if (registrations < MaxHitsPerCollision)
        {
            Debug.Log($"Register Collision, Total: {registrations}");
            components[registrations++] = component;
        }
    }
    
}
