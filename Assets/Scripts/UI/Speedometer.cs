using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private PrometeoCarController car;
    [SerializeField] private RectTransform speeder;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private float distanceLeft;

    private float maxSpeed, currentSpeed;
    void Start()
    {
        maxSpeed =car.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = car.carSpeed;
        speeder.rotation = Quaternion.Euler(0,0,-180.0f * currentSpeed / maxSpeed);
        distanceText.text = $"DISTANCE: {distanceLeft.ToString("F0")}";
    }
}
