using UnityEngine;

public class Room
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
    /** Old stuff
    // However camera bounding is implemented, on changing to a new room, change the camera bound restrictions to the new room.
    private const int _heightUnit = 10, _widthUnit = 18;
    private Door leftDoor, rightDoor, topDoor, bottomDoor;
    private int height { get { return _heightUnit * unitsInHeight; } }
    private int width { get { return _widthUnit * unitsInWidth; } }
    public int unitsInHeight, unitsInWidth, xPos, yPos;
    public bool hasLeftDoor { get { return leftDoor != null; } }
    public bool hasRightDoor { get { return rightDoor != null; } }
    public bool hasTopDoor { get { return topDoor != null; } }
    public bool hasBottomDoor { get { return bottomDoor != null; } }
    public Vector3 cameraAnchorPoint;
    public string roomName;

    public Room(int unitsInHeight, int unitsInWidth, int xPos, int yPos)
    {
        this.unitsInHeight = unitsInHeight;
        this.unitsInWidth = unitsInWidth;
        this.xPos = xPos;
        this.yPos = yPos;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Debug.Log(width + " " + height);
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }
    Vector3 GetRoomCenter()
    {
        return new Vector3(xPos * width, yPos * height);
    }

    **/
}



public enum RoomType
{
    Start,
    Normal,
    Boss,
    Item,

}