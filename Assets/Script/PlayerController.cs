using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int jumpForce = 6;
    Rigidbody2D playerRigidBody;
    public LayerMask groundMask;

    [SerializeField]
    float raycastLong = 1.5f;

    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        Debug.DrawRay(this.transform.position, Vector2.down * raycastLong, Color.green);
    }

    void Jump()
    {
        if (isTouchingTheGround())
        {
            playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool isTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, raycastLong, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
