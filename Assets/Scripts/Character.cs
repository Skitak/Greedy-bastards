using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : BaseEntity
{
    public Weapon weapon;

    public void UseWeapon() {
        weapon.tryUse(this.orientation);   
    }

    public void SendBag() {
        // Send the bag
    }
}
