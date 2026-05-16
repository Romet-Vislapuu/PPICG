using UnityEngine;

public class MazeFactory2 : AbstractMazeFactory
{
    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private GameObject riverRight;
    [SerializeField]
    private GameObject riverForward;
    [SerializeField]
    private GameObject portal;
    public override MapTile CreateGround(Vector3 pos)
    {
        return new Ground(null, ground, pos);
    }

    public override Maze CreateMaze()
    {
        return new Maze();
    }

    public override Portal CreatePortal(Vector3 pos)
    {
        return new Portal(null, portal, pos);
    }

    public override MapTile CreateRiverForward(Vector3 pos)
    {
        return new Ground(null, riverForward, pos);
    }
    public override MapTile CreateRiverRight(Vector3 pos)
    {
        return new Ground(null, riverRight, pos);
    }

    public override Room CreateRoom(int nr)
    {
        return new Room(nr);
    }
}
