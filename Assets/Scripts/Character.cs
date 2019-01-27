using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : BaseEntity
{
    public int maxLootCapacity = 5;
    [HideInInspector]
    public int treasuresLooted;
    public Weapon weapon;
    public CharaController controller;

    public void UseWeapon() {
        weapon.tryUse(this.orientation);   
    }

    public void OnLootCollide(Loot loot){
        if (treasuresLooted >= maxLootCapacity )
        return;
        int treasure = (int)Mathf.Min ( maxLootCapacity - treasuresLooted, loot.value);
        // Now do things with that treasure value, like UI Things
        treasuresLooted += treasure;
        loot.OnLootCollected();
    }

    protected override void Die() {
        base.Die();
        ThrowLootBag(Vector2.zero);
    }

    public void Reset(){
        Vector3 spawnPosition = GameManager.GetSpawnLocationFromController(controller.GetControllerName());
        transform.position = spawnPosition;
    }

    public void StoreAllLoot(){
        if (hasLootBag)
            lootBag.StoreAllLoot();
        GameManager.instance.GlobalLoot += treasuresLooted;
        treasuresLooted = 0;
    }

    protected override void LootBagGrabbed(){
        lootBag.FillBag(treasuresLooted);
        treasuresLooted = 0;
    }

}
