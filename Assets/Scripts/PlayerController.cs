using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [FormerlySerializedAs("MoveSpeed")] public float moveSpeed;
    [FormerlySerializedAs("theRB")] public Rigidbody theRb;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        theRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        theRb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 
            theRb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        
        if (Input.GetButtonDown("Jump"))
        {
            theRb.velocity = new Vector3(theRb.velocity.x, jumpForce, theRb.velocity.z);
        }
    }
}
