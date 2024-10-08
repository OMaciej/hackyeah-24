using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBotLefCor : MonoBehaviour
{  
    public static DontDestroyBotLefCor instance;
    private void Awake()
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

}
