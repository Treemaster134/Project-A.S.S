using UnityEngine;

public class StartLevelScript : MonoBehaviour
{

    [SerializeField] private GameObject Car;
    [SerializeField] private GameObject StartPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Car.transform.position = StartPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
