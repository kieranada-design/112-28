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
}
