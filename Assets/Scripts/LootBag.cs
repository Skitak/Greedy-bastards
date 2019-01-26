﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public static LootBag instance;
    public int totalLoot;
    public float throwForce = 10f;
    Rigidbody rigid;
    public SpriteRenderer spriteRenderer;
    bool grabbed = false;
    ArrayList potentialOwners = new ArrayList();
    GameObject owner;
    Collider collider;
    // public GameObject owner;
    // Timer timerTmpCatch = new Timer(0.5f, delegate(){
    //     owner = null;
    // });
    private void Start() {
        rigid = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        instance = this;
    }
    public float GetSlowPercentage (){
        return  15f * Mathf.Log( (5f * totalLoot) + 1f );
    }

    public void Throw (Vector2 direction) {
        transform.localPosition = Vector3.up;
        collider.enabled = true;
        spriteRenderer.enabled = true;
        transform.parent = null;
        potentialOwners.Remove(owner);
        owner = null;
        grabbed = false;
        Vector3 directionNormalized = new Vector3(direction.x, 0, direction.y).normalized;
        rigid.velocity = directionNormalized * throwForce;
    }

    public bool TryGrab(GameObject owner){
        if (!grabbed){
            grabbed = true;
            spriteRenderer.enabled = false;

            transform.parent = owner.transform;
            transform.localPosition = Vector3.up;
            rigid.velocity = Vector3.zero;
            this.owner = owner;
            foreach (GameObject nonOwner in potentialOwners) {
                if (nonOwner != owner)
                    nonOwner.GetComponent<BaseEntity>().LootBagOutOfRange();
            }
            potentialOwners.Clear();
            collider.enabled = false;
            return true;
        }
        return false;

    }

    public void FillBag (int value) {
        totalLoot += value;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && !potentialOwners.Contains(other.gameObject)){
            potentialOwners.Add(other.gameObject);
            other.gameObject.GetComponent<BaseEntity>().LootBagInRange(this);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player" && potentialOwners.Contains(other.gameObject)){
            other.gameObject.GetComponent<BaseEntity>().LootBagOutOfRange();
            potentialOwners.Remove(other.gameObject);
        }
    }
}