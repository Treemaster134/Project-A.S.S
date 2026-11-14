using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField]private PrometeoCarController car;
    [SerializeField]private Rigidbody rb;
    [SerializeField]private Transform transfom;
    [SerializeField]private Image speeder;

    private float maxSpeed, currentSpeed;
    void Start()
    {
        maxSpeed =car.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = Vector3.Dot(transfom.forward, rb.linearVelocity);
        speeder.fillAmount = maxSpeed / currentSpeed;
    }
}
