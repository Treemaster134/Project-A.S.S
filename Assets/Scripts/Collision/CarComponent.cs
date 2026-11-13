using System;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class CarComponent : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private CollisionController collisionController;

    private void OnTriggerEnter(Collider other)
    {
        collisionController.RegisterCollision(this);
    }

    public void Hit()
    {
        if (--health <= 0)
        {
            gameObject.SetActive(false);
            Debug.Log($"Detached: {gameObject.name}");
        }
        else
        {
            Debug.Log($"Damaged: {gameObject.name}");
        }
    }
}
