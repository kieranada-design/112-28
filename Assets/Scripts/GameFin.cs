using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneControl.instance.LoadScene("Menu");
        }
    }
} //I attached this to the last flame in level 10 and it will just take the player back to the menu