using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    EnemyAnimator animator;
    BoxCollider2D boxCollider;
    EnemyBase _base;
    public string mobName;
    public int health;
    public void LoadData(EnemyBase enemyBase){
        _base = enemyBase;
    }
    
    void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<EnemyAnimator>();
        SetData();
    }
    private void SetData(){
        spriteRenderer.sprite = _base.defaultSprite;
        mobName = _base.mobName;
        health = _base.health;
        animator.idleSprites = _base.idleSprites;    
        animator.moveSprites = _base.moveSprites;
        animator.hitSprites = _base.hitSprites;
        animator.deathSprites = _base.deathSprites;
    }
    public void TakeDamage(int amount){
        health -= amount;
        StartCoroutine(Hit());
    }
    IEnumerator Hit(){
        animator.isHit = true;
        yield return new WaitForSeconds(1);
        if (health <= 0){
            StartCoroutine(Die());
        }
        animator.isHit = false;
    }
    IEnumerator Die(){
        animator.isDead = true;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    void Update(){
        boxCollider.size = spriteRenderer.sprite.rect.size/100;
    }
}
