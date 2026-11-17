using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{

    public static SceneControl instance; //This makes it so that any script can reference it 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //Sets this to instance if instance is equal to nothing and prevents it from being destoyed on loading a scene
        }
        else
        {
            Destroy(gameObject); //Destroys any duplicates 
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1); //Gathers the scene its currently in and and adds one to move to the next scene
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex); //Restarts the current scene
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName); //Takes the name of a scene that can can be travelled to

    }
}
