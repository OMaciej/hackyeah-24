using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScript : Action
{
    public override void PerformAction()
    {
        script.enabled = true;
    }

    [SerializeField] private MonoBehaviour script;
}
