using UnityEngine;
/// <summary>
/// The main class that represents a room. Holds the position, it's type, and it's doors.
/// </summary>
public class RoomData
// However camera bounding is implemented, on changing to a new room, change the camera bound restrictions to the new room.
{
    public Vector2 gridPosition;
    public RoomType roomType;
    public bool hasLeftDoor, hasRightDoor, hasTopDoor, hasBottomDoor;

    public RoomData(Vector2 gridPos, RoomType type)
    {
        this.gridPosition = gridPos;
        this.roomType = type;
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