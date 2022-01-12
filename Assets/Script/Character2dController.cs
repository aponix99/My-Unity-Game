
using System;
using UnityEngine;

public class Character2dController : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 15;
    public ProjectileBehavior ProjectilePrefab;
    public Transform LaunchOffset;
    private Rigidbody2D rigidbody;
    private Vector3 change;
    public Joystick joystick;
    public bool isJumping;
    public float movementHorizontal = 0f;
    public float movementVertical= 0f;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>(); //take x y position
    }

    // Update is called once per frame
    private void Update()
    {
        //var movement = Input.GetAxis("Horizontal");
        if (joystick.Horizontal >= 2f || joystick.Horizontal <= 2f)
        {
            movementHorizontal = joystick.Horizontal;
            transform.position += new Vector3(movementHorizontal, 0, 0) * Time.deltaTime * MovementSpeed;
        }
        movementVertical = joystick.Vertical;
        transform.position += new Vector3(0, movementVertical, 0)*Time.deltaTime*MovementSpeed;
        //movement = joystick.Vertical;
        //change = Vector3.zero;
        //change.x = joystick.Horizontal;
        //change.y = joystick.Vertical;
        // if (change != Vector3.zero)
        //   rigidbody.MovePosition(transform.position + change * MovementSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);

        }

    }


}
