using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : BaseEntity
{
    public int maxLootCapacity = 5;
    [HideInInspector]
    public int treasuresLooted;
    public Weapon weapon;

    public void UseWeapon() {
        weapon.tryUse(this.orientation);   
    }

    public void SendBag() {
        // Send the bag
    }

    public void OnLootCollide(Loot loot){
        if (treasuresLooted >= maxLootCapacity )
        return;
        int treasure = (int)Mathf.Min ( maxLootCapacity - treasuresLooted, loot.value);
        // Now do things with that treasure value, like UI Things
        treasuresLooted += treasure;
        Debug.Log("Looted " + treasure);
        loot.OnLootCollected();
    }

    public void Reset(){}
}
