﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

	[System.Serializable]
	public class Pool
	{
		public string tag;
		public GameObject prefab;
		public int size;
	}
	#region singleton
	public static ObjectPooler Instance;

	private void Awake()
	{
		Instance = this;
	}
	#endregion
	public List<Pool> pools;
	public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    void Start()
    {
		poolDictionary = new Dictionary<string, Queue<GameObject>>();

		foreach (Pool pool in pools)
		{
			Queue<GameObject> objectPool = new Queue<GameObject>();

			for(int i = 0; i < pool.size; i++)
			{
				GameObject obj = Instantiate(pool.prefab);
				obj.SetActive(false);
				obj.transform.parent = gameObject.transform;// testing, obj is child
				objectPool.Enqueue(obj);
			}

			poolDictionary.Add(pool.tag, objectPool);
		}
    }

    
	public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
		if (!poolDictionary.ContainsKey(tag))
		{
			return null;
		}

		GameObject objectToSpawn = poolDictionary[tag].Dequeue();
		objectToSpawn.SetActive(true);
		objectToSpawn.transform.position = position;
		objectToSpawn.transform.rotation = rotation;
		

		IPooledObjects pooledObj = objectToSpawn.GetComponent<IPooledObjects>();

		if(pooledObj != null)
		{
			pooledObj.OnObjectSpawn();
		}

		poolDictionary[tag].Enqueue(objectToSpawn);

		return objectToSpawn;
    }
}
