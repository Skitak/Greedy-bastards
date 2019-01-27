using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFinal : MonoBehaviour
{
    private GameManager gameManager;
    private BaseEntity baseEntity;

	private Timer timerToCenter;


    private float timeBeforeStartClosing;
    private float closingSpeed;
    private int damageOverTime;

    private float totalDistanceToTravel;
    private float actualDistanceToTravel;
    private float playersSpeed;
    private float timeToCenter;

    private int numberOfPlayers;

    private Vector3 houseWorldPosition;


    void Start()
    {
        numberOfPlayers = GameManager.GetNumberOfPlayers();

        print (gameManager.players[0]);
    }



    void PlayerPositionChecker ()
    {
        for (int i = 0; i <= numberOfPlayers; i++)
        {
            float distance = Vector3.Distance (houseWorldPosition, gameManager.players[i].transform.position);
            if (distance > actualDistanceToTravel)
            {
                //Damage gameManager.players[i]
                // Need to use a global timer for ticking ? 
                baseEntity.Hit(damageOverTime);
            }
        }
    }

    void StartTravellingTowardTheCenter(float totalDistanceToTravel, float speed)
    {
        timeToCenter = totalDistanceToTravel / speed;
        timerToCenter = new Timer (timeToCenter,Ending);
        timerToCenter.OnTimerUpdate += Closing;
        timerToCenter.Play();
    }

    void Closing ()
    {
        float timeLeft = timerToCenter.GetTimeLeft();
        actualDistanceToTravel = (totalDistanceToTravel / closingSpeed) * timeLeft;
    }

    void Ending ()
    {
        //Just arrived in the center
    }



}
