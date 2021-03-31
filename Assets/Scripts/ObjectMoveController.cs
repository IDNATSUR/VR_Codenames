using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveController : ObjectController
{
    private float speed = 2.0F;
    private Outline outline;
    void Start() 
    {
        outline = this.GetComponent<Outline>();
    }

    void Update()
    {
        outline.enabled = isPointEnter? true : false;
        if (isPointEnter && isPointDown)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
