using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEventos : MonoBehaviour
{
    public GameObject[] missions;

    private void Start()
    {

        Invoke("MisionTimon", 5);
        Invoke("MisionReactor", 10);
        Invoke("MisionBaņos", 15);

    }

    private void Update()
    {
        /*if (timonCompleted)
	    {
            timonCompleted = false;
            Invoke("MisionTimon", 5);
        }*/
        /*if (reactorCompleted)
	    {
            reactorCompleted = false;
            Invoke("MisionTimon", 5);
        }*/
        /*if (baņosCompleted)
	    {
            baņosCompleted = false;
            Invoke("MisionTimon", 5);
        }*/
    }

    private void MisionTimon()
    {
        missions[0].SetActive(false);

        int tempRandom = Random.Range(1, 11);

        if (tempRandom >= 7)
        {
            //aqui se activa el objeto que marca una mision
            missions[0].SetActive(true);
        }
        else
        {
            Invoke("MisionTimon", 1);
        }

        Debug.Log("Timon");
    }
    private void MisionReactor()
    {
        missions[1].SetActive(false);

        int tempRandom = Random.Range(1, 11);

        if (tempRandom >= 7)
        {
            //aqui se activa el objeto que marca una mision
            missions[1].SetActive(true);
            Invoke("MisionReactor", 5);
        }
        else
        {
            Invoke("MisionReactor", 1);
        }

        Debug.Log("Reactor");
    }
    private void MisionBaņos()
    {
        missions[2].SetActive(false);

        int tempRandom = Random.Range(1, 11);

        if (tempRandom >= 7)
        {
            //aqui se activa el objeto que marca una mision
            missions[2].SetActive(true);
            Invoke("MisionBaņos", 5);
        }
        else
        {
            Invoke("MisionBaņos", 1);
        }

        Debug.Log("Baņos");
    }
}
