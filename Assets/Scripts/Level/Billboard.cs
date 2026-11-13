using UnityEngine;

//https://noodlecollie.github.io/2020-11-29-creating-billboard-sprites-in-unity/
public class Billboard : MonoBehaviour
{
    private Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraForwardXZ = Vector3.ProjectOnPlane(cam.transform.forward,
            Vector3.up).normalized;
        transform.LookAt(transform.position - cameraForwardXZ);
    }
}
