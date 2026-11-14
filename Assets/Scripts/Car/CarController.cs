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
   
  
   public PrometeoCarController PCC;

 
  
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
        if(Input.GetKey(KeyCode.W))
        {
            Debug.Log("W pressed");
            PCC.GoForward();
        }
        else if(Input.GetKey(KeyCode.S))
        {
            Debug.Log("S pressed");
            PCC.GoReverse();
        }

        if(Input.GetKey(KeyCode.A)){
            Debug.Log("A pressed");
            PCC.TurnLeft();
        }
        if(Input.GetKey(KeyCode.D)){
            Debug.Log("D pressed");
            PCC.TurnRight();
        }

if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) &&
PCC.steeringAxis != 0){
PCC.ResetSteeringAngle();
}

        if(!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) &&
!Input.GetKey(KeyCode.Space) && !PCC.deceleratingCar)
        {
            PCC.InvokeRepeating("DecelerateCar", 0f, 0.1f);
            PCC.deceleratingCar = true;
        }
   }
}

