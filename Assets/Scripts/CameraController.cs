using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
            offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the X position of the mouse & rotate the target
        var horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0.0f, horizontal, 0.0f);
        
        // Get the Y position of the mouse and rotate the target
        var vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.Rotate(-vertical, 0.0f, 0.0f);
        
        // Move the camera based on the current rotation of the target and the original offset
        var eulerAngles = target.eulerAngles;
        var desiredYAngle = eulerAngles.y;
        var desiredXAngle = eulerAngles.x;
        var rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0.0f);
        transform.position = target.position - (rotation * offset);
        transform.LookAt(target);
    }
}
