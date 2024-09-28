using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
    }

    public void setTutorialText(string text)
    {
        tutorialText.text = text;
    }

    public void setTutorialTextVisibility(bool visible)
    {
        tutorialText.gameObject.SetActive(visible);
    }

    public static HUD instance;

    [SerializeField] private TextMeshProUGUI tutorialText;
}
