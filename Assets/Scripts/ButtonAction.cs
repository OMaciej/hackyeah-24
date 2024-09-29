using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] private Action enableAction;
    [SerializeField] private Action disableAction;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;


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
            spriteRenderer.sprite = onSprite;
            enableAction.PerformAction();
        } 
        
        else
        {
            spriteRenderer.sprite = offSprite;
            disableAction.PerformAction();
        }
    }
}
