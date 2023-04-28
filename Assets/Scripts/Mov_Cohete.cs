using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mov_Cohete : MonoBehaviour
{
    public float movSpeed;
    public float moveSpeedY;
    public bool left;
    public Image UIThirdCredits;
    public bool isUI;
    bool moveUI;

    private void Start()
    {
        if (isUI)
            Invoke("SetMoveUI", 66);
    }
    private void Update()
    {
        if (!isUI)
        {
            MoveSpaceShip();
            if (left && transform.position.x <= -30.0f)
            {
                Destroy(gameObject);
            }
            if (!left && transform.position.x >= 30)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if(moveUI)
                MoveUI();
        }
            
    }

    private void MoveSpaceShip()
    {
        transform.position = new Vector2(transform.position.x +  movSpeed * Time.deltaTime, transform.position.y);
    } 

    private void MoveUI()
    {
        UIThirdCredits.rectTransform.localPosition = new Vector2(UIThirdCredits.rectTransform.localPosition.x, UIThirdCredits.rectTransform.localPosition.y + moveSpeedY * Time.deltaTime);
    }

    void SetMoveUI()
    {
        moveUI = true;
    }
}
