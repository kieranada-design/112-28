//Access libraries
using UnityEngine;
using System.Collections;

public class TargetHit : MonoBehaviour
{
    //Initialise variables/components
    public FinishPoint thisEnd;
    private BoxCollider2D coll;

    void Awake()
    {
	//Get component from target object
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
	//Checks for collision with an arrow
        if (collision.CompareTag("Arrow"))
        {
            //Counts up the counter for targets hit this level by one
            thisEnd.hit += 1;

	    //Disables the box collider
	    coll.enabled = false;
        }
    }
}
