using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ObjectPoolManager : MonoBehaviour
{

    static private ObjectPoolManager _singleton = null;
    static private ObjectPoolManager singleton
    {
        get 
        {
            if (_singleton == null)
            {
                InstantiateSingleton();
            }
            return singleton;
        }
    }
    private Dictionary<int, Queue<GameObject>> pool = new Dictionary<int, Queue<GameObject>>();

    void Awake()
    {
        if (_singleton == null)
        {
            _singleton = this;
        }
        else if (_singleton != this)
        {
            Destroy(this);
        }
    }

    private void AddInstanceToPool(GameObject argPrefab)
    {
        int instanceId = argPrefab.GetInstanceID();
        argPrefab.SetActive(false);
        GameObject instance = Instantiate(argPrefab);
        argPrefab.SetActive(true);
        instance.name = argPrefab.name;
        instance.transform.parent = transform;
        if (pool.ContainsKey(instanceId) == false)
        {
            pool.Add(instanceId, new Queue<GameObject>());
        }
        pool[instanceId].Enqueue(instance);
        
    }

    private GameObject GetPooledInstance(GameObject argPrefab, Vector3 argPosition, Quaternion argRotation)
    {
        int instanceID = argPrefab.GetInstanceID();
        GameObject instance = null;
        if (pool.ContainsKey(instanceID) && pool[instanceID].Count != 0)
        {
            if (pool[instanceID].Peek().activeSelf == false)
            {
                instance = pool[instanceID].Dequeue();
                pool[instanceID].Enqueue(instance);
            }
        }
            else 
            { 
                AddInstanceToPool(argPrefab);
                instance = pool[instanceID].Dequeue();
                pool[instanceID].Enqueue(instance);
            }   
        
        instance.transform.position = argPosition;
        instance.transform.rotation = argRotation;
        instance.SetActive(true);
        return instance;
    }
    static private void InstantiateSingleton()
    {
        new GameObject("#ObjectPoolManager", typeof(ObjectPoolManager));
    }

    static public void InstantiatePooled ( GameObject argPrefab , Vector3 argPosition , Quaternion argRotation ) {
    
         singleton.GetPooledInstance( argPrefab , argPosition , argRotation );
    }
    static public void InstantiatePooled <T> ( GameObject argPrefab , Vector3 argPosition , Quaternion argRotation , System.Action<T> argAction ) {
         GameObject instance = singleton.GetPooledInstance( argPrefab , argPosition , argRotation );
 
         T[] tComponents = instance.GetComponentsInChildren<T>();
         for( int i = 0 ; i<tComponents.Length ; i++ ) {
             argAction( tComponents[i] );
         }
     }

    static public void InstantiatePooled(GameObject argPrefab, Vector3 argPosition, Quaternion argRotation, Transform argParentTo)
    {
        GameObject instance = singleton.GetPooledInstance(argPrefab, argPosition, argRotation);

        if (instance.GetComponent<Rigidbody>() != null && argParentTo.GetComponent<Rigidbody>() != null)
        {
            Debug.LogWarning("Avoid parenting rigidbodies to another rigidbody. This will causes problems. Ie.: " + instance.name + ".transform.SetParent(" + argParentTo.name + ".transform)");
            Debug.Break();
            return;
        }

        instance.transform.SetParent(argParentTo, true);
    }

}
