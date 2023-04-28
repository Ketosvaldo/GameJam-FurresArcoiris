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

    SFX_Controller sfx;
    MusicController musicController;

    public float transitionTimer = 4.5f, transitionTimerStore;

    public static bool bathroomIsPlaying;

    private void Start() {
        transitionTimerStore = transitionTimer;
        sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<SFX_Controller>();
        musicController = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>();
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
                sfx.PlayAudio(0);
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
        musicController.PlayAudio(1);
        camera.transform.position = cameraTarget.transform.position;
    }
}
