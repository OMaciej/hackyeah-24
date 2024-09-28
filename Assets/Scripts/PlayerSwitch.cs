using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private GameObject player4;

    private PlayerController pc1;
    private PlayerController pc2;
    private PlayerController pc3;
    private PlayerController pc4;

    // Start is called before the first frame update
    void Start()
    {
        pc1 = player1.GetComponent<PlayerController>();
        pc2 = player2.GetComponent<PlayerController>();
        pc3 = player3.GetComponent<PlayerController>();
        pc4 = player4.GetComponent<PlayerController>();


        pc1.enabled = true;
        pc2.enabled = false;
        pc3.enabled = false;
        pc4.enabled = false;

        setCameraFocus(player1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")) {
            pc1.enabled = true;
            pc2.enabled = false;
            pc3.enabled = false;
            pc4.enabled = false;

            setCameraFocus(player1);
        }
        if(Input.GetKeyDown("2")) {
            pc1.enabled = false;
            pc2.enabled = true;
            pc3.enabled = false;
            pc4.enabled = false;

            setCameraFocus(player2);
        }
        if(Input.GetKeyDown("3")) {
            pc1.enabled = false;
            pc2.enabled = false;
            pc3.enabled = true;
            pc4.enabled = false;

            setCameraFocus(player3);
        }
        if(Input.GetKeyDown("4")) {
            pc1.enabled = false;
            pc2.enabled = false;
            pc3.enabled = false;
            pc4.enabled = true;

            setCameraFocus(player4);
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
}
