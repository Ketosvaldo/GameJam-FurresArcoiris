using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Teleport : MonoBehaviour
{
    public float posX; //cordenadas en X
    public float posY; //cordenadas en Y

    public GameObject transitionObject;
    public Collider2D playerStore = null;

    public float transitionTimer = 1, transitionTimerStore;
    private bool canTeleport = false;

    private void Start() {
        transitionTimerStore = transitionTimer;
    }

    private void Update(){
        if(canTeleport && transitionTimer <= 0){
            transitionTimer = transitionTimerStore;
            teleport();
        }else if(canTeleport){
            transitionTimer -= Time.deltaTime;
        }else{
            transitionTimer = transitionTimerStore;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Movement.canMove = false;
            playerStore = collision;
            canTeleport = true;
            transitionObject.SetActive(true);
        }
    }

    private void teleport(){
        playerStore.transform.position = new Vector2(posX, posY);
        Movement.canMove = true;
        canTeleport = false;
    }
}
