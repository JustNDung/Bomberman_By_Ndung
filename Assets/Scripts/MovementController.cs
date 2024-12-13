using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rb2D {get; private set;}
    private Vector2 direction;
    public float movementSpeed = 5f;
    
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(moveUp))
        {
            SetDirection(Vector2.up);
        } 
        else if (Input.GetKey(moveDown))
        {
            SetDirection(Vector2.down);
        } 
        else if (Input.GetKey(moveLeft))
        {
            SetDirection(Vector2.left);
        }
        else if (Input.GetKey(moveRight))
        {
            SetDirection(Vector2.right);
        }
        else
        {
            SetDirection(Vector2.zero);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rb2D.position;
        Vector2 translation = direction * movementSpeed * Time.fixedDeltaTime;
        
        rb2D.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
        //...
    }
    
    
}
