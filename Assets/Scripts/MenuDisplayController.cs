﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDisplayController : MonoBehaviour
{
    private float distance = 1.5f;
    private Canvas menu;
    private static MODE mode;
    public static MODE Mode { get => mode; }
    public enum MODE
    {
        NONE = 0,
        ROTATE_MODE = 1,
        MOVE_MODE = 2,
        COLOR_MODE = 3
    }
    void Start()
    {
        menu = GetComponent<Canvas>();
        menu.enabled = false;
    }

    public void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            //set up the menu position
            menu.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
            menu.transform.rotation = Camera.main.transform.rotation;
            //make menu visible
            menu.enabled = true;
        }
    }

    public void OnBtnClick(string btnName)
    {
        switch (btnName)
        {
            case "rotate":
                mode = MODE.ROTATE_MODE;
                break;
            case "move":
                mode = MODE.MOVE_MODE;
                break;
            case "click":
                mode = MODE.COLOR_MODE;
                break;
            case "clear":
                mode = MODE.NONE;
                break;
            default:
                break;
        }
        menu.enabled = false;
    }
}