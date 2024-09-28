using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : Action
{

    private Renderer objectRenderer;
    private Collider2D objectCollider;
    public override void PerformAction()
    {
        objectRenderer.enabled = false;
        objectCollider.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
