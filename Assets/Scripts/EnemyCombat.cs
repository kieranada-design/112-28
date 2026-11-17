using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneControl.instance.Restart();
        }
    }
} //This calls a restart of the current scene if the player gets hit with this collider that is attached to the enemies weapon and moves with the enemies animation
