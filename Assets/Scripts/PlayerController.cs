using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody2D rigidBody;
    public float speed;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigidBody.linearVelocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigidBody.linearVelocity = new Vector2(-speed, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rigidBody.linearVelocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigidBody.linearVelocity = new Vector2(0f, -speed); 
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            rigidBody.linearVelocity = new Vector2(0f, 0f);
        }
        
    }
}
