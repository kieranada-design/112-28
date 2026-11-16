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

}
