using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixHipsPos : MonoBehaviour
{
    public Transform hips;
    private Vector3 hipsPos;
    
    // Start is called before the first frame update
    void Start()
    {
        hipsPos = hips.localPosition;
    }


    private void LateUpdate()
    {
        hips.transform.localPosition = hipsPos;
    }
}
