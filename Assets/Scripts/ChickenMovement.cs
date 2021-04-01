using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    public float moveSpeed = 30.0f;
    public float jumpForce = 25.0f;
    protected float originalSpeed;
    protected Rigidbody rb;
    protected SphereCollider col;
    public LayerMask groundLayers;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = moveSpeed;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();

    }

    //Check if the player is grounded.
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.9f, groundLayers);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Left")
        {
           
            rb.rotation = Quaternion.LookRotation(-other.gameObject.transform.right);
            moveSpeed = 25.0f;
            
        }
        if (other.gameObject.tag == "Right")
        {
            
            transform.rotation = Quaternion.LookRotation(other.gameObject.transform.right);
            moveSpeed = 25.0f;
        }
        
    }

    void OnTriggerExit(Collider other)
    {     
        if (other.gameObject.tag == "Right")
        {

            moveSpeed = originalSpeed;

        }
        if (other.gameObject.tag == "Left")
        {

            moveSpeed = originalSpeed;
        }
    }

    void FixedUpdate()
    {

        float hmove = Input.GetAxis("Horizontal");
        //float vmove = Input.GetAxis("Vertical");
        //vmove = Mathf.Clamp01(vmove);
        float vmove = 1.0f;
        Camera cam = Camera.main;
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = cam.transform.right;
        right.y = 0;
        right.Normalize();

        if (vmove != 0)
        {
            if (IsGrounded())
            {
                // Vector3 move = hmove * transfom.right + vmove * forward;//One of the two, don't know which one is better
                Vector3 move = hmove * right + vmove * forward;
                rb.MovePosition(rb.position + move * Time.fixedDeltaTime * moveSpeed);
            }
            else if (!IsGrounded())
            {
                Vector3 move = vmove * forward;
                rb.MovePosition(rb.position + move * Time.fixedDeltaTime * moveSpeed);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {         
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }


}
