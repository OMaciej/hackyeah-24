using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, endPos.position) < 0.2f)
        {
            Transform tmp = endPos;
            endPos = startPos;
            startPos = tmp;
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = endPos.position - startPos.position;
        direction.Normalize();

        rb.velocity = direction * movementSpeed * Time.deltaTime;
    }

    [SerializeField] private Transform endPos;
    [SerializeField] private Transform startPos;
    [SerializeField] private float movementSpeed;

    private Rigidbody2D rb;
}
