using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;
    private WheelController[] wheels;
    
    //float motorforce = hur stark motorn är
    //float breakforce = hurtarka bromsarna är
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetMovementInput(InputAction.CallbackContext context)
    {
        return context.ReadValue<Vector2>();
    }
}
