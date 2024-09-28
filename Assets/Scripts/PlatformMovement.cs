using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    [SerializeField] private SmoothMovement sMovement;
    [SerializeField] private Transform endPos;
    [SerializeField] private Transform startPos;
    [SerializeField] private float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        sMovement = GetComponent<SmoothMovement>();
        sMovement.move(endPos.position, movementSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!sMovement.enabled) 
        {
            Transform temp = startPos;
            startPos = endPos;
            endPos = temp;
            Debug.Log(endPos.position);
            sMovement.move(endPos.position, movementSpeed);
        }
    }
}
