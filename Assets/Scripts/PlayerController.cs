using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class CharacterController2D : MonoBehaviour
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        updateTimers();
        horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded();

        if(Input.GetButton("Jump") && isGrounded())
        {
            float targetJmpForce = (jumpForce - rb.velocity.y);

            rb.AddForce(Vector2.up * targetJmpForce, ForceMode2D.Impulse);
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

    }

    private bool isGrounded()
    {
        int groundLayer = LayerMask.GetMask("Ground");
        RaycastHit2D hit2d = Physics2D.CircleCast(feet.position, 0.3f, Vector2.down, 0.1f, groundLayer);

        if(hit2d.collider != null)
        {
            Debug.Log(hit2d.transform.name);
        }

        return hit2d.collider != null;
    }

    [SerializeField] private Transform feet;

    [SerializeField] private float maxRunSpeed;
    [SerializeField] private float accelRate;
    [SerializeField] private float deccelRate;
    [SerializeField] private float maxJumpInputDelay;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;

    private float jumpInputTimer;
    private float horizontalInput;
}
