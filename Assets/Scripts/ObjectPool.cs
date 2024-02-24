using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    List<GameObject> bulletPoolingList = new List<GameObject>();
    [SerializeField] GameObject bullet;
    [SerializeField] int objectToPooling;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start() 
    {
        for(int i = 0; i < objectToPooling; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            bulletPoolingList.Add(obj);
        }
    }
    
    public GameObject FindABullet()
    {
        for(int i = 0; i < bulletPoolingList.Count; i++)
        {
            if(!bulletPoolingList[i].activeInHierarchy)
            {
                return bulletPoolingList[i];
            }
        }

        return null;
    }


}
