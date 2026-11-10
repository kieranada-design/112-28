using UnityEngine;
using System.Collections;

public class TargetHit : MonoBehaviour
{
    public FinishPoint thisEnd;
    private BoxCollider2D coll;

    void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
           
            thisEnd.hit += 1;
	    coll.enabled = false;
        }
    }
}
