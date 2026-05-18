using System.Collections.Generic;
using UnityEngine;

public class Pools : MonoBehaviour
{
    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private GameObject riverRight;
    [SerializeField]
    private GameObject riverForward;
    [SerializeField]
    private GameObject portal;

    public Dictionary<GameObject, Pool> pools = new Dictionary<GameObject, Pool>();

    private void Awake()
    {
        pools.Add(ground, new Pool(ground, 20));
        pools.Add(riverRight, new Pool(riverRight, 20));
        pools.Add(riverForward, new Pool(riverForward, 20));
        pools.Add(portal, new Pool(portal, 20));



    }

    public PooledObject GetPooledObject(GameObject prefab) {
        return pools[prefab].GetPooledObject();
    }
    public void KillPooledObject(PooledObject po) {
        pools[po.prefab].KillPooledObject(po);


    }
    public void PoolsDebugger()
    {
        foreach (Pool pool in pools.Values)
        {
            pool.PoolDebugger();



        }
    }



}
