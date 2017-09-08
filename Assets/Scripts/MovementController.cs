using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovementController : MonoBehaviour
{
    int playerNumber;

    [SerializeField]
    float moveSpeed;
    Vector3 forward, right; // Keeps track of our relative forward and right vectors
    bool canMove = true; // tell the character if its allowed to waltz about all willy nilly
    bool canAttack = true;

    void Start()
    {
        playerNumber = this.GetComponentInParent<PlayerInfo>().playerNumber;

        forward = Camera.main.transform.forward; // Set forward to equal the camera's forward vector
        forward.y = 0; // make sure y is 0
        forward = Vector3.Normalize(forward); // make sure the length of vector is set to a max of 1.0
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward; // set the right-facing vector to be facing right relative to the camera's forward vector
    }

    void Update()
    {
        // move this character if we press a movement button
        if (Input.GetButton(GetComponentInParent<PlayerInfo>().horizontalKey) || Input.GetButton(GetComponentInParent<PlayerInfo>().verticalKey))
        {
                if (canMove == true)
			{
				Move();
				GetComponentInChildren<Animator>().SetTrigger("IsWalking");
			}
        }
        else GetComponent<Animator>().ResetTrigger("IsWalking");
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis(GetComponentInParent<PlayerInfo>().horizontalKey), 0, Input.GetAxis(GetComponentInParent<PlayerInfo>().verticalKey)); // setup a direction Vector based on keyboard input. GetAxis returns a value between -1.0 and 1.0. If the A key is pressed, GetAxis(HorizontalKey) will return -1.0. If D is pressed, it will return 1.0
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis(GetComponentInParent<PlayerInfo>().horizontalKey); // Our right movement is based on the right vector, movement speed, and our GetAxis command. We multiply by Time.deltaTime to make the movement smooth.
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis(GetComponentInParent<PlayerInfo>().verticalKey); // Up movement uses the forward vector, movement speed, and the vertical axis input           
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement); // This creates our new direction. By combining our right and forward movements and normalizing them, we create a new vector that points in the appropriate direction with a length no greater than 1.0
        //transform.forward = heading; // Sets forward direction of our game object to whatever direction we're moving in
        transform.position += rightMovement; // move our transform's position right/left
        transform.position += upMovement; // Move our transform's position up/down
    }

    public void SetCanMove()
    {
        canMove = true;
    }

    public void SetCannotMove()
    {
        canMove = false;
    }

    public void SetMovementSpeed()
    {
        moveSpeed = this.GetComponentInParent<CharacterInfoCollector>().characterSpeed;
    }
}
