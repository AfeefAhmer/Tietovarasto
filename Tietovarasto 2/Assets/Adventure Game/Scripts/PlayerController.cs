using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    private float gravity = -9.81f;
    private float verticalVelocity;
    private CharacterController characterController;

    // --- Input Actions ---
    [SerializeField] private InputActionReference moveAction;    // Vector2
    [SerializeField] private InputActionReference attackAction;  // Button
    [SerializeField] private InputActionReference jumpAction;  // Button
    [SerializeField] private InputActionReference lookAction;    // Vector2

    private Vector2 moveInput;
    private Vector2 look;
    public Vector2 Look { get => look; set => look = value; }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        // Laita actionit päälle. 
        moveAction.action.Enable();
        attackAction.action.Enable();
        jumpAction.action.Enable();
        lookAction.action.Enable();

        // Performed-metodia kutsutaan kun liike alkaa tai muuttuu
        moveAction.action.performed += OnMovePerformed;
        // Canceled-metodia kutsutaan kun liike loppuu
        moveAction.action.canceled += OnMoveCanceled;

        // Painiketta painettiin, suorita Performed-metodi
        attackAction.action.performed += OnAttackPerformed;
        jumpAction.action.performed += OnJumpPerformed;

        lookAction.action.performed += OnLookPerformed;
        lookAction.action.canceled += OnLookCanceled;
    }

    private void OnDisable()
    {
        moveAction.action.performed -= OnMovePerformed;
        moveAction.action.canceled -= OnMoveCanceled;
        attackAction.action.performed -= OnAttackPerformed;
        jumpAction.action.performed -= OnJumpPerformed;
        lookAction.action.performed -= OnLookPerformed;

        moveAction.action.Disable();
        attackAction.action.Disable();
        jumpAction.action.Disable();
        lookAction.action.Disable();
    }

    private void Update()
    {
        // Liikuta hahmoa
        Move(moveInput);
    }

    // Pelaajaa katsoo sivulle
    private void OnLookPerformed(InputAction.CallbackContext context)
    {
        Look = context.action.ReadValue<Vector2>();
    }

    // Peruu katselun
    private void OnLookCanceled(InputAction.CallbackContext context)
    {
        Look = Vector2.zero;
    }

    // Lukee syötteen
    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        // Lue arvo vain kun se muuttuu
        moveInput = context.action.ReadValue<Vector2>();
    }

    // Peruu syötteen
    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        // Tämä varmistaa, että jos ei ole syötettä, pelaaja ei liiku
        moveInput = Vector2.zero;
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Hyökkäys aktivoitu");
    }

    void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (characterController.isGrounded)
        {
            verticalVelocity = 5f; // Aseta hyppyvoima
        }
    }

    // Hahmoa liikutetaan
    private void Move(Vector2 moveInput)
    {
        if (characterController.isGrounded && verticalVelocity < 0f)
            verticalVelocity = -2f;

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 direction = transform.right * moveInput.x + transform.forward * moveInput.y;

        Vector3 velocity = direction * moveSpeed + Vector3.up * verticalVelocity;

        characterController.Move(velocity * Time.deltaTime);
    }
}
