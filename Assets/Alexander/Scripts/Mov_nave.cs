using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_nave : MonoBehaviour
{
    public float movForce;
    public float posXDestroy;
    public bool lefth;


    private void Update()
    {
        MovSpaceShip();

        if (lefth && transform.position.x <= posXDestroy)
        {
            Destroy();
        }
        if (!lefth && transform.position.x >= posXDestroy)
        {
            Destroy();
        }
    }

    private void MovSpaceShip()
    {
        transform.position = new Vector2(transform.position.x + movForce * Time.deltaTime, transform.position.y);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
