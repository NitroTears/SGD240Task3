using UnityEngine;
/// <summary>
/// The main class that represents a room. Holds the position, it's type, and it's doors.
/// </summary>
public class Room
// However camera bounding is implemented, on changing to a new room, change the camera bound restrictions to the new room.
{
    public Vector2 gridPosition;
    public RoomType roomType;
    public bool hasLeftDoor, hasRightDoor, hasTopDoor, hasBottomDoor;
    public GameObject leftDoor, rightDoor, topDoor, bottomDoor;

    void Start()
    {
        SetDoors();
    }

    public Room(Vector2 gridPos, RoomType type)
    {
        this.gridPosition = gridPos;
        this.roomType = type;
    }

    void SetDoors() // Updates which doors are active.
    {
        topDoor.SetActive(false);
        bottomDoor.SetActive(false);
        leftDoor.SetActive(false);
        rightDoor.SetActive(false);

        if (!hasTopDoor)
        {
            topDoor.SetActive(true);
        }
        if (!hasLeftDoor)
        {
            leftDoor.SetActive(true);
        }
        if (!hasBottomDoor)
        {
            bottomDoor.SetActive(true);
        }
        if (!hasRightDoor)
        {
            rightDoor.SetActive(true);
        }
    }

    public override string ToString()
    {
        return gridPosition + " " + roomType;
    }

}
public enum RoomType
{
    Start,
    Normal,
    Boss,
    Item,

}