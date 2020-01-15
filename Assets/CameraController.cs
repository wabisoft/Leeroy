using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // var x = Input.GetAxis("Horizontal");
        // var y = Input.GetAxis("Vertical");
        // if (x != 0)
        //     Debug.Log(x);
        // if (y != 0)
        //     Debug.Log(y);

        for(int i = 1; i < 9; ++i)
        {
            if(i == 4 || i == 5) { continue; }
            var axis = Input.GetAxis($"A{i}");
            if(axis != 0)
            {
                Debug.Log($"Axis{i}: {axis}");
            }
        }
    }
}
