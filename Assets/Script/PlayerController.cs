using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 6f;
    public float runningSpeed = 2f;

    Rigidbody2D rigidBody;
    public LayerMask groundMask;

    [SerializeField]
    float raycastLong = 1.5f;
    Animator animator;

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";
    const string STATE_RUNNING = "isRunning";

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);
        animator.SetBool(STATE_RUNNING, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        animator.SetBool(STATE_ON_THE_GROUND, isTouchingTheGround());
        Debug.DrawRay(this.transform.position, Vector2.down * raycastLong, Color.green);
    }

    void FixedUpdate()
    {
        move();
        //moveWithKey();
    }

    void move() {
        
        if ( rigidBody.velocity.x < runningSpeed) {
            animator.SetBool(STATE_RUNNING, true);
            rigidBody.velocity = new Vector2( runningSpeed, rigidBody.velocity.y );
        }
    }
    
    void moveWithKey() {

        if (rigidBody.velocity.x == 0 && isTouchingTheGround()) {
            animator.SetBool(STATE_RUNNING, false);
        }

        rigidBody.velocity = new Vector2 ( Input.GetAxis("Horizontal")*runningSpeed, rigidBody.velocity.y );

        if (Input.GetAxis("Horizontal") < 0){
            animator.SetBool(STATE_RUNNING, true);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        else if (Input.GetAxis("Horizontal") > 0){
            animator.SetBool(STATE_RUNNING, true);
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }

    void Jump()
    {
        if (isTouchingTheGround())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool isTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, raycastLong, groundMask))
        {
            // animator.enabled = true;
            return true;
        }
        else
        {
            // animator.enabled = false;
            return false;
        }
    }
}
