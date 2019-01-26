using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUpdater : MonoBehaviour
{
  
    public Character chara;
    public Text textLoot;
    public GameObject lootLimitMaxGo;

    void Start()
    {
        
    }

    void Update()
    {
        if (chara.maxLootCapacity <= chara.treasuresLooted)
        {
            lootLimitMaxGo.SetActive (true);
        }
        else 
        {
            lootLimitMaxGo.SetActive (false);
        }
        textLoot.text = chara.treasuresLooted.ToString();
    }
}
