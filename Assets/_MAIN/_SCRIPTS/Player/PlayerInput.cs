using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    //FAÇADE 
    private PlayerController _player;


    // BINDINGS
    [SerializeField] private KeyCode _attackKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode _weapon1Key = KeyCode.Alpha1;
    [SerializeField] private KeyCode _weapon2Key = KeyCode.Alpha2;

    [SerializeField] private KeyCode _moveForward = KeyCode.W;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveBackward = KeyCode.S;

    void Start()
    {
        _player = GetComponent<PlayerController>();
    }
    void Update()
    {
        //Move


        if (Input.GetKey(_moveForward) && !Input.GetKey(_attackKey) && !Input.GetKey(_moveLeft) && !Input.GetKey(_moveRight)) _player.Move(transform.forward);
        if (Input.GetKey(_moveBackward) && !Input.GetKey(_attackKey) && !Input.GetKey(_moveLeft) && !Input.GetKey(_moveRight)) _player.Move(-transform.forward);
        if (Input.GetKey(_moveRight) && !Input.GetKey(_attackKey) && !Input.GetKey(_moveForward) && !Input.GetKey(_moveBackward)) _player.Move(transform.right);
        if (Input.GetKey(_moveLeft) && !Input.GetKey(_attackKey) && !Input.GetKey(_moveForward) && !Input.GetKey(_moveBackward)) _player.Move(-transform.right);



        if (Input.GetKeyDown(_attackKey)) _player.Shoot();
        //Change Weapon
        if (Input.GetKeyDown(_weapon1Key)) _player.ChangeWeapon(0);
        if (Input.GetKeyDown(_weapon2Key)) _player.ChangeWeapon(1);
    }
}
