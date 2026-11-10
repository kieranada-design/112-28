using UnityEngine;
using System.Collections;

public class ArrowPhysics : MonoBehaviour
{
    private Rigidbody2D r;
    private BoxCollider2D coll;
    public Vector2 setCenterOfMass;

    void Awake()
    {
        r = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        r.centerOfMass = setCenterOfMass;
    }

    void FixedUpdate()
    {
	if (r != null)
	{
	    transform.rotation = Quaternion.LookRotation(Vector3.forward, r.linearVelocity);
	    transform.Rotate(0, 0, 90);
	}
    }

    void OnCollisionEnter2D(Collision2D other)
    {
	if (other.gameObject.tag == "Ground")
	{
	    coll.enabled = false;
	    Destroy(r);
	}
    }
}
