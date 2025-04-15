using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockManager : MonoBehaviour
{
    public GameObject persistingParent;


    private void Update()
    {



        // Creating a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        // if gameover destroy jenga
        if (sceneName == "EndScreen")
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {

        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;


    }
    private void SceneManager_activeSceneChanged(Scene umm, Scene currentScene)
    {
        if (currentScene.name == "Jenga Area")
        {
            persistingParent.SetActive(true);
        }

        else
        {
            persistingParent.SetActive(false);
        }
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= SceneManager_activeSceneChanged;
    }
}