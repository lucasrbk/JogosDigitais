using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int speed = 5;
    public int jump = 5;
    public int health = 1;
    public int attack = 1;

    public float attackRadius;
    public float followRadius;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask plataformLayerMask;
    public bool MoveRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(5, 5);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-5, 5);

        }

        if (health <= 0)
        {
            Destroy(gameObject);
            ScoreScript.scoreValue += 1;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MoveRight)
        {
            MoveRight = false;
        }
        else
        {
            MoveRight = true;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage taken");
    }

}
