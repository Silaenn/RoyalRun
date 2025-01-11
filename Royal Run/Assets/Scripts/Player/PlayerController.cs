using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float minMoveSpeed = 5f;
    [SerializeField] float maxMoveSpeed = 18f;
    [SerializeField] float xClamp = 3f;
    [SerializeField] float zClamp = 3f;
    [SerializeField] float jumpForce = 6f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Animator animator;
    const string jumpString = "Jump";

    Vector2 movement;
    Rigidbody rigidBody;
    private float verticalVelocity = 0f;
    private bool isJumping = false;
    private float initialY;

    void Awake() {
        rigidBody = GetComponent<Rigidbody>();    
        initialY = transform.position.y;
    }


    void FixedUpdate() {
        HandleMovementAndJump();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context){
        if (context.performed && !isJumping)
        {
            StartCoroutine(JumpRoutine());
        }
    }

    IEnumerator JumpRoutine()
    {
        animator.SetTrigger(jumpString);
        yield return new WaitForSeconds(0.31f);
        isJumping = true;
        verticalVelocity = jumpForce;
    }

    void HandleMovementAndJump()
    {
        Vector3 currentPosition = rigidBody.position;
        
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 horizontalMovement = moveDirection * (moveSpeed * Time.fixedDeltaTime);

        if (isJumping)
        {
            verticalVelocity += gravity * Time.fixedDeltaTime;
            if (currentPosition.y + verticalVelocity * Time.fixedDeltaTime <= initialY)
            {
                currentPosition.y = initialY;
                isJumping = false;
                verticalVelocity = 0f;
            }
        }

        Vector3 newPosition = currentPosition + horizontalMovement;
        if (isJumping)
        {
            newPosition.y += verticalVelocity * Time.fixedDeltaTime;
        }

        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);
        
        rigidBody.MovePosition(newPosition);
    }

    public void AdjustMoveSpeed(float amount) {
        moveSpeed = Mathf.Clamp(moveSpeed + amount, minMoveSpeed, maxMoveSpeed);
    }
}