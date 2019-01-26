using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<Character>().OnLootCollide(this);
        
    }

    public void OnLootCollected(){
        Destroy(this.gameObject);
    }

}
