//Access libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    //Initialise variables/components
    public int toHit;
    public int hit;
    private BoxCollider2D coll;
    private SpriteRenderer rend;

    void Awake()
    {
	//Set initial values + get components fro object
	hit = 0;
        rend = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

	//Disables the box collider and sprite renderer
	rend.enabled = false;
	coll.enabled = false;
    }

    void Update()
    {
	//Checks if targets hit ar at least the amount required

	//Note: >= used instead of == as a failsafe
	if (hit >= toHit)
	{
	    //Enables the box collider and sprite renderer
	    rend.enabled = true;
	    coll.enabled = true;
	}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
	//Checks if colliding with player
        if (collision.CompareTag("Player"))
        {
            //Loads the next level in sequence
            SceneControl.instance.NextLevel();
        }
    }
}
