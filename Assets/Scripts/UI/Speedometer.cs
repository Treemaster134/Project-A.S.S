using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private PrometeoCarController car;
    [SerializeField] private RectTransform speeder;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private string WinSceneName;
    [SerializeField] private float distanceLeft;
    [SerializeField] private float distanceSubtractionFactor;

    private float maxSpeed, currentSpeed;
    void Start()
    {
        maxSpeed =car.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = car.carSpeed;
        speeder.rotation = Quaternion.Euler(0,0,-180.0f * Mathf.Abs(currentSpeed) / maxSpeed);
        
        if (currentSpeed > 0)
        {
            distanceLeft -= currentSpeed * Time.deltaTime * distanceSubtractionFactor;
        }

        if (distanceLeft <= 0)
        {
            SceneManager.LoadScene(WinSceneName);
        }
        
        distanceText.text = $"DISTANCE: {distanceLeft.ToString("F0")}";
    }
}
