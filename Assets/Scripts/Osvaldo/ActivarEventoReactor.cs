using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarEventoReactor : MonoBehaviour
{
    public GameObject ReactorUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GeneradorDeEventos.reactorIsActive)
        {
            Movement.canMove = false;
            ReactorUI.SetActive(true);
        }
    }
}
