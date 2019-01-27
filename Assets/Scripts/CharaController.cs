using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    Character character;
    string controllerName = "none";

    string horizontal, vertical, horizontal2, vertical2, fire, sendBag;
    Vector2 direction, orientation;
    //Use to check if player released fire input before firing again.
    bool fired = false;
    void Start(){
        character = gameObject.GetComponent<Character>();
    }

    void Update(){
        
        if (controllerName == "none" || GameManager.instance.isGamePaused )
            return;
         direction = new Vector2(Input.GetAxis(horizontal), Input.GetAxis(vertical));
        if (controllerName == "keyboard")
            orientation = getKeyboardOrientation();
        else
            orientation = new Vector2(Input.GetAxis(horizontal2), Input.GetAxis(vertical2));
        character.Move(direction);
        character.Orientate(orientation);
        if (CheckFire())
            character.UseWeapon();
        if (Input.GetButtonDown(sendBag)){
            if (character.HasLootBag())
                character.ThrowLootBag(orientation);
            else
                character.TryGrabBag();
        }
    }

    public void SetController(string name){
        controllerName = name;
        horizontal = "Horizontal1 " + name;
        vertical = "Vertical1 " + name;
        horizontal2 = "Horizontal2 " + name;
        vertical2 = "Vertical2 " + name;
        fire = "Use Weapon " + name;
        sendBag = "Throw " + name;
    }

    public string GetControllerName ()
    {
        return controllerName;
    }

    Vector2 getKeyboardOrientation(){
        Vector3 CharacterPosition = Camera.main.WorldToScreenPoint(character.gameObject.transform.position);
        return Input.mousePosition - CharacterPosition;
    }

    bool CheckFire(){
        if(controllerName == "keyboard")
            return Input.GetButton(fire);
            /*
        if (fired && Input.GetAxis(fire) < 0.5)
            return fired = false;
        else if (!fired && Input.GetAxis(fire) > 0.5){
            fired = true;
            return true;*/
        else if (Input.GetAxis(fire) > 0.5f)
        {
            return true;
        } else
        return false;
    }

}
