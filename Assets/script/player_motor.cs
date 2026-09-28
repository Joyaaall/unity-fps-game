using UnityEngine;

public class player_motor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private InputManager inputManager;

    [Header("Movement")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -18f;

    private Vector3 velocity;

    private void Awake()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterController>();
        }

        if (inputManager == null)
        {
            inputManager = FindFirstObjectByType<InputManager>();
        }

        if (controller == null)
        {
            Debug.LogError("player_motor requires a CharacterController component.");
            enabled = false;
        }
    }

    private void Update()
    {
        if (inputManager == null)
        {
            return;
        }

        Vector3 input = new Vector3(inputManager.MoveInput.x, 0f, inputManager.MoveInput.y);

        if (input.sqrMagnitude > 1f)
        {
            input.Normalize();
        }

        float currentSpeed = inputManager.IsSprinting ? sprintSpeed : walkSpeed;
        Vector3 move = transform.right * input.x + transform.forward * input.z;

        if (controller.isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        if (inputManager.IsJumping && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(move * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
