using UnityEngine;

public abstract class AbstractMazeFactory : MonoBehaviour {

    public abstract Maze CreateMaze();
    public abstract Room CreateRoom(int nr);
    public abstract Portal CreatePortal(Vector3 pos);
    public abstract MapTile CreateGround(Vector3 pos);
    public abstract MapTile CreateRiverForward(Vector3 pos);
    public abstract MapTile CreateRiverRight(Vector3 pos);


}
