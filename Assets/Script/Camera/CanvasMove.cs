using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMove : MonoBehaviour
{
    public Camera targetCamera;
    public Vector3 offset;

    void LateUpdate()
    {
        if (targetCamera != null)
        {
            transform.position = targetCamera.transform.position + offset;
        }
    }

    
}
