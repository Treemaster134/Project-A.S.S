using System;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public WheelCollider _col;
    [SerializeField]private Transform _model;

    private Vector3 _position;
    private Quaternion _rotation;
    
    void Start()
    {
        _col = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    public void Update()
    {
        _col.GetWorldPose(out _position, out _rotation);
        _model.transform.position = _position;
        _model.transform.rotation = _rotation;
    }
}
