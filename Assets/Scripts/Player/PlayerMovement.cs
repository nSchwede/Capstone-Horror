using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float jumpForce;

    public float jumpCoolDown;

    public float airMult;
    
    bool readyJump;

    [Header("Ground")]
    public float playerHeight;
    public float groundDrag;
    public LayerMask whatGround;
    public bool grounded;

    [Header("Keybinds")]
    public KeyCode jumpkey = KeyCode.Space;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    public Rigidbody rb;

    private void Start()
    {
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // on ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.75f + 10.0f, whatGround); 

        MyInput();
        SpeedControl();

        // apply drag as to not ice skate
        if(grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    } 

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyUp(jumpkey) && readyJump && grounded)
        {
            readyJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCoolDown);
        }
    }

    private void MovePlayer()
    {
        // gives movement vector based on orientation of the camera in x z
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // applies the force that moves the player in the calculated direction

        // on ground
        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMult, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVal = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // speed limit
        if(flatVal.magnitude > moveSpeed)
        {
            Vector3 limitedVal = flatVal.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVal.x, rb.linearVelocity.y, limitedVal.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        //rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyJump = true;
    }
}
