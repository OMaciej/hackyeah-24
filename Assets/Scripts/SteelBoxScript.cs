using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SteelBoxScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    // Update is called once per frame
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 20;
    }
    
}
