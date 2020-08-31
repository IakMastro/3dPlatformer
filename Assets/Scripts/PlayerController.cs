using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 m_MoveDirection;
    public float gravityScale;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_MoveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, m_MoveDirection.y,
            Input.GetAxis("Vertical") * moveSpeed);

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
                m_MoveDirection.y = jumpForce;
        }

        m_MoveDirection.y += (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(m_MoveDirection * Time.deltaTime);
    }
}