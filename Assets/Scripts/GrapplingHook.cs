using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GrapplingHook : MonoBehaviour
{
    private GameObject player;
    public float acceleration;
    public float maxSpeed;
    private Transform playerTransform;
    private Rigidbody2D rb;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>().parent.gameObject;
        Debug.Assert(player != null);

        playerTransform = player.GetComponent<Transform>();
        rb = player.GetComponent<Rigidbody2D>();
        // Get the LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();

        Debug.Assert(playerTransform != null);
        Debug.Assert(rb != null);
        Debug.Assert(lineRenderer != null);
    }

    private Vector2 GetPointerPosition()
    {
        Vector3 mouseScreenPosition = new(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        return (Vector2)mouseWorldPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the number of positions (2 for a line)
        // lineRenderer.positionCount = 2;

        // Define the start and end positions
        Vector3 playerPosition = playerTransform.position;
        Vector3 pointerPosition = GetPointerPosition();
        Vector3 startPosition = playerPosition;
        Vector3 endPosition = pointerPosition;

        // Set the positions in the LineRenderer
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);

        if (Input.GetMouseButtonDown(0))
        {
            OnLeftMouseClick();
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnLeftMouseRelease();
        }
    }

    Vector2 accelerationDirection;

    void OnLeftMouseClick()
    {
        Debug.Log("Mouse clicked");
        Vector3 playerPosition = playerTransform.position;
        Vector3 pointerPosition = GetPointerPosition();
        accelerationDirection = (Vector2)(pointerPosition - playerPosition);
        accelerationDirection.Normalize();
        Debug.Log(accelerationDirection);
    }
    void OnLeftMouseRelease()
    {
        Debug.Log("Mouse released");
        accelerationDirection = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        if (accelerationDirection.magnitude > 0)
        {
            // Calculate the new velocity based on acceleration in the specified direction
            rb.velocity += acceleration * Time.fixedDeltaTime * accelerationDirection;

            // Clamp the velocity to the maximum speed
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

            Debug.Log(accelerationDirection);
            Debug.Log(rb.velocity);
        }

        // rb.AddForce(Vector2.right * 100f, ForceMode2D.Impulse);
    }
}
