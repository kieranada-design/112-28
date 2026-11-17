using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject enemy;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Object.Destroy(collision.gameObject);
        }
        //This script attaches to the Arrow prefab and checks to see if it collides with anything tagged "Enemy". If true it will destroy the object
    }
}
