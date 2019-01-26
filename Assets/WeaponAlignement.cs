using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAlignement : MonoBehaviour
{

    public Character chara;
    public CharaController control;
    
    public GameObject weapon;

    private Vector2 myOrientation;

    void Start()
    {
        
    }


    void Update()
    {
        /*if (control.controllerName == "keyboard")
            orientation = getKeyboardOrientation();
        else
            orientation = new Vector2(Input.GetAxis(horizontal2), Input.GetAxis(vertical2));*/

        //weapon.transform.Rotate ((Vector2)control.orientation);

        //weapon.transform.position.Vector3.right = orientation;
        /*
        myOrientation = chara.GetOrientation ();
        weapon.transform.Rotate ((Vector2) myOrientation);*/

        
    }
}
