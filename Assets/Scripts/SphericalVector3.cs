using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sphvector3 {
    public float radius;
    public float theta; 
    public float phi;
    public float r { get { return radius; } set { radius = value; } }
    public float t { get { return theta; } set { theta = value; } }
    public float p { get { return phi; } set { phi = value; } }

    public Sphvector3(float r, float t, float p) { this.radius = r; this.theta = t; this.phi = p;}

    public Vector3 ToVector3(Vector3? center = null) {
        var c = center.HasValue ? center.Value : Vector3.zero;
        var x = c.x + radius * Mathf.Sin(theta) * Mathf.Sin(phi);
        var y = c.y + radius * Mathf.Cos(theta);
        var z = c.z + radius * Mathf.Sin(theta) * Mathf.Cos(phi);
        return new Vector3(x, y, z);
    }

    public static Sphvector3 FromVector3(Vector3 input, Vector3? center = null) {
        var c = center.HasValue ? center.Value : Vector3.zero;
        var r = (input - c).magnitude;
        var t = Mathf.Acos((input.y - c.y) / r);
        var p = Mathf.Acos((input.z - c.z)/(r * Mathf.Sin(t)));
        return new Sphvector3(r, t, p);
    }
}
