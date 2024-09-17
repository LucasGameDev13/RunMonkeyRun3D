using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private float ballRotationSpeed;
    [SerializeField] private bool isRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetBallRotation();
    }


    //Creating the rolling effect to the ball
    private void SetBallRotation()
    {
        if (isRotation)
        {
            transform.Rotate(Vector3.right * ballRotationSpeed * Time.deltaTime);
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
