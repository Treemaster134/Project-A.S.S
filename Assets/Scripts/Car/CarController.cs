using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private WheelController[] wheels;
    [SerializeField]private MultiplierComponent Engine;
    [SerializeField]private MultiplierComponent QPanelFL;
    [SerializeField]private MultiplierComponent QPanelFR;

    [SerializeField]private float motorforce = 10;
    [SerializeField]private float brakeforce = 10;
    [SerializeField]private float maxSteerAngle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Brake(InputAction.CallbackContext context)
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i]._col.brakeTorque = brakeforce;
        }

        if (context.canceled)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i]._col.brakeTorque = 0;
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Köra fram/bak
        if (context.ReadValue<Vector2>().y != 0)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i]._col.motorTorque = motorforce * context.ReadValue<Vector2>().y;
            }
        }
        // Sida 
        if (context.ReadValue<Vector2>().x != 0)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i]._col.steerAngle = context.ReadValue<Vector2>().x * maxSteerAngle;
            }
        }

    }
    public Vector2 GetMovementInput()
    {
       
        return Vector2.zero;
    }
}
