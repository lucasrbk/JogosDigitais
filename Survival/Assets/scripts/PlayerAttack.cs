using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    private float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask isEnemies;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }











}
