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
            Debug.Log($"Damaged: {gameObject.name}");
        }
    }
}
