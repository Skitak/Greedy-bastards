using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<Character>().StoreAllLoot();
    }
}
