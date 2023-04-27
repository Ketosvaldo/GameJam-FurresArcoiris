using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables de movimiento:
    float horizontalMove;
    float verticalMove;
    public float speed;
    public Rigidbody2D rb;
    private Vector2 direction;

    //Variables de animación:
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        CharacterAnimation();
    }

    private void FixedUpdate()
    {
        CharacterMovement();
    }

    void ProcessInputs()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        //Cambiar la dirección del movimiento en X y Y:
        direction = new Vector2(horizontalMove, verticalMove).normalized;

    }
    void CharacterMovement()
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);

    }

    void CharacterAnimation()
    {
        //En animator, con los ESTADOS "CorrerDerecha" y "CorrerIzquierda"
        //con transiciones de ida y vuelta al estado de "Idle".

        //En animator, trabaja con los PARAMETROS booleanos
        //"correrDerecha" y "correrIzquierda". 
        //Solo cambia la primera letra a minúscula.

        //Añadir condiciones en las transiciones
        //Las condiciones son: 
        // De idle a correrDerecha = correrDerecha -- true
        // De correrDerecha a idle = correrDerecha -- false
        // De idle a correrIzquierda = correrIzquierda -- true
        // De correrIzquierda a idle = correrIzquierda -- false

        //Condiciones para cambiar el estado de los parametros booleanos : 
        if (horizontalMove > 0)
        {
            if(verticalMove > 0 || verticalMove < 0)
            {
                animator.SetBool("runRight", true);
            }
            else
            {
                animator.SetBool("runRight", true);
            }
            
        }
        else
        {
            animator.SetBool("runRight", false);
        }

        if (horizontalMove < 0)
        {
            if(verticalMove > 0 || verticalMove < 0)
            {
                animator.SetBool("runLeft", true);
            }
            else
            {
                animator.SetBool("runLeft", true);
            }
            
        }
        else
        {
            animator.SetBool("runLeft", false);
        }
        //-----------------------------------------------
        /*if (movimientoVertical > 0)
        {
            if(movimientoHorizontal > 0)
            {
                animator.SetBool("correrDerecha", true);
            }
            else
            {

                animator.SetBool("correrDerecha", false);
            }
        }
        if (movimientoVertical < 0)
        {
            if (movimientoHorizontal < 0)
            {
                animator.SetBool("correrDerecha", true);
            }
            else
            {

                animator.SetBool("correrDerecha", false);
            }
        }*/


    }
}
