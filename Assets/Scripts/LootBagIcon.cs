using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootBagIcon : MonoBehaviour
{
    Transform followThis;
    Vector2 offset = new Vector2(0, -100);
    Image image;
    public void SetFollow(Transform followThis){
        this.followThis = followThis;
    }

    private void Start() {
        image = GetComponent<Image>();
    }

    private void Update() {
        if (followThis == null) {
            image.enabled = false;
            return;
        }
 
        image.enabled = true;
        Vector2 sp = Camera.main.WorldToScreenPoint(followThis.position);
 
        this.transform.position = sp + offset;
    }


}
