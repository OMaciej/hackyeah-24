using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kopciuch : MonoBehaviour
{
    public SceneAsset nextScene;

    bool isPlayer(Collider2D other)
    {
        return other.gameObject.layer == LayerMask.NameToLayer("Character");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayer(collision))
            SceneManager.LoadScene(nextScene.name);
    }
}
