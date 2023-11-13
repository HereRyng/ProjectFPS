using System.Collections;               
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    float LifeTime { get; }
    float CurrentSpeed { get; }
    Gun Owner { get; }
    LayerMask mask { get; }             
    Rigidbody _Rigidbody { get; }
    Collider _Collider { get; }
    void Travel();
    void Init();
    void SetOwner(Gun owner);
    void OnTriggerEnter(Collider other);

}
