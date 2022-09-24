using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public PlayerControls PlayerControls;
    PlayerControls.MovementActions movement;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    [SerializeField] PlayerController playerCon;
    [SerializeField] MouseLook mouseLook;


    public void Awake()
    {
        PlayerControls = new PlayerControls();
        movement = PlayerControls.Movement;

        movement.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        movement.Jump.performed += _ => playerCon.OnJumpPressed();
        movement.Shoot.performed += _ => playerCon.OnShootPressed();

        movement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        movement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerCon.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }



    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
}
