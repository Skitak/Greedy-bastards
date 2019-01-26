using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        
    }

    
    void Update()
    {
        this.gameObject.transform.LookAt(target);
        
    }

    void LateUpdate ()
    {
        //this.gameObject.transform.rotation += new Vector3 (0,90,0);
        this.gameObject.transform.Rotate (new Vector3 (0,-90,20));
    }
}
