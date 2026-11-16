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

    }
}
