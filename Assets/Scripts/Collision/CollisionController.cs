using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollisionController : MonoBehaviour
{
    [SerializeField] private int MaxHitsPerCollision;
    private CarComponent[] components;
    private int registrations = 0;

    private void Start()
    {
        components = new CarComponent[MaxHitsPerCollision];
    }

    void Update()
    {
        if (registrations >= 0)
        {
            for (int i = 0; i < registrations; i++)
            {
                components[i].Hit();
            }

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
