using UnityEngine;

public class EnemyDirection : MonoBehaviour
{
  public GameObject player;
  public GameObject enemyOb;
   

    private void Update()
    {
        Vector3 scale = transform.localScale;


        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            
            
        }
        else
        {
             scale.x = Mathf.Abs(scale.x);
            
        }
        enemyOb.transform.localScale = scale;
        
    }
}
