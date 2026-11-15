using System;
using UnityEngine;

public class RunningObstacle : MonoBehaviour
{
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float spinSpeed;
    [SerializeField] private Animator sprite;
    [SerializeField] private string pauseAnimationBool;
    [SerializeField] private string carTag;
    [SerializeField, Tooltip("How long to pause in the middle.")] private float waitTime;
    private float progress = 0.0f;
    private float animationTimer = 0.0f;
    public bool spinning = false;

    Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        if (spinning)
        {
            rb.AddTorque(Vector3.up * 50f);
            rb.AddTorque(Vector3.left * 50f);


            // sprite.transform.position = sprite.transform.position + Vector3.up * (spinSpeed * Time.deltaTime);
            animationTimer += Time.deltaTime;

            if (animationTimer >= 1.0f)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (progress >= 0.5f && animationTimer < waitTime)
            {
                animationTimer += Time.deltaTime;
                sprite.SetBool(pauseAnimationBool, true);
            }
            else
            {
                progress += Time.deltaTime * runningSpeed;
                sprite.SetBool(pauseAnimationBool, false);
            }
            
            sprite.transform.position = Vector3.Lerp(startPoint, endPoint, progress) + transform.position;
        }
        
    }

    public void Spin()
    {
        Debug.Log("Spinning obstacle");
        rb.isKinematic = false;
        animationTimer = 0.0f;
        spinning = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPoint + transform.position, endPoint + transform.position);
        Gizmos.DrawSphere((startPoint + endPoint) * 0.5f + transform.position, 0.5f);
        Gizmos.color = Color.darkGreen;
        Gizmos.DrawSphere(startPoint + transform.position, 0.5f);
        Gizmos.DrawSphere(endPoint + transform.position, 0.5f);
    }
}
