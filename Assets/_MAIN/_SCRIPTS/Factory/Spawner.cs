using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : IFactory<T> where T : MonoBehaviour
{
    public T Create(T prefab, Transform parent)
    {
        return GameObject.Instantiate(prefab, parent);
    }
}
   

