using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public int health = 10;
    [SerializeField] float speed = 5;
    [SerializeField] float jump = 10;
    [SerializeField] private LayerMask plataformLayerMask;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2d;
    private Animator anim;
    private Vector3 lastPos;

    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()   
    {

       
        //pega a posição do frame atual
        lastPos = rb.transform.position;
        //idle
        if (rb.transform.position == lastPos)
        {
            anim.SetBool("Idle", true);

        }

        //verificar chão ok!
        if (isGrounded() == true)
        {
            anim.SetBool("Grounded", true);
        }
        if(isGrounded() == false)
        {
            anim.SetBool("Grounded", false);
        }

        //verificar corrida ok!

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {

            Run();

            if (isGrounded() != true)
            {
                anim.SetBool("Running", false);
            }

        }
        else
        {
            anim.SetBool("Running", false);
        }

        //Pulo ok!
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            

            Jump();

            if (isGrounded() && rb.velocity.y == 0)
            {
                anim.ResetTrigger("Jumping");
            }
        }


        //ataque
        if (Input.GetKey(KeyCode.Mouse0))
        {
            attack();
        }
        else
        {
            anim.SetBool("Attacking", false);
        }

        //morte
        if(health <= 0)
        {
            respawn();
            StopAnimations();
            health += 1;
        }
       
       
       
            
    }

    private void respawn()
    {
        this.transform.position = spawnPoint.position;
    }
    private void attack()
    {
        anim.SetBool("Attacking", true);

    }

    private void Run()
    {

        anim.SetBool("Running", true);

        //anim.SetBool("Idle", false);

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 180, 0);
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        
        

    }

    private void Jump()
    {
        anim.SetTrigger("Jumping");
        rb.velocity = Vector2.up * jump;

    }
    private void StopAnimations()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Running", false);
        anim.SetBool("Jumping", true);


    }
    private bool isGrounded()
    {
        float extraHeight = .3f;

        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeight, plataformLayerMask);
        Color raycastColor;

        if(raycastHit.collider != null)
        {
            raycastColor = Color.green;
        }
        else
        {
            raycastColor = Color.red;
        }

        Debug.DrawRay(boxCollider2d.bounds.center, Vector2.down * (boxCollider2d.bounds.extents.y + extraHeight), raycastColor);

        return raycastHit.collider != null;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage taken");
    }
}
