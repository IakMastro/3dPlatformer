using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        var yStore = m_MoveDirection.y;
        m_MoveDirection = transform.forward * Input.GetAxis("Vertical") + 
                          transform.right * Input.GetAxis("Horizontal");
        m_MoveDirection = m_MoveDirection.normalized * moveSpeed;
        m_MoveDirection.y = yStore;

        if (controller.isGrounded)
        {
            m_MoveDirection.y = 0.0f;
            if (Input.GetButtonDown("Jump"))
                m_MoveDirection.y = jumpForce;
        }

        m_MoveDirection.y += (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(m_MoveDirection * Time.deltaTime);
    }
}