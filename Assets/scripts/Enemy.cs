using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    public float startHealth = 100f;
    private float health;
    void Start()
    {
        animator = GetComponent<Animator>();
        health = startHealth;
    }
    public void TakeDamage(float amount){
        health -= amount;
        StartCoroutine(HitAnim());
    }
    IEnumerator HitAnim(){
        animator.SetBool("hit", true);
        yield return new WaitForSeconds(0.5f);

        if (health <= 0){
            animator.SetBool("dead", true);
            StartCoroutine(Die());
        }
        else
            animator.SetBool("hit",false);
    }
    IEnumerator Die(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
