using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [Header("Objects With Rotation")]
    [SerializeField] private bool isRotation;
    [SerializeField] private float ballRotationSpeed;
    

    [Header("Objects With Movement")]
    [SerializeField] private bool isMoving;

    private Vector3 startPosition;
    private float movementeFacor;
    [SerializeField] private Vector3 movementVector;
    [SerializeField] private float period;

    

    // Start is called before the first frame update
    void Start()
    {
        SetObjectMovementPosition();
    }

    // Update is called once per frame
    void Update()
    {
        SetBallRotation();
        SetObjectMovement();
    }


    //Creating the rolling effect to the ball
    private void SetBallRotation()
    {
        if (isRotation)
        {
            transform.Rotate(Vector3.right * ballRotationSpeed * Time.deltaTime);
        }
    }


    //Getting the first position to the oscillation effect
    private void SetObjectMovementPosition()
    {
        if (isMoving)
        {
            startPosition = transform.position;
        }
    }

    //Oscillation Effect Settings
    private void SetObjectMovement()
    {
        if(isMoving)
        {
            if(period <= Mathf.Epsilon) { return; }
            float cycles = Time.time / period;
            const float tau = Mathf.PI * 2;
            float rawSinWave = Mathf.Sin(cycles * tau);

            movementeFacor = (rawSinWave + 1f) / 2f;
            Vector3 offSet = movementVector * movementeFacor;
            transform.position = startPosition + offSet;
        }
    }

    //Setting up the obstacles collision
    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            switch(other.gameObject.tag)
            {
                case "Ground":
                    Debug.Log("Ball on the ground");
                    //Call the ground effect
                break;

                case "Player":
                    Debug.Log("Hit the player");
                    //Call the gameover and restart the game
                break;
            }
        }
    }

}
