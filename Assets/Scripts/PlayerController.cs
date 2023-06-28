using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmt = 1f;
    [SerializeField] float regularSpeed = 10f;
    [SerializeField] float boostSpeed = 30f;
    Rigidbody2D rb2d;
    SurfaceEffector2D se2d;

    bool controlsEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        se2d = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlsEnabled) {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls() {
        controlsEnabled = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            se2d.speed = boostSpeed;
        }
        else {
            se2d.speed = regularSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmt);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmt);
        }
    }
}
