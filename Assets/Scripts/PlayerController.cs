using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        jumpInputTimer = 0f;
        jumpCoyoteTimer = 0f;
    }

    private void Update()
    {
        updateTimers();
        bool grounded = isGrounded();

        horizontalInput = Input.GetAxisRaw("Horizontal");

        if(grounded && rb.velocity.y <= 0f)
        {
            jumpCoyoteTimer = coyoteTime;
        } 

        if(Input.GetButton("Jump"))
        {
            if(grounded || (jumpCoyoteTimer > 0f && rb.velocity.y <= 0f))
            {
                jump();
            }
        }

        else if (jumpInputTimer > 0f && grounded && rb.velocity.y <= 0f)
        {
            jump();
        }
    }

    private void FixedUpdate()
    {
        float targetSpeed = maxRunSpeed * horizontalInput;

        float accel = accelRate;

        if(Mathf.Abs(targetSpeed) < 0.1f)
        {
            accel = deccelRate;
        }

        float forceToApply = (targetSpeed - rb.velocity.x) * accel;

        rb.AddForce(Vector2.right * forceToApply, ForceMode2D.Impulse);
    }

    private void updateTimers()
    {
        jumpInputTimer -= Time.deltaTime;
        jumpCoyoteTimer -= Time.deltaTime;
    }

    private void jump()
    {
        jumpCoyoteTimer = 0f;
        float targetJmpForce = (jumpForce - rb.velocity.y);
        rb.AddForce(Vector2.up * targetJmpForce, ForceMode2D.Impulse);
    }

    private bool isGrounded()
    {
        int groundLayer = LayerMask.GetMask("Ground");
        RaycastHit2D hit2d = Physics2D.CircleCast(feet.position, 0.3f, Vector2.down, 0.1f, groundLayer);

        return hit2d.collider != null;
    }

    [SerializeField] private Transform feet;

    [SerializeField] private float maxRunSpeed;
    [SerializeField] private float accelRate;
    [SerializeField] private float deccelRate;
    [SerializeField] private float maxJumpInputDelay;
    [SerializeField] private float jumpForce;
    [SerializeField] private float coyoteTime;

    private Rigidbody2D rb;

    private float horizontalInput;

    private float jumpInputTimer;
    [SerializeField] private float jumpCoyoteTimer;
}
