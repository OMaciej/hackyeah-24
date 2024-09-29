using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScript : Action
{
    public override void PerformAction()
    {
        script.enabled = false;
    }

    [SerializeField] private MonoBehaviour script;
}
