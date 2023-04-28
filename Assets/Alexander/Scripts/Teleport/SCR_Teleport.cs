using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Teleport : MonoBehaviour
{
    public float posX; //cordenadas en X
    public float posY; //cordenadas en Y
    public GameObject InteractableIconPlayer;

    public GameObject transitionObject;
    public Collider2D playerStore = null;

    // Movimiento de la camara
    public GameObject camera;
    public GameObject cameraTarget;

    public float transitionTimer = 1, transitionTimerStore;
    private bool canTeleport = false;

    private void Start() {
        transitionTimerStore = transitionTimer;
    }

    private void Update(){
        if(canTeleport && transitionTimer <= 0){
            transitionTimer = transitionTimerStore;
            teleport();
        }else if(canTeleport && transitionTimer > 0){
            transitionTimer -= Time.deltaTime;
        }else{
            transitionTimer = transitionTimerStore;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InteractableIconPlayer.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                transitionObject.SetActive(true);
                playerStore = collision;
                canTeleport = true;
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
        playerStore.transform.position = new Vector2(posX, posY);
        camera.transform.position = cameraTarget.transform.position;
        //Movement.canMove = true;
        canTeleport = false;
    }
}
