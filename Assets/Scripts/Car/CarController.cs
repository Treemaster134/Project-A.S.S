using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CarController : MonoBehaviour
{
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

    [SerializeField] float baseSpeed;
    [SerializeField] float slowSpeed;

   
    
    float currentMotorTorque;
    private bool braking;
    private float currentAngle;
    private Vector2 movement;
    
    

    void Update()
    {
        for (int i = 0; i < frontWheels.Length; i++)
        {
            if (braking)
            {
                frontWheels[i]._col.motorTorque = 0;
                frontWheels[i]._col.brakeTorque = brakeforce;
            }
            else
            {
                if (movement.y == 0.0f)
                {
                    frontWheels[i]._col.brakeTorque = 1000;
                }
                else
                {
                    currentMotorTorque = Mathf.Lerp(motorforce, motorforce * 3, accelerate);
                    frontWheels[i]._col.motorTorque = currentMotorTorque * movement.y;
                    frontWheels[i]._col.brakeTorque = 0;
                }
            }
            
            // Sida 
            frontWheels[i]._col.steerAngle = movement.x * currentAngle;
            
        }
    }

    public void Brake(InputAction.CallbackContext context)
    {
        braking = !context.canceled;
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
}
