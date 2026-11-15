using UnityEngine;

//https://noodlecollie.github.io/2020-11-29-creating-billboard-sprites-in-unity/
public class Billboard : MonoBehaviour
{
    [SerializeField]private Camera cam;
        public bool rotate = true;

    void Start()
    {
        if (cam == null)
        {
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!rotate) return;
        Vector3 cameraForwardXZ = Vector3.ProjectOnPlane(cam.transform.forward,
            Vector3.up).normalized;
        transform.LookAt(transform.position - cameraForwardXZ);
    }
}
