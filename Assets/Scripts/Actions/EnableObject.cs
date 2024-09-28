using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : Action
{
    [SerializeField] GameObject DisappearingObject;

    private Renderer objectRenderer;
    private Collider2D objectCollider;
    public override void PerformAction()
    {
        objectRenderer.enabled = true;
        objectCollider.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = DisappearingObject.GetComponent<Renderer>();
        objectCollider = DisappearingObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
