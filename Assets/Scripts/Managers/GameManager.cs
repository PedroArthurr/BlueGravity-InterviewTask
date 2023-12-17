using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string userName;
    public DateTime dateTime;
    public bool playerCanInteract = true;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        userName = Environment.UserName;
        if (Environment.UserName == null)
            userName = "Username";
    }

    private void Update()
    {
        //Current date-time because why not? :P
        dateTime = DateTime.Now;
    }
}