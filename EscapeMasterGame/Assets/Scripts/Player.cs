using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //variables

    Vector3 playerVelocity;

    public float moveSpeed = 7;

    Rigidbody rB;
    
    bool disabled;

    public event System.Action OnReachedEndOfLevel;

    void Start()
    {
        // get the rigid body component
        rB = GetComponent<Rigidbody>();
        // register the disable method to the action event
        Guard.OnGuardHasSpottedPlayer += Disable;

    }

    // Update is called once per frame
    void Update()
    {
        // get movement inputs only if the player is not caught

        Vector3 inputDirection = Vector3.zero;
        if (!disabled) {
            inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        }
        playerVelocity = inputDirection * moveSpeed;
        transform.Translate(playerVelocity * Time.deltaTime);  

    }
 
    void OnDestroy() { 
    
        // unsubscribe the disable method from the action event
        Guard.OnGuardHasSpottedPlayer -= Disable;
    }
    void Disable()
    {
        disabled = true;
    }
    void OnTriggerEnter(Collider hitCollider)
    {
        // check if the player has reached the end of the level
        if (hitCollider.tag == "Finish")
        {
            Disable();
            // display end of level GUI
            if (OnReachedEndOfLevel != null)
            {
                OnReachedEndOfLevel();
            }

        }
    }
}
