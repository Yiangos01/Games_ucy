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

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.9f, groundLayers);
    }

    void OnTriggerEnter(Collider other)
    {
        //if player is on a turning point, change forward direction 
        if (other.gameObject.tag == "West")
        {
           // Vector3 lookAt = new Vector3(-1.0f, 0f, 0f);
            rb.rotation = Quaternion.LookRotation(-other.gameObject.transform.right);
            moveSpeed = 25.0f;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookAt), 1.0f);
        }
        if (other.gameObject.tag == "North")
        {
           // Vector3 lookAt = new Vector3(0f, 0f, 1.0f);
            transform.rotation = Quaternion.LookRotation(other.gameObject.transform.forward);
            moveSpeed = 25.0f;
        }
        if (other.gameObject.tag == "East")
        {
           // Vector3 lookAt = new Vector3(1.0f, 0f, 0f);
            transform.rotation = Quaternion.LookRotation(other.gameObject.transform.right);
            moveSpeed = 25.0f;
        }
        if (other.gameObject.tag == "South")
        {
           // Vector3 lookAt = new Vector3(0f, 0f, -1.0f);
            transform.rotation = Quaternion.LookRotation(-other.gameObject.transform.forward);
            moveSpeed = 25.0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "West")
        {

            moveSpeed = originalSpeed;

        }
        if (other.gameObject.tag == "North")
        {

            moveSpeed = originalSpeed;
        }
        if (other.gameObject.tag == "East")
        {

            moveSpeed = originalSpeed;
        }
        if (other.gameObject.tag == "South")
        {

            moveSpeed = originalSpeed;

        }
    }

    void FixedUpdate()
    {

        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");
        vmove = Mathf.Clamp01(vmove);

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
            //  Debug.Log("Space");
            //  Debug.Log("Jump force " + jumpForce);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        //    //transform.rotation = Quaternion.LookRotation(transform.position);
        //  //  transform.rotation = previousLookRotation;
        //    float hmove = Input.GetAxis("Horizontal");
        //     //float vmove = Input.GetAxisRaw("Vertical");
        //    float vmove = Input.GetAxis("Vertical");
        //    vmove = Mathf.Clamp01(vmove);
        //    // 
        //    Camera cam = Camera.main;
        //    Vector3 forward = cam.transform.forward;
        //    forward.y = 0;
        //    forward.Normalize();

        //    Vector3 right = cam.transform.right;
        //    right.y = 0;
        //    right.Normalize();



        //    if (vmove != 0)//Move only left-right if move forward
        //    {
        //        // Vector3 move = hmove * transfom.right + vmove * forward;//One of the two, don't know which one is better
        //        Vector3 move = hmove * right + vmove * forward;
        //        transform.position += move * Time.deltaTime * moveSpeed;
        //    }
        //    //if (move != Vector3.zero)
        //    //{
        //    //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.1f); //Quaternion.LookRotation(move);
        //    //                                                                                                     // previousLookRotation = transform.rotation;
        //    //    transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
        //    //}
        //    //    //transform.position += Vector3(right * hmove * Time.deltaTime * moveSpeed, 0.0f,forward * vmove * Time.deltaTime * moveSpeed,  );
        //   // }
        //    //transform.position += move * Time.deltaTime * moveSpeed;

    }


}
