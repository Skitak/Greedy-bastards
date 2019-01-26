using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEntity : MonoBehaviour {
    public int maxHealth = 10;
    public float speed;
    public Rigidbody rigid;
    public Sprite spriteBack, spriteFront;
    public SpriteRenderer spriteRenderer;
    protected Vector2 orientation;
    protected LootBag lootBag;
    protected bool hasLootBag;
    protected bool isDead = false;

    private int health;

    private void Start() {
        health = maxHealth;
    }

    public int Health {
        get { return health;}
        set {
            health = value; 
            if (value <= 0)
                Die();
        }
    }

    public virtual void Move(Vector2 direction) {
        if (GameManager.instance.isGamePaused)
            return;
        float modifiedSpeed = speed * (hasLootBag ? (1f - (lootBag.GetSlowPercentage() / 100f)) : 1);
        rigid.velocity = new Vector3 (direction.x, 0, direction.y) * modifiedSpeed;
        ChangeSpriteOrientation();
    }

    public virtual void Orientate(Vector2 orientation) {
        this.orientation = orientation;

    }

    void ChangeSpriteOrientation() {
        spriteRenderer.flipX = orientation.x > 0;
        spriteRenderer.sprite = orientation.y > 0 ? spriteBack : spriteFront;
    }

    protected virtual void Die() {
        ThrowLootBag(Vector2.zero);
        isDead = true;
    }

    public virtual void Hit(int damages){
        Health -= damages;
        //Activate animation
    }

    public void TryGrabBag(){
        if (lootBag != null)
            hasLootBag = lootBag.TryGrab(this.gameObject);
        if (hasLootBag)
            LootBagGrabbed();
    }

    public void ThrowLootBag(Vector2 orientation){
        if (hasLootBag){
            hasLootBag = false;
            lootBag.Throw(orientation);
        }
    }

    public void LootBagInRange(LootBag lootBag){
        this.lootBag = lootBag;
    }

    public void LootBagOutOfRange(){
        lootBag = null;
    }

    public bool HasLootBag(){
        return hasLootBag;
    }

    public bool IsDead () {
        return isDead;
    }
    
    protected virtual void LootBagGrabbed() {
        
    }
}