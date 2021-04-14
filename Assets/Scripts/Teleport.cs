using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 spymaster = new Vector3(-4.053f, 1.587f, -36.198f);
    public Vector3 spawn = new Vector3(-.451156f, 1.867f, 1.286f);

    public void tp(string btnName)
    {
        switch (btnName)
        {
            case "spymaster":
                gameObject.transform.position = spymaster;
                //Debug.Log("Attempted to teleport to spymaster view");
                break;
            case "spawn":
                gameObject.transform.position = spawn;
                //Debug.Log("Attempted to teleport back to spawn");
                break;
        }
    }
}