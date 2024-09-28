using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GrapplingHook : MonoBehaviour
{
    private GameObject player;
    public float acceleration;
    public float maxSpeed;
    public float maxRopeLen;
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
        Vector3 startPosition = playerTransform.position;

        // Set the positions in the LineRenderer
        lineRenderer.SetPosition(0, startPosition);

        if (GetClickedAnchorPosition(out Vector3 anchorPosition))
        {
            TryToGrabPoint(anchorPosition);
        }
        else
        {
            Unbrab();
        }

        // if (Input.GetMouseButton(0))
        // {
        //     OnLeftMouseClick();
        // }
        // else
        // {
        //     OnLeftMouseRelease();
        // }
    }

    Vector2 accelerationDirection;

    private bool GetClickedAnchorPosition(out Vector3 anchorPosition)
    {
        anchorPosition = Vector3.zero;
        GameObject clickedAnchor = ClickableAnchor.clickedObject;
        if (clickedAnchor != null)
        {
            anchorPosition = clickedAnchor.transform.position;
            return true;
        }
        return false;
    }

    private void TryToGrabPoint(Vector3 pointPosition)
    {
        Vector3 begRope = playerTransform.position;
        Vector3 endRope = pointPosition;
        Vector3 ropeVec = endRope - begRope;
        if (ropeVec.magnitude <= maxRopeLen)
        {
            accelerationDirection = (Vector2)ropeVec.normalized;
            // transform.parent.GetComponent<PlayerController>().blockMovement = true;
        }
        else
        {
            accelerationDirection = new Vector2(0, 0);
            endRope = begRope + ropeVec.normalized * maxRopeLen;
        }
        lineRenderer.SetPosition(1, endRope);
        lineRenderer.enabled = true;
    }

    private void Unbrab()
    {
        accelerationDirection = new Vector3(0, 0, 0);
        lineRenderer.enabled = false;
        // transform.parent.GetComponent<PlayerController>().blockMovement = false;
    }

    // private bool GetAnchorPositionAtPointer(out Vector3 anchorPosition)
    // {
    //     anchorPosition = Vector3.zero;

    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //     // Perform the raycast
    //     if (Physics.Raycast(ray, out RaycastHit hit))
    //     {
    //         Debug.Log("Ray hit some object I guess");
    //         // Check if the hit object has a BoxCollider and is this GameObject
    //         if (hit.collider != null)
    //         {
    //             Debug.Log("Ray hit some object with a collider");

    //             GameObject anchorGameObject = hit.collider.gameObject;
    //             if (anchorGameObject.GetComponent<CanBeAnchor>())
    //             {
    //                 anchorPosition = anchorGameObject.transform.position;
    //                 return true;
    //             }
    //         }
    //     }
    //     return false;
    // }

    // void OnLeftMouseClick()
    // {
    //     Debug.Log("Mouse clicked");
    //     if (GetAnchorPositionAtPointer(out Vector3 anchorPosition))
    //     {
    //         Debug.Log("Clicked anchor");
    //         Vector3 begRope = playerTransform.position;
    //         Vector3 endRope = anchorPosition;
    //         accelerationDirection = (Vector2)(endRope - begRope);
    //         accelerationDirection.Normalize();
    //         Debug.Log(accelerationDirection);
    //         lineRenderer.SetPosition(1, endRope);
    //     }
    // }
    // void OnLeftMouseRelease()
    // {
    //     // Debug.Log("Mouse released");
    //     accelerationDirection = new Vector3(0, 0, 0);
    // }

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
        else
        {
        }

        // rb.AddForce(Vector2.right * 100f, ForceMode2D.Impulse);
    }
}
