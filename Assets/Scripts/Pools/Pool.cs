using NUnit.Framework;
using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class Pool
{
    // Dead objects are at the end.
    private List<PooledObject> pool = new List<PooledObject>();
    int index;//for fast pool
    private GameObject prefab;

    public Pool(GameObject prefab, int count) {
        for(int i = 0; i < count; i++)
        {
            pool.Add(new PooledObject(prefab, i));
        }
        this.prefab = prefab;
        index = 0;
    }//Pool()

    public PooledObject GetPooledObject() { 
        PooledObject p = pool[index];
        index++;
        if (index == pool.Count) {
            Debug.Log("Pool empty");
            p.Revive();
            PoolDebugger();
            return p;
        }
        p.Revive();
        return p;
    }
    public void KillPooledObject(PooledObject po)
    {
        po.Die();
        if (po.index == pool.Count-1)
        {
            // Inactive object at the end of the list where it should be.
            index = po.index;
            return;
        }
        // Move right if possible.
        for (int i = po.index + 1; i < pool.Count; i++)
        {
            if (pool[i].Alive)
            {
                Swap(pool[i - 1], pool[i]);
            }
            else
                break;

        }
        index = po.index;
    }
    public void Swap(PooledObject a, PooledObject b) { 
        int aIndex = a.index;
        int bIndex = b.index;

        pool[aIndex] = b;
        pool[bIndex] = a;
        a.index = bIndex;
        b.index = aIndex;
    }

    public void PoolDebugger()
    {
        string output = $"{prefab.name} Pool: ";
        for (int i = 0; i < pool.Count; i++) {
            output += $" [{pool[i].index}]{pool[i].Alive}";
        }
        Debug.Log(output);
    }



}
