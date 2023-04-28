using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomTrigger : MonoBehaviour
{
    public GameObject transitionObject;
    public GameObject camera;
    public GameObject cameraTarget;
    public GameObject InteractableIconPlayer;
    public GameObject cheetaBathroomAnim;
    public GameObject bathroomUI;

    public float transitionTimer = 4.5f, transitionTimerStore;

    public static bool bathroomIsPlaying;

    private void Start() {
        transitionTimerStore = transitionTimer;
    }

    private void Update(){
        if(transitionTimer <= 2.6){
            teleport();
            cheetaBathroomAnim.SetActive(true);
        }
        if(transitionTimer <= 0.0){
            bathroomUI.SetActive(true);
            bathroomIsPlaying = false;
            transitionTimer = transitionTimerStore;
        }else if(transitionTimer > 0.0 && bathroomIsPlaying){
            transitionTimer -= Time.deltaTime;
        }else{
            transitionTimer = transitionTimerStore;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GeneradorDeEventos.bathroomIsActive)
        {
            InteractableIconPlayer.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                bathroomIsPlaying = true;
                transitionObject.SetActive(true);
                transitionTimer = transitionTimerStore;
                Movement.canMove = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InteractableIconPlayer.SetActive(false);
        }
    }

    private void teleport(){
        camera.transform.position = cameraTarget.transform.position;
    }
}
