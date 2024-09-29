using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitForKey : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    [SerializeField] private string sceneToLoad;
}
