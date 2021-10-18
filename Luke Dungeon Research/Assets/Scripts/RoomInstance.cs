using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInstance : MonoBehaviour
{
    public Texture2D tex; // store the template data
    [HideInInspector]
    public Vector2 gridPosition;
    public RoomType roomType;
    [HideInInspector]
    public bool hasTopDoor, hasBottomDoor, hasLeftDoor, hasRightDoor;
    [SerializeField]
    GameObject topDoor, bottomDoor, leftDoor, rightDoor, doorWall;
    [SerializeField]
    ColourToGameObject[] mappings;
    float tileSize = 16;
    Vector2 roomSizeInTiles = new Vector2(9, 17);


    void Start()
    {
        // MakeDoors();
        // GenerateRoomTiles();
    }

    private void GenerateRoomTiles()
    {

    }

    private void MakeDoors()
    {
        Vector3 spawnPos = transform.position + Vector3.up * (roomSizeInTiles.y / 4 * tileSize) - Vector3.up * (tileSize / 4);
    }
}
