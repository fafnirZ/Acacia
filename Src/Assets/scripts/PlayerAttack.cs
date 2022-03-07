using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public KeyCode attack1;
    bool isAttacking = false;

    private float attackTimer;
    public float timeBetweenAttack;
    public float damage = 50f;  
    [Header("HitBox")]
    public Transform attackPos;
    public float attackRange;

    // todo animation queue?
    void Update(){
        if(attackTimer <= 0){
            if(Input.GetKeyDown(attack1)) {
                attackTimer = timeBetweenAttack;
                isAttacking = true;
                CheckHitBox();
            }
        } else{
            attackTimer -= Time.deltaTime;
        }
        animator.SetBool("isAttacking", isAttacking);
        isAttacking = false;

    }
    void CheckHitBox(){
        Collider2D[] hitbox = Physics2D.OverlapCircleAll(attackPos.position, attackRange);
            foreach (Collider2D collider in hitbox){
                if (collider.tag == "Enemy"){
                    Damage(collider.transform);
                }
            }
    }
    void Damage(Transform enemy){
        Enemy e = enemy.GetComponent<Enemy>();

        e.TakeDamage(damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
