
using UnityEngine;

public class Character2dController : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 15;

    private Rigidbody2D rigidbody;
    public Joystick joystick;
    float movement = 0f;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>(); //take x y position
    }

    // Update is called once per frame
    private void Update()
    {
        //var movement = Input.GetAxis("Horizontal");
        movement = joystick.Horizontal;
        transform.position += new Vector3(movement, 0, 0)*Time.deltaTime * MovementSpeed;
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = new Vector2(0f, 5f);

        }

    }
}
