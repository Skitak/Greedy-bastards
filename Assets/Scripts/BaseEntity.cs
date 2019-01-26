﻿using System.Collections;
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
        rigid.velocity = new Vector3 (direction.x, 0, direction.y) * speed;
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
        Destroy(this.gameObject);
    }

    public virtual void Hit(int damages){
        Health -= damages;
        //Activate animation
    }
}