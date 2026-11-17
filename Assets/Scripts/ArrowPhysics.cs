//Access libraries
using UnityEngine;
using System.Collections;

public class ArrowPhysics : MonoBehaviour
{
    //Initialise variables/components
    private Rigidbody2D r;
    private BoxCollider2D coll;
    public Vector2 setCenterOfMass;

    void Awake()
    {
	//Get components from arrow object
        r = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

	//Set object's center of mass to appropriate position
        r.centerOfMass = setCenterOfMass;
    }

    void FixedUpdate()
    {
	//Check if rigidbody is still active
	if (r != null)
	{
	    //Rotate arrow to point in direction of movement

	    //Note: LookRotation usually uses format (look vector, fixed vector)
	    //This, however, has to be swapped for 2D space, which was found on accident
	    //Will look into this further

	    transform.rotation = Quaternion.LookRotation(Vector3.forward, r.linearVelocity);
	    transform.Rotate(0, 0, 90);
	}
    }

    void OnCollisionEnter2D(Collision2D other)
    {
	//Check if colliding with ground
	if (other.gameObject.tag == "Ground")
	{
	    //Disable box collider
	    coll.enabled = false;

	    //Remove Rigidbody2d component
	    Destroy(r);
	}
    }
}
