using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ArrowShooting : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float shootForce = 5f;
    private float rotInput;
    private bool canShoot;
    private bool turned;

    void Awake()
    {
        canShoot = true;
	turned = false;
    }

    void Update()
    {
        Input();
    }

    private void Input()
    {
        Keyboard kb = Keyboard.current;
        if (kb.aKey.isPressed && !turned)
        {
	    transform.Rotate(new Vector3(0, 0, 180));
            turned = true;
        }
        if (kb.dKey.isPressed && turned) 
        {
	    transform.Rotate(new Vector3(0, 0, 180));
            turned = false;
        }
        if (kb.shiftKey.isPressed)
        {
            if (kb.wKey.isPressed)
            {
		transform.Rotate(new Vector3(0, 0, 0.25f));
	    }
            if (kb.sKey.isPressed)
            {
		transform.Rotate(new Vector3(0, 0, -0.25f));
	    }
	    if (kb.ctrlKey.isPressed && canShoot)
	    {
		canShoot = false;
		GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
		Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
		rb.AddForce(arrow.transform.right * shootForce, ForceMode2D.Impulse);
		StartCoroutine(reload());
	    }
	}
    }

    private IEnumerator reload()
    {
	yield return new WaitForSeconds(1f);
	canShoot = true;
    }
}
