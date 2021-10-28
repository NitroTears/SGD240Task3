using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is now unused, Most of this functionality was merged with the Room class.
/// remnants of the tutorial I used can also be found here.
/// </summary>

public class RoomObject : MonoBehaviour
{
    // public Sprite sprU, sprD, sprR, sprL, sprUD, sprRL, sprUR, sprUL, sprDR, sprDL, sprULD, sprRUL, sprDRU, sprLDR, sprUDRL;
    public bool up, down, left, right;
    public GameObject doorLeft, doorRight, doorTop, doorBottom;
    public RoomType roomType;
    // public Color normalColour, enterColour;
    // Color mainColour;
    // SpriteRenderer sprRenderer;

    // Start is called before the first frame update
    void Start()
    {
        doorTop.SetActive(false);
        doorBottom.SetActive(false);
        doorLeft.SetActive(false);
        doorRight.SetActive(false);

        // doorLeft = GameObject.Find("DoorLeft");
        // doorRight = GameObject.Find("DoorRight");
        // doorTop = GameObject.Find("DoorTop");
        // doorBottom = GameObject.Find("DoorBottom");

        // sprRenderer = GetComponent<SpriteRenderer>();
        // normalColour.a = 1;
        // mainColour = normalColour;
        // mainColour.a = 1;

        SetDoors();
        // PickSprite(); // These are the old methods from a tutorial, they used sprites and colours instead of door objects.
        // PickColour();
    }

    // private void PickColour()
    // {
    //     if (roomType == RoomType.Normal)
    //     {
    //         mainColour = normalColour;
    //     }
    //     else if (roomType == RoomType.Start)
    //     {
    //         mainColour = enterColour;
    //     }
    //     sprRenderer.color = mainColour;
    // }


    void SetDoors() // The replacement for PickSprite for the new room.
    {
        if (!up)
        {
            doorTop.SetActive(true);
        }
        if (!left)
        {
            doorLeft.SetActive(true);
        }
        if (!down)
        {
            doorBottom.SetActive(true);
        }
        if (!right)
        {
            doorRight.SetActive(true);
        }


    }

    // picks correct sprite based on the four door bools
    // void PickSprite()
    // {
    //     if (up)
    //     {
    //         if (down)
    //         {
    //             if (right)
    //             {
    //                 if (left)
    //                 {
    //                     sprRenderer.sprite = sprUDRL;
    //                 }
    //                 else
    //                 {
    //                     sprRenderer.sprite = sprDRU;
    //                 }
    //             }
    //             else if (left)
    //             {
    //                 sprRenderer.sprite = sprULD;
    //             }
    //             else
    //             {
    //                 sprRenderer.sprite = sprUD;
    //             }
    //         }
    //         else
    //         {
    //             if (right)
    //             {
    //                 if (left)
    //                 {
    //                     sprRenderer.sprite = sprRUL;
    //                 }
    //                 else
    //                 {
    //                     sprRenderer.sprite = sprUR;
    //                 }
    //             }
    //             else if (left)
    //             {
    //                 sprRenderer.sprite = sprUL;
    //             }
    //             else
    //             {
    //                 sprRenderer.sprite = sprU;
    //             }
    //         }
    //         return;
    //     }
    //     if (down)
    //     {
    //         if (right)
    //         {
    //             if (left)
    //             {
    //                 sprRenderer.sprite = sprLDR;
    //             }
    //             else
    //             {
    //                 sprRenderer.sprite = sprDR;
    //             }
    //         }
    //         else if (left)
    //         {
    //             sprRenderer.sprite = sprDL;
    //         }
    //         else
    //         {
    //             sprRenderer.sprite = sprD;
    //         }
    //         return;
    //     }
    //     if (right)
    //     {
    //         if (left)
    //         {
    //             sprRenderer.sprite = sprRL;
    //         }
    //         else
    //         {
    //             sprRenderer.sprite = sprR;
    //         }
    //     }
    //     else
    //     {
    //         sprRenderer.sprite = sprL;
    //     }
    // }

}

