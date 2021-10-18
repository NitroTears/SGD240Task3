using UnityEngine;

public class Room
// However camera bounding is implemented, on changing to a new room, change the camera bound restrictions to the new room.

{
    public Vector2 gridPosition;
    public RoomType roomType;
    public bool hasLeftDoor;
    public bool hasRightDoor;
    public bool hasTopDoor;
    public bool hasBottomDoor;

    public Room(Vector2 gridPos, RoomType type)
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