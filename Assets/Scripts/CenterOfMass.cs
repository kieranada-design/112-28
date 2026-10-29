using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    private Rigidbody2D r;
    public Vector2 setCenterOfMass;

    void Awake()
    {
        r = GetComponent<Rigidbody2D>();
        r.centerOfMass = setCenterOfMass;
    }

    void FixedUpdate()
    {
	transform.rotation = Quaternion.LookRotation(Vector3.forward, r.linearVelocity);
	transform.Rotate(0, 0, 90);
    }
}
