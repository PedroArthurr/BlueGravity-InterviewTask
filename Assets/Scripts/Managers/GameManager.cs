using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string userName;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Application.targetFrameRate = 60;
        userName = Environment.UserName;
        print(userName);
        if (Environment.UserName == null)
            userName = "Username";
    }
}
