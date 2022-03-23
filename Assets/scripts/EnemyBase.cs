using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Mob/Mob")]
public class EnemyBase : ScriptableObject
{
    [Space]
    [Header("Description")]
    public string mobName;
    [TextArea]
    public string description;

    [Space]
    [Header("Stats")]   // TODO: decide what stats enemies will have
    public int health;
    public int speed;
    public int damage;

    [Space]
    [Header("Sprites")]
    
    [Tooltip("First frame of idle sprite")]
    public Sprite defaultSprite;
    public List<Sprite> idleSprites;
    public List<Sprite> moveSprites;
    public List<Sprite> hitSprites;
    public List<Sprite> deathSprites;
    
}
