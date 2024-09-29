using UnityEngine;
using UnityEngine.SceneManagement;

public class deathZoneScript : MonoBehaviour
{

    public static deathZoneScript instance;
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
    void OnTriggerEnter2D(Collider2D col) 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
