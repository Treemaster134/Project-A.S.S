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
        _model.position = _col.transform.position;
        _model.rotation = _col.transform.rotation;
    }
}
