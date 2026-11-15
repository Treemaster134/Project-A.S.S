using UnityEngine;

enum Direction
{
    Left,
    Right,
    Up,
    Back
}

public class BreakableComponent : CarComponent
{
    [SerializeField]
    Direction direction;
    Vector3 launchDirection;

    [SerializeField] private int health;

    Rigidbody rb;

    bool broken = false;


    // [SerializeField]AudioClip[] crashSound;

    // AudioSource audioSource;

    private void Update()
    {
        if(broken)
        {
            rb.AddTorque(Vector3.up * 50f);
            rb.AddTorque(Vector3.left * 50f);
        }
    }
    public override bool Hit()
    {
        if (--health <= 0)
        {
            // audioSource = gameObject.AddComponent<AudioSource>();
            // audioSource.clip = crashSound;
            // audioSource.Play();
            rb = gameObject.AddComponent<Rigidbody>();
            switch (direction)
            {
                case Direction.Left:
                    launchDirection = transform.forward.normalized;
                    break;
                case Direction.Right:
                    launchDirection = -transform.forward.normalized;
                    break;

                case Direction.Up:
                    launchDirection = transform.up.normalized;
                    break;

                case Direction.Back:
                    launchDirection = -transform.right.normalized;
                    break;

            }
            launchDirection.y += 0.5f;

            transform.parent = null;
            GetComponent<Collider>().enabled = false;
            rb.AddForce(launchDirection.normalized * 15f, ForceMode.Impulse);
            broken = true;
        }
        else
        {
            Debug.Log($"Damaged: {gameObject.name}");
        }

        return broken;
    }
}
