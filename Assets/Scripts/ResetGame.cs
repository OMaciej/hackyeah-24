using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{

    public static ResetGame instance;
    // Start is called before the first frame update
    void Awake() 
        {
                if(instance == null)
            {
                instance = this;
            } else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }

    void Update() 
        {
            if(Input.GetKeyUp(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
}

