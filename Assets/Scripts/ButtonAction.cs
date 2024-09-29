using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] private Action enableAction;
    [SerializeField] private Action disableAction;

    private bool toggled;

    private void Start()
    {
        toggled = false;
    }

    public void ClickButton()
    {
        toggled = !toggled;

        if (toggled)
        {
            enableAction.PerformAction();
        } 
        
        else
        {
            disableAction.PerformAction();
        }
    }
}
