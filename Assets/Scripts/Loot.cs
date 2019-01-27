using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public int value;
    public float despawnTime = 5f;
    Timer timer;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<Character>().OnLootCollide(this);
        
    }

    public void OnLootCollected(){
        Destroy(this.gameObject);
    }

    void Start ()
    {
        timer = new Timer (despawnTime, delegate () {Destroy(this.gameObject);});
        timer.Play();
    }

}
