using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    private void Start()
    {
        foreach(GameObject character in characters)
        {
            characterControllers.Add(character.GetComponent<PlayerController>());
        }

        currentCharacter = 0;

        foreach(PlayerController pc in characterControllers) {
            pc.enabled = false;
        }

        characterControllers[0].enabled = true;

        setCameraFocus(characters[0]);
    }

    private void Update()
    {
        for (int i = 0; i < characterControllers.Count; i++) {
            if (Input.GetKeyDown(switchKeyCodes[i]))
            {
                if(i == currentCharacter)
                {
                    continue;
                }
                characterControllers[i].enabled = true;
                characterControllers[currentCharacter].enabled = false;
                currentCharacter = i;

                setCameraFocus(characters[i]);
            }
        }
    }

    private void setCameraFocus(GameObject character)
    {
        //some levels may be using a static camera, so check if a CameraFollower exists
        if(CameraFollower.instance != null)
        {
            CameraFollower.instance.setFocusOnCharacter(character);
        }
    }

    [SerializeField] private GameObject[] characters;

    [SerializeField] private List<PlayerController> characterControllers;

    //the id of the character we're currently controlling
    private int currentCharacter;

    //the keys that will be used to switch to a given character
    private KeyCode[] switchKeyCodes =
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
        KeyCode.Alpha0
    };
}
