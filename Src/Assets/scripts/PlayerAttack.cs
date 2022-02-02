using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    // Start is called before the first frame update
    bool isAttacking = false;

    // Update is called once per frame
    // todo animation queue?
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl)) {
            isAttacking = true;
        }
        animator.SetBool("isAttacking", isAttacking);
        isAttacking = false;
    }
}
