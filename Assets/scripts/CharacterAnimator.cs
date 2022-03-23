using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] List<Sprite> idleSprites;
    [SerializeField] List<Sprite> walkSprites;
    [SerializeField] List<Sprite> jumpSprites;

    SpriteAnimator currentAnim;

    // Parameters 
    public float speed;
    public bool isJumping;

    // States
    SpriteAnimator idleAnim;
    SpriteAnimator walkAnim;
    SpriteAnimator jumpAnim;

    // References;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        idleAnim = new SpriteAnimator(idleSprites, true, spriteRenderer);
        walkAnim = new SpriteAnimator(walkSprites, true, spriteRenderer);
        jumpAnim = new SpriteAnimator(jumpSprites, true, spriteRenderer);

        currentAnim = idleAnim;
    }
    private void Update()
    {
        var prevAnim = currentAnim;

        if (isJumping)
            currentAnim = jumpAnim;
        else if (!isJumping)
            if (speed > 0 )
            currentAnim = walkAnim;
            else if (speed == 0)
            currentAnim = idleAnim;

        if (currentAnim != prevAnim)
            currentAnim.Start();

        currentAnim.HandleUpdate();
    }
}
