using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SteelBoxScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float defaultMass = 5f;

    // Update is called once per frame
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag != "StrongLemur") 
        {
            rb.mass = 10000;
        } else 
        {
            rb.mass = defaultMass;
        }
    }
    
}
