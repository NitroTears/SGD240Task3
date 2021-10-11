using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapSpriteSelector : MonoBehaviour
{
    public Sprite sprU, sprD, sprR, sprL, sprUD, sprRL, sprUR, sprUL, sprDR, sprDL, sprULD, sprRUL, sprDRU, sprLDR, sprUDRL;
    public bool up, down, left, right;
    public RoomType roomType;
    public Color normalColour, enterColour;
    Color mainColour;
    SpriteRenderer sprRenderer;

    // Start is called before the first frame update
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        normalColour.a = 1;
        mainColour = normalColour;
        mainColour.a = 1;
        PickSprite();
        PickColour();
    }

    private void PickColour()
    {
        if (roomType == RoomType.Normal)
        {
            mainColour = normalColour;
        }
        else if (roomType == RoomType.Start)
        {
            mainColour = enterColour;
        }
        sprRenderer.color = mainColour;
    }

    void PickSprite()
    { //picks correct sprite based on the four door bools
        if (up)
        {
            if (down)
            {
                if (right)
                {
                    if (left)
                    {
                        sprRenderer.sprite = sprUDRL;
                    }
                    else
                    {
                        sprRenderer.sprite = sprDRU;
                    }
                }
                else if (left)
                {
                    sprRenderer.sprite = sprULD;
                }
                else
                {
                    sprRenderer.sprite = sprUD;
                }
            }
            else
            {
                if (right)
                {
                    if (left)
                    {
                        sprRenderer.sprite = sprRUL;
                    }
                    else
                    {
                        sprRenderer.sprite = sprUR;
                    }
                }
                else if (left)
                {
                    sprRenderer.sprite = sprUL;
                }
                else
                {
                    sprRenderer.sprite = sprU;
                }
            }
            return;
        }
        if (down)
        {
            if (right)
            {
                if (left)
                {
                    sprRenderer.sprite = sprLDR;
                }
                else
                {
                    sprRenderer.sprite = sprDR;
                }
            }
            else if (left)
            {
                sprRenderer.sprite = sprDL;
            }
            else
            {
                sprRenderer.sprite = sprD;
            }
            return;
        }
        if (right)
        {
            if (left)
            {
                sprRenderer.sprite = sprRL;
            }
            else
            {
                sprRenderer.sprite = sprR;
            }
        }
        else
        {
            sprRenderer.sprite = sprL;
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
