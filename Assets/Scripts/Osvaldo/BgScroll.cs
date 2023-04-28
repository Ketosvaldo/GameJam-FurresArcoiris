using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    Material mat;
    private float xScroll;
    private float yScroll;

    private void Awake()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        xScroll = Time.time * scrollSpeed;
        yScroll = Time.time * scrollSpeed;
        Vector2 _offset = new Vector2(xScroll, yScroll);
        mat.mainTextureOffset = _offset;
    }
}