using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;

    

    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;

    void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
        //Referencing the animator component and setting the timer to its defualt state
    }

    void Update()
    {
        if (inRange)
        {
            Vector2 direction = (target.transform.position - rayCast.position).normalized;
            hit = Physics2D.Raycast(rayCast.position, direction, rayCastLength, raycastMask);
            RayCastDebugger(direction);
            //If inRange is true this will shout out the raycast in the direction of the target which is set once a "Player" tagged object is within a certain distance. This also calls a debugger function i made just for a visual cue
        }

        if (hit.collider != null)
        {
            EnemyLogic();
            //If The raycast is not equal to null it will call the enemy logic function
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            anim.SetBool("canWalk", false);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        } //This will check to see that whatever has entered the trigger area has the tag "Player" and if this is true it will set the player to the target and set inRange to true
        else
        {
            inRange = false;
        }
    }

    public void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)   //EnemyLogic is the brain of the enemy and will call different functions based on whats going on
                                                                   //Firstly it gets the distance between itself and the target then checks to see if its greater than the attack distance. If this is true it calls the StopAttack and Move functions
        {                                                          //Secondly it checks to see if  its attack distance is more than or equal to the distance from the player and if cooling is false. Only them will it call the attack function.
                                                                   //Lastly if the cooling boolean is true it will set attacking to false and call the Cooldown function
            Attack();
        }                                                          

        if (cooling)
        {
            anim.SetBool("Attack", false);
            CoolDown();
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        //The move function is fairly simple it sets canWalk to true and then checks to see if the Attack animation boolean is false then it gathers the targets position and uses a simple Vector2.MoveTowards to follow the player
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
        //All the attack function does is set the canWalk bool to false and actiates the Attack bool animation while resetting the timer and setting the attack mode bool to true. 
        //This works in game due to a seperate script ive placed on the enemies hitbox that uses a simple OnCollisionEnter2D function
    }

    void CoolDown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        } //CoolDown method is used to make the enemy cool down after an attack by counting down the timer and resetting it when it reaches 0. It also sets cooling to false and allows the enemy to attack again.
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
        
    }

    void RayCastDebugger(Vector2 direction)
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, direction * rayCastLength, Color.red);
        }
        else
        {
            Debug.DrawRay(rayCast.position, direction * rayCastLength, Color.green);
        }
        //This will make it so i can see the raycast in the editor. Red is present when the enemy can see the enemy but cant attack and green is for when the enemy can attack
    }

    public void Cooling()
    {
        cooling = true;
        //this method is used to set cooling to true, it is called from the animation event at the end of the attack animation so that the enemy starts cooling down after attacking.
    }
}