using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    // Sprite lists
    public List<Sprite> idleSprites;
    public List<Sprite> moveSprites;
    public List<Sprite> hitSprites;
    public List<Sprite> deathSprites;

    // Animation Parameters 
    public float speed;
    public bool isHit;
    public bool isDead;
    
    SpriteAnimator currentAnim;

    // States
    SpriteAnimator idleAnim;
    SpriteAnimator moveAnim;
    SpriteAnimator hitAnim;
    SpriteAnimator deathAnim;

    // References;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        idleAnim = new SpriteAnimator(idleSprites, true, spriteRenderer);
        moveAnim = new SpriteAnimator(moveSprites, true, spriteRenderer);
        hitAnim = new SpriteAnimator(hitSprites, true, spriteRenderer);
        deathAnim = new SpriteAnimator(deathSprites, false, spriteRenderer);

        currentAnim = idleAnim;
    }
    private void Update()
    {
        var prevAnim = currentAnim;

        // TODO: make better/cleaner
        if (!isDead){
            if (!isHit){
                if (speed == 0)
                currentAnim = idleAnim;

                if (speed != 0)
                currentAnim = moveAnim;
            }
            else
                currentAnim = hitAnim;
        }
        else 
            currentAnim = deathAnim;

        

        currentAnim.HandleUpdate();
    }
}
