using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraController))]
[ExecuteInEditMode]
public class CameraConfiguration : MonoBehaviour
{
    public float YOffset;
    public float ZOffset;
    [Range(0.3f, 1)]
    public float SmoothingTime;
    [Range(1, 5)]
    public float RotationSpeed;
    public Transform Target;
    private CameraController cameraController;

    private Vector3 offset;
    public Vector3 Offset { get { return offset; } set { offset = value; } } // TODO: maybe calculate this on the fly from a more complicated principle
    public float OffsetMagnitude {get; private set;}

    void Start()
    {
        cameraController = (cameraController) ?? GetComponent<CameraController>();
        Debug.Assert(cameraController != null);
        offset = new Vector3(0, YOffset, ZOffset);
        OffsetMagnitude = offset.magnitude;
    }

    void LateUpdate()
    {
        transform.LookAt(Target);
    }

}
