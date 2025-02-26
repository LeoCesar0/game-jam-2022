using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
 {
 
     public float enemyCooldown = 1;
     public float damage = 1;
 
     public bool playerInRange = false;
     private bool canAttack = true;
     private Animator animator;
     

     private void Start() {
        animator = GetComponent<Animator>();
     }
 
    private void Update()
     {
         if (playerInRange && canAttack)
         {
             animator.SetBool("canAttack", true);
             //GameObject.Find("Fall_0").GetComponent<PC>().currentHealth -= damage;
             StartCoroutine(AttackCooldown());
         }
     }

     void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player")
          {
            
             playerInRange = true;
         }
     }

       void OnCollisionExit2D(Collision2D collision) {

        if (collision.gameObject.tag == "Player")
          {
             animator.SetBool("canAttack", false);
             animator.SetBool("canWalk", true);
             playerInRange = false;
         }
     }


     IEnumerator AttackCooldown()
     {
         canAttack = false;
         yield return new WaitForSeconds(enemyCooldown);
         canAttack = true;
     }
 }