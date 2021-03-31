using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotateController : ObjectController
{
    private float rotateSpeed = 360.0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPointEnter && isPointDown)
            transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
    }
}
