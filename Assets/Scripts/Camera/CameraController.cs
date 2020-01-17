using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraConfiguration))]
public class CameraController : InputListener
{
    private CameraConfiguration cameraConfiguration;
    private Vector3 offset;
    private Vector3 smoothingVelocity;

    void Start ()
    {
        Debug.Assert(InputController != null);
        Subscribe(InputController);
        cameraConfiguration = (cameraConfiguration == null) ? GetComponent<CameraConfiguration>() : cameraConfiguration;
        Debug.Assert(cameraConfiguration != null);
        transform.LookAt(cameraConfiguration.Target);
    }

    public override void OnLeftStick(float horizontal, float vertical)
    {
        var targetPosition = cameraConfiguration.Target.position + cameraConfiguration.Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref smoothingVelocity, cameraConfiguration.SmoothingTime);
        transform.LookAt(cameraConfiguration.Target);
    }


    public override void OnRightStick(float horizontal, float vertical)
    {
        transform.RotateAround(cameraConfiguration.Target.position, Vector2.up, -horizontal * cameraConfiguration.RotationSpeed);
        transform.LookAt(cameraConfiguration.Target);
        var new_offset_normaized = (transform.position - cameraConfiguration.Target.position).normalized;
        cameraConfiguration.Offset = new_offset_normaized * cameraConfiguration.OffsetMagnitude;
        // cameraConfiguration.Offset = transform.position - cameraConfiguration.Target.position;
    }

}
