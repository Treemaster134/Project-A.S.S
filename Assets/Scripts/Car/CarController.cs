using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CarController : MonoBehaviour
{
    
    private Rigidbody rb;
    [Header("Car Components")]
    [FormerlySerializedAs("wheels")] [SerializeField]private WheelController[] frontWheels;
    [SerializeField]private MultiplierComponent Engine;
    [SerializeField]private MultiplierComponent QPanelFL;
    [SerializeField]private MultiplierComponent QPanelFR;

    [Header("motor and steering")]
    [SerializeField]private float motorforce = 10;
    [SerializeField]private float brakeforce = 10;
    [SerializeField]private float maxSteerAngle;
    [SerializeField]private float maxSpeed = 100;

    [Header("Acceleration")] 
    [SerializeField]private float accelerate = 10;

   
    
    float currentMotorTorque;
    private float currentBrakeTorque;
    private float currentAngle;
    private Vector2 movement;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        float currentSpeed = Vector3.Dot(transform.forward, rb.linearVelocity);
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, Mathf.Abs(currentSpeed));
        if (movement.y == 0 && currentMotorTorque == 0)
        {
            currentMotorTorque = 0;
            currentBrakeTorque = 1000;
        }
        else if (movement.y != 0)
        {
            currentMotorTorque = Mathf.Lerp(motorforce, motorforce * 2, accelerate);
            currentBrakeTorque = 0;
        }
        for (int i = 0; i < frontWheels.Length; i++)
        {
            
            frontWheels[i]._col.motorTorque = currentMotorTorque * movement.y;
            frontWheels[i]._col.brakeTorque = currentBrakeTorque;
            
            // Sida 
            frontWheels[i]._col.steerAngle = movement.x * currentAngle;
            
        }
    }

    public void Brake(InputAction.CallbackContext context)
    {
        currentBrakeTorque = brakeforce * 10;
        currentMotorTorque = 0;

        if (context.canceled)
        {
            currentBrakeTorque = 0;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        
        movement = context.ReadValue<Vector2>();
        //Apply multiplyer to max-steer
        if (movement.x < 0)
        {
            currentAngle = maxSteerAngle * QPanelFL.Multiplier;
        }
        else if (movement.x > 0)
        {
            currentAngle = maxSteerAngle * QPanelFR.Multiplier;
        }
    }
    public Vector2 GetMovementInput()
    {
       
        return Vector2.zero;
    }
}
