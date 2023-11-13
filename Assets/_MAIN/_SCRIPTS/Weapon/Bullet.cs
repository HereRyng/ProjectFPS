using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IBullet
{
   
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private LayerMask _hittableMask;
    [SerializeField] private float _speed;
    private float _currentLifeTime;
    private Collider _collider;
    private Rigidbody _rigidbody;

    #region Properties

    public Gun Owner { get; private set; }

    public LayerMask mask => _hittableMask;

    public Rigidbody _Rigidbody => _rigidbody;

    public Collider _Collider => _collider;

    public float LifeTime => _lifeTime;

    public float CurrentSpeed => _speed;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

        
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        _currentLifeTime = _lifeTime;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _currentLifeTime -= Time.deltaTime;
        if (_currentLifeTime <= 0) Destroy(gameObject);
        Travel();
    }

    public void SetOwner(Gun owner)
    {
        Owner = owner;
    }

    public void Travel()
    {

        transform.position += transform.forward* CurrentSpeed * Time.deltaTime;
       
    }

    public void Init()
    {
        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    } 

    public void OnTriggerEnter(Collider other)
    {
        if ((_hittableMask & 1 << other.gameObject.layer) != 0) 
        {
            other.GetComponent<IDamageable>()?.TakeDamage(Owner.Stats.Damage);
            Destroy(gameObject);
            
        }
         
    }
}
