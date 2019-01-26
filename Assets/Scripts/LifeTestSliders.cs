using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTestSliders : MonoBehaviour
{
    bool offseted = false;
    public float maxLife = 15f;

    public Slider slider;

    public GameObject backgroundDanger;

    public float life;

    float life1;
    float life2;
    float life3;

    float tier;
    float oldLife;
    float temp;

    public CharaController charaController;

    string controllerName;

    public GameObject positionGo;

    private int playerNumber;

    public float offset;

    // New 

    public Image fill;
    public Image BackGround;
    public Sprite SpriteBackGround;
    public Sprite SpriteBackGroundLow;

    public Sprite SpriteBackGroundDead;

   
    void Start()
    {
        life = maxLife;
        
    }

    void Update()
    { 
            if (charaController.GetControllerName() != "none" && !offseted)
        {
            playerNumber = GameManager.GetPlayerNumberFromController(charaController.GetControllerName());
            print (playerNumber);
            positionGo.transform.position += new Vector3 (0, - offset * (playerNumber - 1),0);
            offseted = true;

        }
     
        
        slider.value = (life/maxLife);

        
        //ROUGE
        if ((life/maxLife) < 0.33f && (life/maxLife) >0)
        {
            // BackGround Danger
            backgroundDanger.SetActive (true);

            fill.color = new Color (255,0,0);
            BackGround.sprite = SpriteBackGroundLow;

        }
        else 
        {
            BackGround.sprite = SpriteBackGround;
            backgroundDanger.SetActive (false);
        }
        //JAUNE
        if ((life/maxLife) >= 0.33f && (life/maxLife) < 0.66f)
        {
           fill.color = new Color (255,255,0);
        }
        //VERT
        if ((life/maxLife) >= 0.66f)
        {
           fill.color = new Color (0,255,0);
        }

        //DEAD
        if ((life/maxLife) <= 0)
        {
            BackGround.sprite = SpriteBackGroundDead;
        }
    }
}
