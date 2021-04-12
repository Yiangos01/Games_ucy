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
    public bool isgrounded;
    protected Animator animator;
    protected ChickenStatus chSt;
    protected Vector3 vel = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = moveSpeed;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>(); //GetComponent<Animator>();
        chSt = GetComponent<ChickenStatus>();
    }

    //Check if the player is grounded.
    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.2f, groundLayers, QueryTriggerInteraction.Ignore);
    }

    //void OnTriggerEnter(Collider other)
    //{
        
    //    if (other.gameObject.tag == "Left")
    //    {

           
    //          moveSpeed = 25.0f;
           
           
    //    }
    //    if (other.gameObject.tag == "Right")
    //    {

           
    //          moveSpeed = 25.0f;


           

    //    }

    //}
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Left")
        {
          
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(-other.gameObject.transform.right), 0.2f);

           

        }
        if (other.gameObject.tag == "Right")
        {
            

            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(other.gameObject.transform.right), 0.2f);

           
        }

    }

    //void OnTriggerExit(Collider other)
    //{     
    //    if (other.gameObject.tag == "Right")
    //    {

    //        moveSpeed = originalSpeed;

    //    }
    //    if (other.gameObject.tag == "Left")
    //    {

    //        moveSpeed = originalSpeed;
    //    }
    //}

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
            if (IsGrounded() && !chSt.isHit)
            {
                // Vector3 move = hmove * transfom.right + vmove * forward;//One of the two, don't know which one is better
                Vector3 move = hmove * right + vmove * forward;
                rb.MovePosition(rb.position + move * Time.fixedDeltaTime * moveSpeed);
                transform.GetChild(0).gameObject.transform.rotation = Quaternion.LookRotation(move);//change direction of chicken mesh according with the movement(go right-left)
            }
            else if (!IsGrounded())
            {
                Vector3 move = vmove * forward;
                rb.MovePosition(rb.position + move * Time.fixedDeltaTime * moveSpeed);
                transform.GetChild(0).gameObject.transform.rotation = Quaternion.LookRotation(move);//change direction of chicken mesh according with the movement(go right-left)
            }
        }
        //Set Run Animation
        animator.SetFloat("ChickenSpeed", vmove);
        //Set part of Jump animation
        animator.SetBool("IsGrounded", IsGrounded());
        
 
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && !chSt.isHit)
        {   //Jump Force
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //Set part of Jump animation
            animator.SetTrigger("Jump");
           
        }
        isgrounded = IsGrounded();

    }


}
