using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player 2 Movement script
public class Player2Controller: MonoBehaviour
{
    //Setting the wheel colliders for player 2
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    //Setting the wheel transform for player 2
    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    //Setting the attributes of the car for player 2
    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 35f;

    //Current state of the cars movement for player 2
    private float currentacceleration = 0f;
    private float currentbreakingForce = 0f;
    private float currentTurnAngleLeft = 0f;
    private float currentTurnAngleRight = 0f;

    private void FixedUpdate()
    {
        //Player 2 forward and reverse movement
        if (Input.GetKey(KeyCode.UpArrow)) currentacceleration = -acceleration * 1 * Time.deltaTime *100;
        if (Input.GetKey(KeyCode.DownArrow)) currentacceleration = acceleration * 1 * Time.deltaTime * 100;

        //Player 2 brakes
        if (Input.GetKey(KeyCode.RightShift))
        {
            currentbreakingForce = breakingForce*100;
        } else {
            currentbreakingForce = 0f;
        }

        //Applying acceleration for player 2
        frontRight.motorTorque = currentacceleration;
        frontLeft.motorTorque = currentacceleration;

        //Applying brake to all 4 wheels of player 2
        frontRight.brakeTorque = currentbreakingForce;
        frontLeft.brakeTorque = currentbreakingForce;
        backRight.brakeTorque = currentbreakingForce;
        backLeft.brakeTorque = currentbreakingForce;

        //Player 2 turn left
        if (Input.GetKey(KeyCode.LeftArrow)) {
            currentTurnAngleLeft = -maxTurnAngle * 1; 
        } else {
            currentTurnAngleLeft = 0f; 
        }

        //Player 2 turn right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentTurnAngleRight = maxTurnAngle * 1;
        } else {
            currentTurnAngleRight = 0f;
        }

        frontLeft.steerAngle = currentTurnAngleLeft;
        frontRight.steerAngle = currentTurnAngleRight;
    }

}