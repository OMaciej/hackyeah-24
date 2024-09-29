using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        playerInteract = GetComponent<PlayerInteract>();

        jumpInputTimer = 0f;
        jumpCoyoteTimer = 0f;

        platformObjectController = GetComponent<PlatformObjectController>();
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

        Vector2 platformVelocity = platformObjectController.getPlatformVelocity();

        forceToApply = (targetSpeed - rb.velocity.x) * accel;

        rb.AddForce(Vector2.right * forceToApply + new Vector2(platformVelocity.x, 0f), ForceMode2D.Impulse);
        rb.AddForce(new Vector2(0f, platformVelocity.y), ForceMode2D.Force);

        if (rb.velocity == Vector2.zero)
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Jump", false);

        }
        else if (rb.velocity.x > 0)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Jump", false);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        }
        else if (rb.velocity.x < 0)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Jump", false);
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        }
    }

    private void OnEnable()
    {
        if (abilityScript != null) 
        {
            abilityScript.enabled = true;
            if(this.gameObject.name == "Player3")
            {
                this.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
            
    }

    private void OnDisable()
    {
        if (abilityScript != null)
            abilityScript.enabled = false;
            if(this.gameObject.name == "Player3")
            {
                this.transform.GetChild(1).gameObject.SetActive(false);
            }
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
        anim.SetBool("Jump", true);
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
    [SerializeField] private float speed;
    [SerializeField] private float accelRate;
    [SerializeField] private float deccelRate;
    [SerializeField] private float maxJumpInputDelay;
    [SerializeField] private float jumpForce;
    [SerializeField] private float coyoteTime;

    [SerializeField] private AudioClip jumpSfx;

    private PlayerInteract playerInteract;
    private PlatformObjectController platformObjectController;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public Animator anim;

    private TutorialTrigger tutorialToTrigger;

    private float horizontalInput;

    private float jumpInputTimer;
    [SerializeField] private float jumpCoyoteTimer;
    // public bool blockMovement = false;
}
