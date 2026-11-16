using UnityEngine;

public class EnemyDirection : MonoBehaviour
{
  public GameObject player;
   
    public Enemy enemy;
    private void Update()
    {
        Vector3 scale = transform.localScale;


        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            enemy.EnemyLogic();
            
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
            enemy.EnemyLogic();
        }
        transform.localScale = scale;
        
    }
}
