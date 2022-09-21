using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 horizontalInput;
    [SerializeField] float speed = 11f;
    [SerializeField] CharacterController controller;
    [SerializeField] float gravity = -20f;
    Vector3 verticalVelocity = Vector3.zero;

    public bool isGrounded;
    [SerializeField] float jumpHeight = 3.5f;
    public bool jump;

    public void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics.CheckSphere(transform.position, 0.5f, groundMask);
        isGrounded = controller.isGrounded;
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        if (jump)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }




        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void ReceiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;

    }

    public void OnJumpPressed()
    {
        jump = true;
    }
}
