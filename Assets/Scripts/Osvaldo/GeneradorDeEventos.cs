using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeEventos : MonoBehaviour
{
    public int eventStartTimeFirst, eventStartTimeSecond, eventStartTimeThird;

    public int bathroomProbability, reactorProbability;

    static public float bathroomTimer, reactorTimer, simonTimer;

    public static bool bathroomIsActive, reactorIsActive, simonIsActive;

    public float bathroomDelay, reactorDelay;

    public GameObject bathroomAlert, reactorAlert, simonAlert;

    void Start()
    {
        int randomValue = Random.Range(0, 2);
        if(randomValue == 0)
        {
            bathroomTimer = eventStartTimeFirst;
            reactorTimer = eventStartTimeSecond;
        }
        else
        {
            bathroomTimer = eventStartTimeSecond;
            reactorTimer = eventStartTimeFirst;
        }
    }

    void Update()
    {
        if (!bathroomIsActive && bathroomTimer > 0)
        {
            bathroomTimer -= Time.deltaTime;
            bathroomAlert.SetActive(false);
        }    
        else if (!bathroomIsActive)
        {
            int randomValue = Random.Range(0, 100);
            if (randomValue <= bathroomProbability)
            {
                bathroomIsActive = true;
                bathroomAlert.SetActive(true);
            }    
            else
                bathroomTimer += 1;
        }

        if (!reactorIsActive && reactorTimer > 0)
        {
            reactorTimer -= Time.deltaTime;
            reactorAlert.SetActive(false);
        }    
        else if (!reactorIsActive)
        {
            int randomValue = Random.Range(0, 100);
            if (randomValue <= reactorProbability)
            {
                reactorIsActive = true;
                reactorAlert.SetActive(true);
            }  
            else
                reactorTimer += 1;
        }
    }
}
