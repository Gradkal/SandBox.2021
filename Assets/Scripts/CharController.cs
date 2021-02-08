using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    public CharacterController controller;

    //Stats
    public float moveSpeed = 4f;
    public float JumpForce;

    public Animator anim;

    public Rigidbody rb;
    public bool IsOnTheGround = true;


    public float turnSmoothTime;
    float turnSmoothVelocity;

    Vector3 forward, right;


    //Attack
    public Collider[] attackHitboxes;

    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        rb = GetComponent<Rigidbody>();

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            Move();


        //Jump
        /*if(Input.GetButtonDown("Jump") && IsOnTheGround)
        {
            rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);

            IsOnTheGround = false;
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Move()
    {
        /*
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;

        */

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            controller.Move(direction * moveSpeed * Time.deltaTime);

        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsOnTheGround = true;
        }
    }
}
