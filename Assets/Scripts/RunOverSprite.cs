using UnityEngine;

public class RunOverSprite : MonoBehaviour
{
    RunningObstacle runningObstacle;

    void Start()
    {
        runningObstacle = GetComponentInParent<RunningObstacle>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Debug.Log("Car hit the obstacle");
            gameObject.GetComponent<Collider>().enabled = false;
            runningObstacle.Spin();
        }
    }
}
