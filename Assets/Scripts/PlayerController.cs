using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : InputListener
{
    private new Rigidbody rigidbody;
    public Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = (rigidbody) ?? GetComponent<Rigidbody>();
        Debug.Assert(rigidbody != null);
        Subscribe(InputController);
    }

    public override void OnLeftStick(float horizontal, float vertical)
    {
        var z_movement = Camera.transform.forward * vertical;
        var x_movement = Camera.transform.right * horizontal;
        var movement = z_movement + x_movement;
        movement *= 5 * Time.deltaTime;
        rigidbody.MovePosition(transform.position + movement);
        transform.rotation = Quaternion.LookRotation(movement);
    }

    public override void OnRightStick(float horizontal, float vertical)
    {
        // var targetRotation = Quaternion.Euler(0, horizontal, 0);
        // var targetRotation = Quaternion.LookRotation(new Vector3(horizontal, 0, 0)* Time.deltaTime);
        // transform.rotation *= targetRotation;
        // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
        // transform.Translate(movement, Space.Self);
        // rigidbody.MovePosition(transform.position + movement);
    }

    public override void OnDPad(float horizontal, float vertical) {
        OnLeftStick(horizontal, vertical);
    }

}
