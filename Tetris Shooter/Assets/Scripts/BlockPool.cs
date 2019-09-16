using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPool
{

    private List<GameObject> pool;
    private GameObject block;
    private Transform root;

    private static BlockPool instance;
    public static BlockPool Instance {
        get {
            if (instance == null)
            {
                instance = new BlockPool(20);
            }

            return instance;
        }
    }    

    private BlockPool(int startSize)
    {

        block = Resources.Load<GameObject>("Block");
        if(block == null)
        {
            Debug.LogError("Block Prefab not found in Resources");
        }

        root = new GameObject().transform;
        root.name = "BlockPool";
        pool = new List<GameObject>();

        for (int i = 0; i < startSize; i++)
        {
            pool.Add(GameObject.Instantiate(block,root));
            pool[i].SetActive(false);
        }
    }

    public GameObject GetNext()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool[0];
            obj.SetActive(true);
            pool.RemoveAt(0); 
            return obj;
        }
        else
        {
            return GameObject.Instantiate(block, root);
        }
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        pool.Add(obj);
    }

}