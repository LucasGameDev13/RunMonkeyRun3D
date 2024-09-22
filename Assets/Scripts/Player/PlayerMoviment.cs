using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private TimeLineController timeLineController;
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

    private void Awake()
    {
        timeLineController = FindObjectOfType<TimeLineController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRig = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLineController.IsAlive)
        {
            PlayerRotation();
            PlayerMovement();
            PlayerJumping();
            PlayerFreezeRotations();
        }
    }


    //Front Movement Mechanics
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

    //Jump Mechanics
    private void PlayerJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            playerRig.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);
            Physics.gravity = new Vector3(0, playerGravity, 0);
            isJumping = true;
            
        }
    }

    //Rotation Mechanics
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


    //Getting the player movement
    private void GetPlayerMovement(float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        isMoving = true;
    }

    //Getting the player rotation
    private void GetPlayerRotation(float _speed)
    {
        playerRig.freezeRotation = true;
        transform.Rotate(Vector3.up *  _speed * Time.deltaTime);
        isMoving = true;
        playerRig.freezeRotation = false;
    }

    //Keeping player static to not rotate automatically
    private void PlayerFreezeRotations()
    {
        playerRig.constraints = RigidbodyConstraints.FreezeRotationX |
                                RigidbodyConstraints.FreezeRotationY | 
                                RigidbodyConstraints.FreezeRotationZ;
    }
}
