using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player 1 Movement script
public class Player1Controller: MonoBehaviour
{
    //Setting the wheel colliders for player 1
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    //Setting the wheel transform for player 1
    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    //Setting the attributes of the car for player 1
    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 35f;

    //Current state of the cars movement for player 1
    private float currentacceleration = 0f;
    private float currentbreakingForce = 0f;
    private float currentTurnAngleLeft = 0f;
    private float currentTurnAngleRight = 0f;

    private void FixedUpdate()
    {
        //Player 1 forward and reverse movement
        if (Input.GetKey(KeyCode.W)) currentacceleration = -acceleration * 1 * Time.deltaTime *100;
        if (Input.GetKey(KeyCode.S)) currentacceleration = acceleration * 1 * Time.deltaTime * 100;

        //Player 1 brakes
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentbreakingForce = breakingForce*100;
        } else {
            currentbreakingForce = 0f;
        }

        //Applying acceleration for player 1
        frontRight.motorTorque = currentacceleration;
        frontLeft.motorTorque = currentacceleration;

        //Applying brake to all 4 wheels of player 1
        frontRight.brakeTorque = currentbreakingForce;
        frontLeft.brakeTorque = currentbreakingForce;
        backRight.brakeTorque = currentbreakingForce;
        backLeft.brakeTorque = currentbreakingForce;

        //Player 1 turn left
        if (Input.GetKey(KeyCode.A)) {
            currentTurnAngleLeft = -maxTurnAngle * 1; 
        } else {
            currentTurnAngleLeft = 0f; 
        }

        //Player 1 turn right
        if (Input.GetKey(KeyCode.D))
        {
            currentTurnAngleRight = maxTurnAngle * 1;
        } else {
            currentTurnAngleRight = 0f;
        }

        frontLeft.steerAngle = currentTurnAngleLeft;
        frontRight.steerAngle = currentTurnAngleRight;
    }

}