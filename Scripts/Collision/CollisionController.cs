using UnityEngine;

[RequireComponent(typeof(CarController)), RequireComponent(typeof(Rigidbody))]
public class CollisionController : MonoBehaviour
{
    [SerializeField] private int MaxHitsPerCollision;
    private CarComponent component = null;
    private bool registeredHit = false;
    
    // Update is called once per frame
    void Update()
    {
        if (registeredHit)
        {
            component.Hit();
            component = null;
            registeredHit = false;
        }
    }

    public void RegisterCollision(CarComponent component)
    {
        registeredHit = true;
        this.component = component;
    }
    
}
