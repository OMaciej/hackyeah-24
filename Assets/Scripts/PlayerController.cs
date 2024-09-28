using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        playerInteract = GetComponent<PlayerInteract>();

        jumpInputTimer = 0f;
        jumpCoyoteTimer = 0f;
    }

    private void Update()
    {
        updateTimers();
        bool grounded = isGrounded();

        // if (grounded)
        //     blockMovement = false;

        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (grounded && rb.velocity.y <= 0f)
        {
            jumpCoyoteTimer = coyoteTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded || (jumpCoyoteTimer > 0f && rb.velocity.y <= 0f))
            {
                jump();
            }
        }

        else if (jumpInputTimer > 0f && grounded && rb.velocity.y <= 0f)
        {
            jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            playerInteract.clickButton();
        }
    }

    private void FixedUpdate()
    {
        // if (blockMovement)
        //     return;

        float targetSpeed = maxRunSpeed * horizontalInput;

        float accel = accelRate;

        if (Mathf.Abs(targetSpeed) < 0.1f)
        {
            if (isGrounded())
            {
                accel = deccelRate;
            }
            else
            {
                accel = 0;
            }
        }

        float forceToApply;
        forceToApply = (targetSpeed - rb.velocity.x) * accel;

        rb.AddForce(Vector2.right * forceToApply, ForceMode2D.Impulse);
    }

    private void OnEnable()
    {
        if (abilityScript != null)
            abilityScript.enabled = true;
    }

    private void OnDisable()
    {
        if (abilityScript != null)
            abilityScript.enabled = false;
    }

    public void OnCharacterSwitch(bool switchedTo)
    {
        if (tutorialToTrigger != null)
        {
            if (switchedTo)
            {
                tutorialToTrigger.enableTrigger();
            }
            else
            {
                tutorialToTrigger.disableTrigger();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TutorialTrigger"))
        {
            tutorialToTrigger = collision.GetComponent<TutorialTrigger>();
            tutorialToTrigger.enableTrigger();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TutorialTrigger"))
        {
            tutorialToTrigger.disableTrigger();
            tutorialToTrigger = null;
        }
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

        //Play jump sound effect
        if (audioSource.clip == null || audioSource.clip.name != jumpSfx.name)
            audioSource.clip = jumpSfx;

        audioSource.Play();
    }

    private bool isGrounded()
    {
        //Check for collision with ground
        int groundLayer = LayerMask.GetMask("Ground");
        RaycastHit2D hit2d = Physics2D.CircleCast(feet.position, 0.3f, Vector2.down, 0.1f, groundLayer);

        if (hit2d.collider != null)
        {
            return true;
        }

        groundLayer = LayerMask.GetMask("MovingPlatform");
        hit2d = Physics2D.CircleCast(feet.position, 0.3f, Vector2.down, 0.1f, groundLayer);

        if (hit2d.collider != null)
        {
            return true;
        }

        //Check for collision with other controllable characters (players)
        int characterLayer = LayerMask.GetMask("Character");
        RaycastHit2D[] hits2d = Physics2D.CircleCastAll(feet.position, 0.3f, Vector2.down, 0.1f, characterLayer);

        foreach (RaycastHit2D hit in hits2d)
        {
            if (hit.transform.GetInstanceID() != transform.GetInstanceID())
            {
                return true;
            }
        }

        return false;
    }

    [SerializeField] private MonoBehaviour abilityScript;

    [SerializeField] private Transform feet;

    [SerializeField] private float maxRunSpeed;
    [SerializeField] private float accelRate;
    [SerializeField] private float deccelRate;
    [SerializeField] private float maxJumpInputDelay;
    [SerializeField] private float jumpForce;
    [SerializeField] private float coyoteTime;

    [SerializeField] private AudioClip jumpSfx;

    private PlayerInteract playerInteract;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    private TutorialTrigger tutorialToTrigger;

    private float horizontalInput;

    private float jumpInputTimer;
    [SerializeField] private float jumpCoyoteTimer;
    // public bool blockMovement = false;
}
