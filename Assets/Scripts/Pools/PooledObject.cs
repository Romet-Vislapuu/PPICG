using UnityEngine;
using UnityEngine.Pool;

public class PooledObject
{
    private GameObject go;
    public GameObject prefab;//any point in storing this here?
    public int index;
    public bool Alive;

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
        go.SetActive(true);
    }
    public void Die() {
        this.Alive = false;
        go.SetActive(false);
    
    }
    
}
