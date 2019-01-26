using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTestSliders : MonoBehaviour
{

    public float maxLife = 15f;

    public Slider slider1; //Rouge
    public Slider slider2; //Jaune
    public Slider slider3; //Vert

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
   
    void Start()
    {
        /*
        life = maxLife;
        life1 = life2 = life3 = tier =  life / 3;

        slider1.maxValue = life1;
        slider1.value = life1;

        slider2.maxValue = life2;
        slider2.value = life2;

        slider3.maxValue = life3;
        slider3.value = life3;

        oldLife = maxLife;*/

        controllerName = charaController.GetControllerName();
        playerNumber = GameManager.GetPlayerNumberFromController (controllerName);

        print ("Player Number" + playerNumber);
        positionGo.transform.position += new Vector3 (0,( playerNumber - 1 ) * offset,0);
    }

    void Update()
    { 
        print ("Player Number" + playerNumber);
        slider1.value = slider2.value = slider3.value = (life / maxLife) * 100;
        
        if ((life/maxLife) * 100 < 33f)
            backgroundDanger.SetActive (true);
        else 
            backgroundDanger.SetActive (false);
        

        
        
        
        
        
        
        
        
        
        /*
        // 3 puis 2 puis 1 // 
        if (life > 2 * tier && oldLife != life && life3 > 0)
        {
            float temp;
            temp = life - oldLife;
            life3 += temp;
            if (life <= tier * 3 && life > tier * 2)
                slider3.value += temp;
            temp = 0;  
        }

        if (life > 1 * tier && oldLife != life && life2 > 0 && life <= 2 * tier)
        {
            backgroundDanger.SetActive(false);
            float temp;
            temp = life - oldLife;
            life2 += temp;
            if (life <= tier * 2 && life > tier * 1)
            {
                //DO NOT WORK WITHOUT THE PRINTS
                print ("I lie to you");
                print (tier * 2);
                print (life);
                slider2.value += temp;
            }
            temp = 0;  
        }

        if (life <= 1 * tier && oldLife != life)
        {
            backgroundDanger.SetActive (true);
            float temp;
            temp = life - oldLife;
            life1 += temp;
            if (life <= (maxLife / 3) * 1)
                slider1.value += temp;
            temp = 0;  
        }




        //Last Check
        oldLife = life;*/
    }
}
