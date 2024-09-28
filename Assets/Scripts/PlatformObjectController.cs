using UnityEngine;

public class PlatformObjectController : MonoBehaviour
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        platform = getPlatform();
    }

    private GameObject getPlatform()
    {
        int platformLayer = LayerMask.GetMask("MovingPlatform");
        RaycastHit2D hit2d = Physics2D.CircleCast(feet.position, 0.3f, Vector2.down, 0.1f, platformLayer);

        if (hit2d.collider != null)
        {
            return hit2d.collider.gameObject;
        }

        return null;
    }

    public Vector2 getPlatformVelocity()
    {
        if (platform == null)
        {
            return Vector2.zero;
        }

        return platform.GetComponent<Rigidbody2D>().velocity;
    }

    [SerializeField] private Transform feet;

    private Rigidbody2D rb;
    private GameObject platform;
}
