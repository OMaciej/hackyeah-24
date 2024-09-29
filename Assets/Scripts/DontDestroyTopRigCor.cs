using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyTopRigCor : MonoBehaviour
{  
    public static DontDestroyTopRigCor instance;
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
