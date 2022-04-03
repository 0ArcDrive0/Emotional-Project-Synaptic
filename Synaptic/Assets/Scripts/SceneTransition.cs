using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string SceneToLoad;
    public Vector2 playerPosition;
    public VectorPosition playerStorage;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initalValue = playerPosition;
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}

