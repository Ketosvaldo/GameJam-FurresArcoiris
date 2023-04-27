using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Teleport : MonoBehaviour
{
    public float posX; //cordenadas en X
    public float posY; //cordenadas en Y

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("interact");
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            collision.transform.position = new Vector2(posX, posY);
            Debug.Log("kaycode");
        }
    }
}
