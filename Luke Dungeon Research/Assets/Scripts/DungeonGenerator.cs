using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public Vector2 mapSize;
    Room[,] rooms;
    List<Vector2> filledMapPositions = new List<Vector2>();
    int mapSizeX, mapSizeY;
    public int NumberOfRooms;
    private Vector2 furthestRoom;
    public GameObject roomObj;
    public GameObject startRoomObj;
    public GameObject bossRoomObj;


    void Start()
    {
        if (NumberOfRooms >= (mapSize.x * 2) * (mapSize.y * 2))
        {
            NumberOfRooms = Mathf.RoundToInt((mapSize.x * 2) * (mapSize.y * 2));
        }
        mapSizeX = Mathf.RoundToInt(mapSize.x);
        mapSizeY = Mathf.RoundToInt(mapSize.y);
        CreateRooms();
        SetRoomDoors();
        DrawMap();
    }

    void CreateRooms()
    {
        furthestRoom = new Vector2(0, 0); //holds the furthest room away, to dictate the boss room.
        rooms = new Room[mapSizeX * 2, mapSizeY * 2]; // generate the map bounds (mapSizeX/Y is the center of the room.)
        rooms[mapSizeX, mapSizeY] = new Room(Vector2.zero, RoomType.Start); // put starting room in the centre
        filledMapPositions.Insert(0, Vector2.zero); // add this starting room to the list of filled positions
        Vector2 checkPos = Vector2.zero;

        // generate room positions
        float randomCompare = 0.2f, randomCompareStart = 0.2f, randomCompareEnd = 0.01f; // 'magic numbers'
        for (int i = 0; i < NumberOfRooms - 1; i++) // minus 1 to account for the starting room
        {
            float randomPerc = ((float)i) / (((float)NumberOfRooms - 1));
            randomCompare = Mathf.Lerp(randomCompareStart, randomCompareEnd, randomPerc);
            checkPos = NewPosition(); // get valid position for spawn
            if (NumberOfNeighbours(checkPos, filledMapPositions) > 1 && UnityEngine.Random.value > randomCompare) // branch out the rooms
            {
                int iterations = 0;
                do
                {
                    checkPos = SelectiveNewPosition();
                    iterations++;
                } while (NumberOfNeighbours(checkPos, filledMapPositions) > 1 && iterations < 100);
                if (iterations >= 50)
                {
                    Debug.Log("Error: could not create with fewer neighbours than : " + NumberOfNeighbours(checkPos, filledMapPositions));
                }
            }

            rooms[(int)checkPos.x + mapSizeX, (int)checkPos.y + mapSizeY] = new Room(checkPos, RoomType.Normal);
            if (AbsVector2(checkPos).x + AbsVector2(checkPos).y > furthestRoom.x + furthestRoom.y)
            // The furthest room from the start room will be used as the boss room. Absolute values are used to measure distance from (0, 0).
            {
                furthestRoom = AbsVector2(checkPos);
            }
            filledMapPositions.Insert(0, checkPos);
        }

        // rooms.GetValue()
        foreach (var room in rooms)
        {
            try
            {
                if (room != null)
                {
                    if (furthestRoom == room.gridPosition)
                    {
                        room.roomType = RoomType.Boss;
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                Debug.Log("Ouch");
            }
            finally
            {

            }

        }
    }

    private int NumberOfNeighbours(Vector2 checkPos, List<Vector2> filledMapPositions)
    {
        int noOfNeighbours = 0;
        if (filledMapPositions.Contains(checkPos + Vector2.right))
        {
            noOfNeighbours++;
        }
        if (filledMapPositions.Contains(checkPos + Vector2.left))
        {
            noOfNeighbours++;
        }
        if (filledMapPositions.Contains(checkPos + Vector2.up))
        {
            noOfNeighbours++;
        }
        if (filledMapPositions.Contains(checkPos + Vector2.down))
        {
            noOfNeighbours++;
        }
        return noOfNeighbours;
    }

    Vector2 SelectiveNewPosition() // Gets a valid position, one that only only has one neighbour
    {
        int index = 0, inc = 0;
        int x = 0, y = 0;
        Vector2 checkingPos = Vector2.zero;
        do // Calculate new Positions until one is not taken by existing room and is within the boundaries of the map
        {
            inc = 0;
            do // Get a room that only has one neighbour
            {
                index = Mathf.RoundToInt(UnityEngine.Random.value * (filledMapPositions.Count - 1)); // Get a random existing room to offset from.
                inc++;
            } while (NumberOfNeighbours(filledMapPositions[index], filledMapPositions) > 1 && inc < 100);
            x = (int)filledMapPositions[index].x;
            y = (int)filledMapPositions[index].y;
            bool upAndDown = (UnityEngine.Random.value < 0.5f);
            bool positive = (UnityEngine.Random.value < 0.5f);
            if (upAndDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y); // get the new position.
        } while (filledMapPositions.Contains(checkingPos) || x >= mapSizeX || x < -mapSizeX || y >= mapSizeY || y < -mapSizeY);
        if (inc >= 100)
        {
            Debug.Log("Error: Could not find a position with only one neighbour");

        }
        return checkingPos;
    }

    Vector2 NewPosition() // Gets a valid position, one that is adjacent to an existing room.
    {
        int x = 0, y = 0;
        Vector2 checkingPos = Vector2.zero;
        do // Calculate new Positions until one is not taken by existing room and is within the boundaries of the map
        {
            int index = Mathf.RoundToInt(UnityEngine.Random.value * (filledMapPositions.Count - 1)); // Get a random existing room to offset from.
            x = (int)filledMapPositions[index].x;
            y = (int)filledMapPositions[index].y;
            bool upAndDown = (UnityEngine.Random.value < 0.5f);
            bool positive = (UnityEngine.Random.value < 0.5f);
            if (upAndDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y); // get the new position.
        } while (filledMapPositions.Contains(checkingPos) || x >= mapSizeX || x < -mapSizeX || y >= mapSizeY || y < -mapSizeY);
        return checkingPos;
    }

    void SetRoomDoors()
    {
        for (int x = 0; x < (mapSizeX * 2); x++)
        {
            for (int y = 0; y < (mapSizeY * 2); y++) // Nested loop to look through 2D list of positions
            {
                if (rooms[x, y] == null)
                {
                    continue;
                }
                Vector2 mapPosition = new Vector2(x, y);
                rooms[x, y].hasBottomDoor = y - 1 < 0 ? false : (rooms[x, y - 1] != null);
                rooms[x, y].hasTopDoor = (y + 1 >= mapSizeY * 2) ? false : (rooms[x, y + 1] != null);
                rooms[x, y].hasLeftDoor = x - 1 < 0 ? false : (rooms[x - 1, y] != null);
                rooms[x, y].hasRightDoor = (x + 1 >= mapSizeX * 2) ? false : (rooms[x + 1, y] != null);
            }
        }
    }

    private void DrawMap()
    {
        MapSpriteSelector mapper = null;
        // var firstRoom = true;
        foreach (Room room in rooms)
        {
            if (room == null)
            {
                continue;
            }
            Debug.Log(room.ToString());
            Vector2 drawPos = room.gridPosition;
            drawPos.x *= 1280; // 16 // these are the size of the map sprite.
            drawPos.y *= 720;  // 8
            switch (room.roomType)
            {
                case RoomType.Start:
                    mapper = UnityEngine.Object.Instantiate(startRoomObj, drawPos, Quaternion.identity).GetComponent<MapSpriteSelector>();
                    break;
                case RoomType.Normal:
                    mapper = UnityEngine.Object.Instantiate(roomObj, drawPos, Quaternion.identity).GetComponent<MapSpriteSelector>();

                    break;
                case RoomType.Boss:
                    mapper = UnityEngine.Object.Instantiate(bossRoomObj, drawPos, Quaternion.identity).GetComponent<MapSpriteSelector>();
                    break;
                // case RoomType.Item:
                //     break;
                default:
                    break;
            }
            // if (room.gridPosition == furthestRoom)
            // {
            //    mapper = UnityEngine.Object.Instantiate(bossRoomObj, drawPos, Quaternion.identity).GetComponent<MapSpriteSelector>();
            // }
            mapper.roomType = room.roomType;
            mapper.up = room.hasTopDoor;
            mapper.down = room.hasBottomDoor;
            mapper.left = room.hasLeftDoor;
            mapper.right = room.hasRightDoor;
        }
    }

    public bool DoesRoomExist(Vector2 mapPosition)
    {

        return true;
    }

    // Vector2 didn't have a native absolute value function, so I made one.
    public Vector2 AbsVector2(Vector2 vector2)
    {
        return new Vector2(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y));

    }
}
