using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{

    //[SerializeField] private bool isPlayer1On;
    //[SerializeField] private bool isPlayer2On;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private GameObject player4;
    // Start is called before the first frame update
    void Start()
    {
        player1.GetComponent<PlayerController>().enabled = true;
        player2.GetComponent<PlayerController>().enabled = false;
        player3.GetComponent<PlayerController>().enabled = false;
        player4.GetComponent<PlayerController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")) {
            player1.GetComponent<PlayerController>().enabled = true;
            player2.GetComponent<PlayerController>().enabled = false;
            player3.GetComponent<PlayerController>().enabled = false;
            player4.GetComponent<PlayerController>().enabled = false;
        }
        if(Input.GetKeyDown("2")) {
            player1.GetComponent<PlayerController>().enabled = false;
            player2.GetComponent<PlayerController>().enabled = true;
            player3.GetComponent<PlayerController>().enabled = false;
            player4.GetComponent<PlayerController>().enabled = false;
        }
        if(Input.GetKeyDown("3")) {
            player1.GetComponent<PlayerController>().enabled = false;
            player2.GetComponent<PlayerController>().enabled = false;
            player3.GetComponent<PlayerController>().enabled = true;
            player4.GetComponent<PlayerController>().enabled = false;
        }
        if(Input.GetKeyDown("4")) {
            player1.GetComponent<PlayerController>().enabled = false;
            player2.GetComponent<PlayerController>().enabled = false;
            player3.GetComponent<PlayerController>().enabled = false;
            player4.GetComponent<PlayerController>().enabled = true;
        }
    }
}
