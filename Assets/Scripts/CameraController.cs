using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateSpeed;
    public Transform pivot;
    
    public float maxViewAngle;
    public float minViewAngle;

    public bool invertY;

    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
            offset = target.position - transform.position;

        var targetTransform = target.transform;
        var pivotTransform = pivot.transform;
        pivotTransform.position = targetTransform.position;
        pivotTransform.parent = targetTransform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Get the X position of the mouse & rotate the target
        var horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0.0f, horizontal, 0.0f);

        // Get the Y position of the mouse and rotate the pivot
        var vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        if (invertY)
            pivot.Rotate(vertical, 0.0f, 0.0f);

        else
            pivot.Rotate(-vertical, 0.0f, 0.0f);

        // Limit the up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180.0f)
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0.0f, 0.0f);

        if (pivot.rotation.eulerAngles.x > 180.0f && pivot.rotation.eulerAngles.x < 360.0f + minViewAngle) 
            pivot.rotation = Quaternion.Euler(360.0f + minViewAngle, 0.0f, 0.0f);

        // Move the camera based on the current rotation of the target and the original offset
        var desiredYAngle = target.eulerAngles.y;
        var desiredXAngle = pivot.eulerAngles.x;
        var rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0.0f);
        transform.position = target.position - (rotation * offset);

        if (transform.position.y < target.position.y)
            transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);

        transform.LookAt(target);
    }
}