using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;
    private WheelController[] wheels;

    private float motorforce = 10;
    private float brakeforce = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Brake(InputAction.CallbackContext context)
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i]._col.brakeTorque = 0;
        }
    }
    public Vector2 GetMovementInput(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>().y != 0)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
              wheels[i]._col.motorTorque = motorforce * context.ReadValue<Vector2>().y;
            }
        }

        if (context.ReadValue<Vector2>().x != 0)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i]._col.steerAngle = 1;
            }
        }
        
        return context.ReadValue<Vector2>();
    }
}
