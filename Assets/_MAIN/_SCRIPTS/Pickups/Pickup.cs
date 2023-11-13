using UnityEngine;

public abstract class Pickup : MonoBehaviour, IPickup
{   

    protected PlayerController _owner;

    public bool Grabbed { get; }

    public void Interaction()
    {
        Do();      
    }
    public void SetOwner(PlayerController owner)
    {
        _owner = owner;
    }
    public virtual void Do()
    {

       
    }

    public virtual void Update()
    {
       
    }
}
