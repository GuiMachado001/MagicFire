using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls controls; 
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator animator;
    
    
    private bool isGrounded; 

    public float speed = 5f;
    public float jumpForce = 5f; 
    public Transform groundCheck; 
    public LayerMask groundLayer; 

    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;


        controls.Player.Jump.performed += ctx => {
            if (isGrounded)
            {
                HandleJump();
            }
        }; 
    }
    
    private void HandleJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        isGrounded = false; 
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    void FixedUpdate()
    {
        if(moveInput .x > 0)
        {
            transform.localScale = new Vector3(5f, 5f, 5f);
        }else if(moveInput.x < 0){
            transform.localScale = new Vector3(-5f, 5f, 5f);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        
        Vector2 movementVelocity = new Vector2(moveInput.x * speed, rb.velocity.y);
        rb.velocity = movementVelocity;


        if (isGrounded)
        {
            animator.SetFloat("speed", Mathf.Abs(moveInput.x));
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }
    }
}