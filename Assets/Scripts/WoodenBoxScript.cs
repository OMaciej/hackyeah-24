using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class WoodenBoxScript : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    // Update is called once per frame
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 20;
    }

}
