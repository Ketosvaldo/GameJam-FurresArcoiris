using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MissionActive : MonoBehaviour
{
    public GameObject mision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
            mision.SetActive(true);
        }
    }

}
