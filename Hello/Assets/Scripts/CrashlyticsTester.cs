using System;
using UnityEngine;
using UnityEngine.UI;

public class CrashlyticsTester : MonoBehaviour
{

    public Text label;
    int updatesBeforeException;

    // Use this for initialization
    void Start () {
      updatesBeforeException = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Call the exception-throwing method here so that it's run
        // every frame update
        throwExceptionEvery60Updates();
    }

    private int times = 1;
    // A method that tests your Crashlytics implementation by throwing an
    // exception every 60 frame updates. You should see non-fatal errors in the
    // Firebase console a few minutes after running your app with this method.
    void throwExceptionEvery60Updates()
    {
        if (updatesBeforeException > 0)
        {
            updatesBeforeException--;
        }
        else
        {
            // Set the counter to 60 updates
            updatesBeforeException = 60;

            ++times;
            label.text = times.ToString();
            // Throw an exception to test your Crashlytics implementation
            
            GameObject err = null;
            err.SetActive(false);
            //throw new System.Exception("test exception please ignore");
        }
    }
}