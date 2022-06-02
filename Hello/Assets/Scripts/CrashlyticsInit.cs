using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Import Firebase
//using Firebase;
using UnityEngine.UI;

public class CrashlyticsInit : MonoBehaviour {
    public Text label;
    private string msg;
    public Button init;
    public Button crash;
    private bool isSafe;

    private void Awake()
    {
        init.onClick.AddListener(() => Init());
        crash.onClick.AddListener(() => CrashTest());
    }

    // Use this for initialization
    void Start () {
        // Initialize Firebase
        //Init();
    }

    private void Update()
    {
        this.label.text = isSafe + "   " + msg;
    }

    private void Init()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            msg = "11111111";
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                // Crashlytics will use the DefaultInstance, as well;
                // this ensures that Crashlytics is initialized.
                Firebase.FirebaseApp.LogLevel = Firebase.LogLevel.Debug;
                Firebase.FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;
                // Set a flag here for indicating that your project is ready to use Firebase.

                msg = "firebase Available";
                isSafe = true;
            }
            else
            {
                msg = dependencyStatus.ToString();
                isSafe = false;
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    private void CrashTest()
    {
        throw new System.Exception("test exception please ignore");
    }
}
