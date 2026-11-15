using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class CollisionController : MonoBehaviour
{
    [SerializeField] private int MaxHitsPerCollision;
    [SerializeField] private int componentsLeft = 0;
    [SerializeField] private int minimumComponentsLeft = 0;
    [SerializeField] private string GameOverSceneName;
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
            for (int i = 0; i < registrations; i++)
            {
                if (components[i].Hit())
                {
                    //component broke
                    componentsLeft--;

                    if (componentsLeft < minimumComponentsLeft)
                    {
                        SceneManager.LoadScene(GameOverSceneName);
                        return;
                    }
                }
            }
            
            codriver.PlayCrashReaction();

            registrations = 0;
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
