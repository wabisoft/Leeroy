using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraController))]
[ExecuteInEditMode]
public class CameraConfiguration : MonoBehaviour
{
    [Range(0.5f, 5)]
    public float RotationSpeed = 2;
    [Range(0.1f, 1)]
    public float ZoomSpeed = 0.1f;
    [Range(0.1f, 1)]
    public PlayerController Target;
    public Sphvector3 Offset;
    public float MinOffsetRadius = 10;
    public float MaxOffsetRadius = 10;
    private CameraController cameraController;
    private Vector3 smoothingVelocity;

    void Start()
    {
        cameraController = (cameraController) ?? GetComponent<CameraController>();
        Debug.Assert(cameraController != null);
        transform.LookAt(Target.transform);
    }

    void LateUpdate() {
        var targetPosition = Offset.ToVector3(Target.transform.position);
        transform.position = targetPosition;
        transform.LookAt(Target.transform.position);
    }
}
