using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeEventos : MonoBehaviour
{
    public int eventStartTimeFirst, eventStartTimeSecond, eventStartTimeThird;

    public int bathroomProbability, reactorProbability, simonProbability;

    static public float bathroomTimer, reactorTimer, simonTimer;

    public static bool bathroomIsActive, reactorIsActive, simonIsActive;

    public float bathroomDelay, reactorDelay, simonDelay;

    public GameObject bathroomAlert, reactorAlert, simonAlert;

    public float bathroomDmgTimer, reactorDmgTimer, simonDmgTimer;
    private float bathroomDmgTimerStore, reactorDmgTimerStore, simonDmgTimerStore;

    [SerializeField] bool isTutorial;

    HealthBar healthBar;

    void Start()
    {
        Application.targetFrameRate = 60;
        bathroomDmgTimerStore = bathroomDmgTimer;
        reactorDmgTimerStore = reactorDmgTimer;
        simonDmgTimerStore = simonDmgTimer;

        if (!isTutorial)
        {
            int randomValue = Random.Range(0, 2);

            if (randomValue == 0)
            {
                bathroomTimer = eventStartTimeFirst;
                reactorTimer = eventStartTimeSecond;
                simonTimer = eventStartTimeThird;
            }
            else if (randomValue == 1)
            {
                bathroomTimer = eventStartTimeThird;
                reactorTimer = eventStartTimeFirst;
                simonTimer = eventStartTimeSecond;
            }
            else
            {
                bathroomTimer = eventStartTimeSecond;
                reactorTimer = eventStartTimeThird;
                simonTimer = eventStartTimeFirst;
            }
        }
        healthBar = FindObjectOfType<HealthBar>();
    }

    void Update()
    {
        if (!isTutorial)
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
                    bathroomDmgTimer = bathroomDmgTimerStore;
                    bathroomAlert.SetActive(true);
                }
                else
                    bathroomTimer += 1;
            }
            else
            {
                bathroomDmgTimer -= Time.deltaTime;
                if (bathroomDmgTimer <= 0)
                {
                    healthBar.damageDrain();
                }
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
                    reactorDmgTimer = reactorDmgTimerStore;
                    reactorAlert.SetActive(true);
                }
                else
                    reactorTimer += 1;
            }
            else
            {
                reactorDmgTimer -= Time.deltaTime;
                if (reactorDmgTimer <= 0)
                {
                    healthBar.damageDrain();
                }
            }

            if (!simonIsActive && simonTimer > 0)
            {
                simonTimer -= Time.deltaTime;
                simonAlert.SetActive(false);
            }
            else if (!simonIsActive)
            {
                int randomValue = Random.Range(0, 100);
                if (randomValue <= simonProbability)
                {
                    simonIsActive = true;
                    simonDmgTimer = simonDmgTimerStore;
                    simonAlert.SetActive(true);
                }
                else
                    simonTimer += 1;
            }
            else
            {
                simonDmgTimer -= Time.deltaTime;
                if (simonDmgTimer <= 0)
                    healthBar.damageDrain();
            }
        }
    }
}
