using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : InputListener
{
    private new Rigidbody rigidbody;
    public Camera CameraController;
    [Range(1, 10)]
    public float MovementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = (rigidbody) ?? GetComponent<Rigidbody>();
        Debug.Assert(rigidbody != null);
        Subscribe(InputController);
    }

    public override void OnLeftStick(float horizontal, float vertical)
    {
        var cameraRelPos =  (transform.position - CameraController.transform.position).normalized;
        var forward = new Vector3(cameraRelPos.x, 0, cameraRelPos.z);
        var right = CameraController.transform.right;
        var z_movement = forward * vertical;
        var x_movement = right * horizontal;
        var movement = z_movement + x_movement;
        Debug.DrawLine(transform.position, transform.position + right * 1, Color.red);
        Debug.DrawLine(transform.position, transform.position + forward * 1, Color.blue);
        movement *= MovementSpeed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + movement);
        transform.rotation = Quaternion.LookRotation(movement);
    }


    public override void OnDPad(float horizontal, float vertical) {
        OnLeftStick(horizontal, vertical);
    }

}
