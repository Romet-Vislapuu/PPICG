using UnityEngine;
using UnityEngine.Pool;

public class PooledObject
{
    public GameObject go;
    public GameObject prefab;//any point in storing this here?
    public int index;
    public bool Alive { get; private set; }

    public PooledObject(GameObject prefab, int index)
    {
        this.index = index;
        this.prefab = prefab;
        this.go = GameObject.Instantiate(prefab);
        Die();//start turned off.
    }
    //TODO
    public void Revive() {
        this.Alive = true;
        //Debug.Log(go);
        go.SetActive(true);
    }
    public void Die() {
        this.Alive = false;
        go.transform.parent = null;// Since the room gets destroyed even in this version, and "go" gets added as a child to room, when room gets destroyed so does child, which is why you got to remove the parent.
        go.SetActive(false);
    
    }
    
}
