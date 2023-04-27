using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeEventos : MonoBehaviour
{
    public int eventStartTime1, eventStartTime2, eventStartTime3;

    private float countTime1, countTime2, countTime3;

    public bool eventIsActive1, eventIsActive2, eventIsActive3;

    Reactor_Focos lightsStatus;

    void Start()
    {
        lightsStatus = FindObjectOfType<Reactor_Focos>();

    }

    void Update()
    {
        
    }

    static void MisionReactorStatus()
    {
        
    }
}
