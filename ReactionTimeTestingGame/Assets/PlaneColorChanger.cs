using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColorChanger : MonoBehaviour
{

    float roundStartTime;
    float waitTime;
    bool startedFlag = false;
    Renderer myPlaneRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myPlaneRenderer = GetComponent<Renderer>();
        changeColorToRed();
        print("Press Enter to start.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && startedFlag == false)
        {
            startRoutine();
        }

        else if (Input.GetKeyDown(KeyCode.Space) && startedFlag == true)
        {
            pressSpaceRoutine();
        }
        /*
        else {

            print("Please press enter to start.");
        
        }
        */
    }

    void SetRandomTime()
    {
        waitTime = Random.Range(2, 11);
        roundStartTime = Time.time;
        print(waitTime + " seconds.");
    }

    void changeColorToGreen()
    {
        myPlaneRenderer.material.color = Color.green;
    }

    void changeColorToRed()
    {
        myPlaneRenderer.material.color = Color.red;
    }

    void changeColorToBlue()
    {
        myPlaneRenderer.material.color = Color.blue;
    }

    void startRoutine()
    {
        print("Starting game.");
        changeColorToRed();
        SetRandomTime();
        startedFlag = true;
        print("Hit Spacebar when the color changes to green.");
        Invoke("changeColorToGreen", waitTime);
    }

    void pressSpaceRoutine()
    {
        float reactionTimeTaken = Time.time - roundStartTime - waitTime;
        if (reactionTimeTaken < 0)
        {
            CancelInvoke("changeColorToGreen");
            print("Pressed too early");
            startedFlag = false;
            changeColorToBlue();
            print("Press Enter to go again.");
        }
        else
        {
            CancelInvoke("changeColorToGreen");
            print("Reaction time: " + reactionTimeTaken);
            startedFlag = false;
            changeColorToRed();
            print("Press Enter to go again.");
        }
    }

}
