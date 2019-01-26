using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEntity {

    public GameObject loot;
    public int lootValue = 100;

    protected override void Die(){
        (Instantiate(loot, transform.position, Quaternion.identity) as GameObject).GetComponent<Loot>().value = lootValue;
        Destroy(this.gameObject);
    }
}
