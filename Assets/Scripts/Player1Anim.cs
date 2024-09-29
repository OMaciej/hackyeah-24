using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Anim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        spriteId = 0;
        currentSID = 0;

        anim = 0;
        currentAnim = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(spriteId != currentSID)
        {

        }
    }

    public int spriteId;
    public int anim;

    private int currentSID;
    private int currentAnim;

    [SerializeField] private Sprite[] walk;
    [SerializeField] private Sprite[] jumpingAnim;
    [SerializeField] private Sprite[] fallingAnim;
}
