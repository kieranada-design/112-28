//Access libraries
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ArrowShooting : MonoBehaviour
{
    //Initialise variables
    public GameObject arrowPrefab;
    public float shootForce = 5f;
    private float rotInput;
    private bool canShoot;
    private bool turned;

    void Awake()
    {
	//Set initial values
        canShoot = true;
	turned = false;
    }

    void Update()
    {
	//Run Input function
        Input();
    }

    private void Input()
    {
	//Assign keyboard
        Keyboard kb = Keyboard.current;

	//Check for inputs
        if (kb.aKey.isPressed && !turned)
        {
	    //Face shooter left
	    transform.Rotate(new Vector3(0, 0, 180));
            turned = true;
        }
        if (kb.dKey.isPressed && turned) 
        {
	    //Face shooter right
	    transform.Rotate(new Vector3(0, 0, 180));
            turned = false;
        }
        if (kb.shiftKey.isPressed)
        {
            if (kb.wKey.isPressed)
            {
		//Rotate shoooter to point further up
		transform.Rotate(new Vector3(0, 0, 0.25f));
	    }
            if (kb.sKey.isPressed)
            {
		//Rotate shoooter to point further down
		transform.Rotate(new Vector3(0, 0, -0.25f));
	    }
	    if (kb.ctrlKey.isPressed && canShoot)
	    {
		//Prevent user from shooting again
		canShoot = false;

		//Creates an arrow from cloning the arrow prefab and gets its Rigidbody2d
		GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
		Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

		//Gives the arrow a force based on the direction it's pointing and the predefined shoot force
		rb.AddForce(arrow.transform.right * shootForce, ForceMode2D.Impulse);

		//Starts the reload coroutine
		StartCoroutine(reload());
	    }
	}
    }

    private IEnumerator reload()
    {
	//Waits for 1 second
	yield return new WaitForSeconds(1f);

	//Allows the user to shoot again
	canShoot = true;
    }
}
