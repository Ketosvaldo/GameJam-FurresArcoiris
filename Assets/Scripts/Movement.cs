using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables de movimiento:
    float horizontalMove;
    float verticalMove;
    public float speed;
    private Rigidbody2D rb;
    public static bool canMove;
    private Vector2 direction;

    //Variables de animaci�n:
    private Animator animator;
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        canMove = true;
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

        //Cambiar la direcci�n del movimiento en X y Y:
        direction = new Vector2(horizontalMove, verticalMove).normalized;

    }
    void CharacterMovement()
    {
        if(canMove)
            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        else{
            rb.velocity = new Vector2(0,0);
        }
    }

    void CharacterAnimation()
    {
        if (canMove)
        {
            if(horizontalMove != 0 || verticalMove != 0){
                animator.SetBool("run", true);
                if(horizontalMove < 0){
                    renderer.flipX = true;
                }else if(horizontalMove > 0){
                    renderer.flipX = false;
                }
            }
            else{
                animator.SetBool("run", false);
            }
        }
        else{
            animator.SetBool("run", false);
        }
    }

}
