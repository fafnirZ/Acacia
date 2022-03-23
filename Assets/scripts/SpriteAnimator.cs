using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator
{
    SpriteRenderer spriteRenderer;

    List<Sprite> frames;
    float frameRate;
    public int currentFrame;
    float timer;
    bool looping;
    bool isPlaying = true;

    public SpriteAnimator(List<Sprite> frames, bool looping, SpriteRenderer spriteRenderer, float frameRate=0.16f)
    {
        this.frames = frames;
        this.looping = looping;
        this.spriteRenderer = spriteRenderer;
        this.frameRate = frameRate;
    }

    public void Start()
    {
        currentFrame = 0;
        timer = 0f;
        spriteRenderer.sprite = frames[0];
    }

    public void HandleUpdate()
    {
        if(!isPlaying)
            return;

        timer += Time.deltaTime;
        if (timer > frameRate)
        {
            currentFrame = (currentFrame + 1) % frames.Count;
            spriteRenderer.sprite = frames[currentFrame];
            timer -= frameRate;

            if (!looping && currentFrame == frames.Count - 1){
                StopPlaying();
            }
        }
    }
    private void StopPlaying(){
        isPlaying = false;
    }

    public List<Sprite> Frames {
        get { return frames; }
    }
}
