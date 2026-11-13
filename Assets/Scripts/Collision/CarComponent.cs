using System;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class CarComponent : MonoBehaviour
{
    [SerializeField] private CollisionController collisionController;

    private void OnTriggerEnter(Collider other)
    {
        collisionController.RegisterCollision(this);
    }

    public virtual void Hit() { }
}
