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

    public GameObject newSprites;

    protected Vector2 orientation;
    protected LootBag lootBag;
    protected bool hasLootBag;
    protected bool isDead = false;

    private int health;
    public Animator animator;

    public AudioSource source;
    

    protected virtual void Start() {
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
        animator.SetFloat("Speed", direction.magnitude);
        float modifiedSpeed = speed * (hasLootBag ? (1f - (lootBag.GetSlowPercentage() / 100f)) : 1);
        rigid.velocity = new Vector3 (direction.x, 0, direction.y) * modifiedSpeed;

        if (source.clip != null && rigid.velocity.magnitude > 3f)
        {
            source.Play ();
            source.loop = true;
        }  
        else
        {
            source.loop = false;
            source.Stop();
        }

        
    }

    public virtual void Orientate(Vector2 orientation) {
        
        animator.SetFloat("OrientationY", orientation.y);
        this.orientation = orientation;
        ChangeSpriteOrientation();

    }

    void ChangeSpriteOrientation() {
        /*spriteRenderer.flipX = orientation.x > 0;
        spriteRenderer.sprite = orientation.y > 0 ? spriteBack : spriteFront;*/

        if (newSprites.transform.localScale.x > 0 && orientation.x < 0){
            SwapSprite();
        }
        else if (newSprites.transform.localScale.x  < 0 && orientation.x > 0){
            SwapSprite();
        }
    }

    protected virtual void Die() {
        ThrowLootBag(Vector2.zero);
        isDead = true;
        animator.SetBool("Dead", true);
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

    public virtual void LootBagInRange(LootBag lootBag){
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

    public Vector2 GetOrientation ()
    {
        return orientation;
    }

    private void WeaponOrientation (GameObject weaponHolder)
    {
        
    }

    void SwapSprite(){
        float xSprite = -newSprites.transform.localScale.x;
        float ySprite = newSprites.transform.localScale.y;
        float zSprite = newSprites.transform.localScale.z;
        newSprites.transform.localScale = new Vector3(xSprite, ySprite, zSprite);
    }
}