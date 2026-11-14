using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CarController : MonoBehaviour
{
   private Rigidbody rb;
   [FormerlySerializedAs("Wheels")] [Header("Car Components")] [SerializeField]private WheelController[] wheels;
   [FormerlySerializedAs("wheels")] [SerializeField]private WheelController[] backWheels;
   [SerializeField]private MultiplierComponent Engine;
   [SerializeField]private MultiplierComponent QPanelFL;
   [SerializeField]private MultiplierComponent QPanelFR;
  


   [Header("motor and steering")]
   [SerializeField]private float motorforce = 10;
   [SerializeField]private float brakeforce = 10;
   [SerializeField]private float maxSteerAngle;


   [Header("Acceleration")]
   [SerializeField]private float accelerate = 10;
   [SerializeField]private float retardation = 10;


   [SerializeField] float baseRotationSpeed;
   [SerializeField] private float maxRotationspeed;
   
  


 
  
   float currentMotorTorque;
   private float currentRotation;
   private bool braking;
   private float currentAngle;
   private Vector2 movement;


   void Start()
   {
       rb = GetComponent<Rigidbody>();
   }
  
  


   void Update()
   {
       for (int i = 0; i < wheels.Length; i++)
       {
           if (braking)
           {
               currentRotation = Mathf.Lerp(wheels[i]._col.rotationSpeed, 0, retardation);
               wheels[i]._col.rotationSpeed = currentRotation;
               wheels[i]._col.motorTorque = 0;
               wheels[i]._col.brakeTorque = brakeforce;
           }
           else
           {
               if (movement.y == 0.0f)
               {
                   wheels[i]._col.motorTorque = 0;
                   wheels[i]._col.brakeTorque = 1000;
               }
               else
               {
                   currentRotation = Mathf.Lerp(wheels[i]._col.rotationSpeed, maxRotationspeed, accelerate);
                   wheels[i]._col.rotationSpeed = currentRotation;
                   currentMotorTorque = Mathf.Lerp(motorforce, motorforce * 3, accelerate);
                   wheels[i]._col.motorTorque = currentMotorTorque * movement.y;
                   wheels[i]._col.brakeTorque = 0;
               }
           }
          
           // Sida
           if(wheels[i].FrontWheel)
           {
               wheels[i]._col.steerAngle = movement.x * currentAngle;
           }
          
       }
   }


   public void Brake(InputAction.CallbackContext context)
   {
     
       braking = !context.canceled;
   }


   public void Move(InputAction.CallbackContext context)
   {
       if (context.started)
       {
              for (int i = 0; i < wheels.Length; i++)
              {
                  wheels[i]._col.rotationSpeed += baseRotationSpeed;
              }
               
       }
      
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

