using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPl1 : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.tag = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            rb.transform.localScale = new UnityEngine.Vector3(2f, 2f, 0);
            rb.tag = "StrongLemur";

        }

        if (Input.GetKeyDown("e"))
        {
            rb.transform.localScale = new UnityEngine.Vector3(1f, 1f, 0);
            rb.tag = "Player";
        }
    }
}
