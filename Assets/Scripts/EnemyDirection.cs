using UnityEngine;

public class EnemyDirection : MonoBehaviour
{
  public GameObject player;
  public GameObject enemyOb;
   //This script takes two Game Objects, that of the player and the enemy itself

    private void Update()
    {
        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;                            //This script basically checks the players position on the X axis and if its greater than that of the Enemy it will flip the whole game object
        }                                                     //(for some reason i had a problem where if i didnt reference the enemy object the whole logic of the enemy would fly out the window thats why its referencing itself even though its attached directly to the enemy)
        else
        {
             scale.x = Mathf.Abs(scale.x);
            
        }
        enemyOb.transform.localScale = scale;
        
    }
}
