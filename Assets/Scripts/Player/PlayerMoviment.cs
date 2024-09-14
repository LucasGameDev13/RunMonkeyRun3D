using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private Rigidbody playerRig;
    [SerializeField] private float horizontalRotationSpeed;
    [SerializeField] private float horizontalPlayerSpeed;
    [SerializeField] private float jumpingForce;
    [SerializeField] private float playerGravity;
    private bool isMoving;
    private bool isJumping;
    
    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }

    public bool IsJumping
    {
        get { return isJumping; }
        set { isJumping = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotation();
        PlayerMovement();
        PlayerJumping();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetPlayerMovement(horizontalPlayerSpeed);
        }
        else
        {
            isMoving = false;
        }
    }

    private void PlayerJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            playerRig.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);
            Physics.gravity = new Vector3(0, playerGravity, 0);
            isJumping = true;
            
        }
    }

    private void PlayerRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetPlayerRotation(horizontalRotationSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GetPlayerRotation(-horizontalRotationSpeed);
        }
        else
        {
            isMoving = false;
        }
    }

    private void GetPlayerMovement(float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        isMoving = true;
    }

    private void GetPlayerRotation(float _speed)
    {
        playerRig.freezeRotation = true;
        transform.Rotate(Vector3.up *  _speed * Time.deltaTime);
        isMoving = true;
        playerRig.freezeRotation = false;
    }
}
