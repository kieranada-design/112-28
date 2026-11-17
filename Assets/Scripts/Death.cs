//Access libraries
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
	//Checks if death plane is colliding with player
        if (collision.CompareTag("Player"))
        {
            //Restarts the level via reloading the scene
            SceneControl.instance.Restart();
        }
    }
}
