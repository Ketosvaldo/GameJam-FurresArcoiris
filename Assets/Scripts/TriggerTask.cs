using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTask : MonoBehaviour
{
    public GameObject bathroomUI;

    private void Start() {
        bathroomUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && GeneradorDeEventos.bathroomIsActive)
        {
            bathroomUI.SetActive(true);
            Movement.canMove = false;
        }
    }
}
