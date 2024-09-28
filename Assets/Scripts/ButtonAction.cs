using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] private Action pressAction;

    public void ClickButton()
    {
        pressAction.PerformAction();
    }
}
