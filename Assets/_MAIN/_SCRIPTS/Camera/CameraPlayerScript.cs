using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerScript : MonoBehaviour
{
    [SerializeField] private Vector2 speed;
    Vector2 rotateView;
    [SerializeField] private Camera mainCam;
    [SerializeField] private float rotMaxHigher;
    [SerializeField] private float rotMinLower;
 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   

    }

    // Update is called once per frame
    void Update()
    {
        rotateView.x = speed.x * Input.GetAxis("Mouse X");
        rotateView.y += speed.y * Input.GetAxis("Mouse Y");
        mainCam.transform.localEulerAngles = new Vector2(-rotateView.y, 0);
        transform.Rotate(0, rotateView.x, 0);
        rotateView.y = Mathf.Clamp(rotateView.y, rotMinLower, rotMaxHigher);
    }
}
