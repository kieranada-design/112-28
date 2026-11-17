using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
   public void OnStartClick()
    {
        SceneManager.LoadScene("Level 1"); //If the player clicks "Start" it will take them to level 1 of the game
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR //If "Exit" is clicked it sets the Unity Editor application to false. Quitting out of the game
        UnityEditor.EditorApplication.isPlaying = false; 
#endif
    }
}
