using System;
using UnityEngine;

public class PrometeoWhisperer : MonoBehaviour
{
    [Header("max speeds")]
    [SerializeField] int maxCarSpeed = 200;
    [SerializeField] int maxAcceleration = 10;
    
    [Header("Max Brakes")]
    [SerializeField] bool wantBrakes = true;
    [SerializeField, Tooltip("högre siffra = långsammare broms")] float maxBrakeSpeed = 0.5f;
    [SerializeField, Tooltip("högre siffra = långsammare broms")]  float BaseBrakeSpeed = 0.5f;
    [SerializeField, Tooltip("högre siffra = långsammare broms")] private float brakeSpeed;
    
    [Header("Components")]
    [SerializeField] PrometeoCarController car;
    [SerializeField] MultiplierComponent engine;
    [SerializeField] MultiplierComponent Left;
    [SerializeField] MultiplierComponent Right;
    
    float previousEngineMulti;
    float maxSpeed;
    float carAcceleration;
    
    
    float previousLeftMulti;
    float maxSteer;
    float previousRightMulti;
   
    void Start()
    {
        previousEngineMulti = engine.Multiplier;
        previousLeftMulti = Left.Multiplier;
        previousRightMulti = Right.Multiplier;
        maxSteer = car.maxSteeringAngle;
        carAcceleration = car.accelerationMultiplier;
        maxSpeed = car.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (previousLeftMulti != Left.Multiplier)
            {
                previousLeftMulti = Left.Multiplier;
            }
            
            car.maxSteeringAngle = (int)Mathf.Floor(maxSteer * previousLeftMulti);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (previousRightMulti != Right.Multiplier)
            {
                previousRightMulti = Right.Multiplier;
            }
            car.maxSteeringAngle = (int)Mathf.Floor(maxSteer * previousRightMulti);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (previousEngineMulti != engine.Multiplier)
            {
                previousEngineMulti = engine.Multiplier;
                brakeSpeed = Mathf.Clamp((int)Mathf.Ceil(BaseBrakeSpeed * brakeSpeed * previousEngineMulti), 1, maxBrakeSpeed);
                
                car.maxSpeed = Mathf.Clamp((int)Mathf.Ceil(maxSpeed * previousEngineMulti), 100, maxCarSpeed) ;
                car.accelerationMultiplier = Mathf.Clamp((int)Mathf.Ceil(carAcceleration * previousEngineMulti), 1, maxAcceleration);
            }
        }

        if (Input.GetKey(KeyCode.Space) && brakeSpeed != maxBrakeSpeed &&  wantBrakes)
        {
            car.frontLeftCollider.rotationSpeed = Mathf.Lerp(car.frontLeftCollider.rotationSpeed, 0, brakeSpeed);
            car.frontRightCollider.rotationSpeed = Mathf.Lerp(car.frontLeftCollider.rotationSpeed, 0, brakeSpeed);
            car.rearRightCollider.rotationSpeed = Mathf.Lerp(car.frontLeftCollider.rotationSpeed, 0, brakeSpeed);
            car.rearLeftCollider.rotationSpeed = Mathf.Lerp(car.frontLeftCollider.rotationSpeed, 0, brakeSpeed);
        }
    }
}
