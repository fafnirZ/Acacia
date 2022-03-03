using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;

    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    void Awake(){
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        playerRB.velocity = new Vector2(dirX * moveSpeed, playerRB.velocity.y);

        if (Input.GetButtonDown("Jump")){
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("jumping", true);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation(){
        if (dirX < 0f){
            anim.SetBool("walking", true);
            sprite.flipX = false;
        }
        else if (dirX > 0f){
            anim.SetBool("walking", true);
            sprite.flipX = true;
        }
        else{
            anim.SetBool("walking", false);
        }
    }
}
