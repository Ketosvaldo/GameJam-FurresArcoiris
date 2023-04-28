using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Teleport : MonoBehaviour
{
    public float posX; //cordenadas en X
    public float posY; //cordenadas en Y
    public GameObject InteractableIconPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InteractableIconPlayer.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
                collision.transform.position = new Vector2(posX, posY);
            Debug.Log("kaycode");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InteractableIconPlayer.SetActive(false);
            Debug.Log("kaycode");
        }
    }
}
