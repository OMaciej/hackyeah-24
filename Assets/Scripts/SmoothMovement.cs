using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// This class is used to smoothly move an object from point A to point B
/// </summary>
public class SmoothMovement : MonoBehaviour
{
    private void Update()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = endPos - pos;
        direction.Normalize();

        Vector2 posChange = direction * movementSpeed * Time.deltaTime;

        pos += posChange;

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);

        if(Vector2.Distance(pos, endPos) < 1f)
        {
            transform.position = new Vector3(endPos.x, endPos.y, transform.position.z);
            this.enabled = false;
        }
    }

    public void move(Vector2 _endPos, float _movementSpeed)
    {
        endPos = _endPos;
        movementSpeed = _movementSpeed;
        this.enabled = true;
    }

    private Vector2 endPos;
    private float movementSpeed;
}
