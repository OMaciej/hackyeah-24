using UnityEngine;

public class PlatformObjectController : MonoBehaviour
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        GameObject platform = getPlatform();
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

    [SerializeField] private Transform feet;

    private Rigidbody2D rb;
}
