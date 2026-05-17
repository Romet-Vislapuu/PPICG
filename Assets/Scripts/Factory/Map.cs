using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Maze consists of rooms.
/// </summary>
public class Maze
{
    public List<Room> rooms = new List<Room>();

    public void AddRoom(Room room)
    {
        rooms.Add(room);
    }

    public void Load()
    {
        if(rooms.Count == 0)
        {
            return;
        }
        rooms[0].Load();
    }
}

/// <summary>
/// Base class for tiles and rooms. Defines that all things must be loaded and unload.
/// Enter method is called when actor enters the mapsite.
/// </summary>
public abstract class MapSite
{
    public virtual void Enter(Actor actor) { }
    /// <summary>
    /// Used to instantiate game objects into the scene.
    /// </summary>
    public virtual void Load() { }
    /// <summary>
    /// Used to clean up game objects from the scene.
    /// </summary>
    public virtual void Unload() { }
}

/// <summary>
/// Consists of tiles. Only one room is loaded at a time.
/// </summary>
public class Room : MapSite
{
    private bool toggle = false;
    public int nr;
    public List<MapTile> tiles = new List<MapTile>();

    private GameObject go;

    public Room(int nr)
    {
        this.nr = nr;
    }

    public override void Load()
    {
        UnityEngine.Debug.Log("Loading room " + nr);
        float startTime = Time.realtimeSinceStartup;
        go = new GameObject("Room " + nr);
        foreach (var tile in tiles)
        {
            tile.Load();
        }
        UnityEngine.Debug.Log("Ms to load: " + ((Time.realtimeSinceStartup - startTime) * 1000f));





        



    }

    public void AddTile(MapTile tile)
    {
        tile.room = this;
        tiles.Add(tile);
    }

    public override void Unload()
    {
        UnityEngine.Debug.Log("Unloading room " + nr);
        if (toggle)
        {

        }
        else {
            foreach (var tile in tiles)
            {
                tile.Unload();
            }
            Object.Destroy(go);

        }
    }

    public Transform GetTransform()
    {
        return go.transform;
    }
}

/// <summary>
/// Smallest part of the map. A single tile.
/// </summary>
public abstract class MapTile : MapSite {

    public Room room;
    protected Vector3 position;
    protected GameObject prefab;
    private GameObject go;
    private PooledObject po;
    private bool toggle = false;
    protected const float tileSize = 3f; //hard coded ugliness

    public MapTile(Room room, GameObject pref, Vector3 pos)
    {
        this.room = room;
        this.position = pos;
        this.prefab = pref;
    }

    public override void Enter(Actor actor)
    {
        UnityEngine.Debug.Log(string.Format("{0} entered tile {1}", actor.name, position));
    }

    public override void Load()
    {
        // Not pool
        if (toggle)
        {
            go = Object.Instantiate<GameObject>(prefab, position * tileSize, Quaternion.identity);

            go.transform.parent = room.GetTransform();
            go.GetComponent<TileEvent>().tile = this;
        }
        //Pool
        else
        {

            po = ServiceSingleton.Instance.PoolService.GetPooledObject(prefab);
            go = po.go;
            go.transform.position = position * tileSize;
            go.transform.rotation = Quaternion.identity;
            go.transform.parent = room.GetTransform();
            go.GetComponent<TileEvent>().tile = this;
        }

    }

    public override void Unload()
    {
        //Not pool
        if (toggle)
            Object.Destroy(go);
        //Pool
        else
            ServiceSingleton.Instance.PoolService.KillPooledObject(po);



    }
}

/// <summary>
/// Doesn't really do anything
/// </summary>
public class Ground : MapTile
{
    public Ground(Room room, GameObject pref, Vector3 pos) : base (room, pref, pos)
    {
    }
}

/// <summary>
/// A tile that moves player into anothe room when entered.
/// </summary>
public class Portal : MapTile
{
    Portal exit;

    public Portal(Room room, GameObject pref, Vector3 pos) : base (room, pref, pos)
    {
    }

    public void SetExit(Portal exit)
    {
        this.exit = exit;
    }

    public override void Enter(Actor actor)
    {
        UnityEngine.Debug.Log(string.Format("{0} entered portal {1}", actor.name, position));
        if (room != exit.room)
        {
            room.Unload();
            exit.room.Load();
        }
        Vector3 cornerOffset = new Vector3(-2f, 0, -3f);
        actor.SetPosition(exit.position * tileSize + cornerOffset);
    }
}