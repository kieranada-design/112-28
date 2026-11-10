

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public int toHit;
    public int hit;
    private BoxCollider2D coll;
    private SpriteRenderer rend;

    void Awake()
    {
	hit = 0;
        rend = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
	rend.enabled = false;
	coll.enabled = false;
    }

    void Update()
    {
	if (hit >= toHit)
	{
	    rend.enabled = true;
	    coll.enabled = true;
	}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            SceneControl.instance.NextLevel();
        }
    }
}
