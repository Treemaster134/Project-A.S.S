using UnityEngine;

public class BreakableComponent : CarComponent
{
    [SerializeField] private int health;
    public override void Hit()
    {
        if (--health <= 0)
        {
            gameObject.SetActive(false);
            Debug.Log($"Detached: {gameObject.name}");
        }
        else
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            Vector3 launchDirection = -transform.parent.forward.normalized;
            launchDirection += transform.parent.right * transform.localPosition.normalized.x;

            transform.parent = null;
            GetComponent<Collider>().enabled = false;
            rb.AddForce(launchDirection * 100, ForceMode.Impulse);
        }
    }
}
