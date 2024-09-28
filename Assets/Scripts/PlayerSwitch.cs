using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{

    [SerializeField] private bool isPlayer1On;
    [SerializeField] private bool isPlayer2On;

    [SerializeField] private PlayerController pc1;
    // Start is called before the first frame update
    void Start()
    {
        isPlayer1On = true;
        isPlayer2On = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
