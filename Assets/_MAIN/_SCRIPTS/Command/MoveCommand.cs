using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    public Vector3 _Direction { get; private set; }
    public Transform _transform { get; private set; }
    public float _CurrentSpeed { get; private set; }

    public MoveCommand(Transform transform, float currentSpeed, Vector3 direction)
    {

        _transform = transform;
        _CurrentSpeed = currentSpeed;
        _Direction = direction;
    }
    
    public void Do()
    {
        _transform.position += _Direction * _CurrentSpeed * Time.deltaTime;
    }
}
