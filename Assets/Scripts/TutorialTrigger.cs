using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    private void Start()
    {
        wasEnabled = false;
    }

    public void enableTrigger()
    {
        if(!wasEnabled || !displayOnlyOnce)
        {
            HUD.instance.setTutorialText(textToDisplay);
            HUD.instance.setTutorialTextVisibility(true);
            wasEnabled = true;
        }
    }

    public void disableTrigger()
    {
        HUD.instance.setTutorialTextVisibility(false);
    }

    [SerializeField] private string textToDisplay;
    [SerializeField] private bool displayOnlyOnce;

    private bool wasEnabled;
}
