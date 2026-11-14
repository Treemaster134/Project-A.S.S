using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField]private PrometeoCarController car;
    [SerializeField]private Image speeder;

    private float maxSpeed, currentSpeed;
    void Start()
    {
        maxSpeed =car.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        speeder.fillAmount = maxSpeed / car.carSpeed;
    }
}
