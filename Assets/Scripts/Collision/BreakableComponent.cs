using UnityEngine;

public class BreakableComponent : CarComponent
{
    [SerializeField] private int health;
    public override void Hit()
    {
        if (--health <= 0)
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            Vector3 launchDirection = -transform.parent.right.normalized;
            launchDirection -= transform.parent.forward.normalized * (transform.localPosition.normalized.x * 0.1f);
            launchDirection.y += 0.5f;

            transform.parent = null;
            GetComponent<Collider>().enabled = false;
            rb.AddForce(launchDirection.normalized * 35f, ForceMode.Impulse);
        }
        else
        {
            Debug.Log($"Damaged: {gameObject.name}");
        }
    }
}
