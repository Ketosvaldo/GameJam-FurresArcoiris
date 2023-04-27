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
        bathroomUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        bathroomUI.SetActive(false);
    }
}
