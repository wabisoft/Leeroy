using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraConfiguration))]
public class CameraController : InputListener
{
    private CameraConfiguration cameraConfiguration;
    public CameraConfiguration CameraConfiguration { get { return cameraConfiguration; } }
    private Vector3 smoothingVelocity;
    private const float quarterPI = Mathf.PI / 4;
    private const float halfPI = Mathf.PI / 2;
    private const float twoPI = Mathf.PI * 2;

    void Start ()
    {
        Debug.Assert(InputController != null);
        Subscribe(InputController);
        cameraConfiguration = (cameraConfiguration == null) ? GetComponent<CameraConfiguration>() : cameraConfiguration;
        Debug.Assert(cameraConfiguration != null);
    }

    public override void OnRightStick(float horizontal, float vertical)
    {
        var moveTheta = -vertical * cameraConfiguration.RotationSpeed * Time.deltaTime;
        var movePhi = -horizontal * cameraConfiguration.RotationSpeed * Time.deltaTime;
        var offset = cameraConfiguration.Offset;
        var newTheta = offset.t + moveTheta;
        if(offset.t > 0 && newTheta < 0) {
            cameraConfiguration.Offset.t = Mathf.Clamp(newTheta, 0, halfPI);
        } else {
            cameraConfiguration.Offset.t = Mathf.Clamp(newTheta, -halfPI, 0);
        }
        // var absTheta = Mathf.Abs(cameraConfiguration.Offset.t);
        // var howCloseToQuarterPI =  Mathf.Clamp(absTheta / quarterPI, 0, 1);
        // var radiusplay = cameraConfiguration.MaxOffsetRadius - cameraConfiguration.MinOffsetRadius;
        // cameraConfiguration.Offset.r = radiusplay - (radiusplay * howCloseToQuarterPI);
        // Debug.Log(radiusplay * howCloseToQuarterPI);
        
        // cameraConfiguration.Offset.r = newRadius;
        var newPhi = offset.p + movePhi;
        if(Mathf.Abs(newPhi) > twoPI){
            newPhi = newPhi - Mathf.Sign(newPhi) * twoPI;
        }
        cameraConfiguration.Offset.p = newPhi;
        
    }

}
