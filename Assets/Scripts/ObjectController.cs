using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ObjectController : MonoBehaviourPun
{
    protected bool isPointEnter = false;
    protected bool isPointDown = false;

    public void PointEnter()
    {
        isPointEnter = true;
    }

    public void PointExit()
    {
        isPointEnter = false;
    }

    public void PointUp()
    {
        isPointDown = false;
    }
    
    public void PointDown()
    {
        isPointDown = true;
    }
}
