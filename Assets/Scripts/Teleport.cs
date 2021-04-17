using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //hard coded coordinates of teleport points
    public Vector3 spymaster = new Vector3(-4.053f, .25f, -36.198f);
    public Vector3 spawn = new Vector3(-.451156f, .25f, 1.286f);
    public CharacterController cc;

    void Start()
    {
        //cc = GetComponent<CharacterController>();
    }

    public void tp(string btnName)
    {
        switch (btnName)
        {
            case "spymaster":
                cc.enabled = false;
                transform.position = spymaster;
                cc.enabled = true;
                Debug.Log("Attempted to teleport to spymaster view");
                break;
            case "spawn":
                cc.enabled = false;
                transform.position = spawn;
                cc.enabled = true;
                Debug.Log("Attempted to teleport back to spawn");
                break;
        }
    }
}