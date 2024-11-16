using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody2D rigidBody;
    public float speed;
    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.linearVelocity = new Vector2(0, 0);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigidBody.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigidBody.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rigidBody.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigidBody.AddForce(Vector2.down * speed, ForceMode2D.Impulse); 
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            rigidBody.linearVelocity = new Vector2(0, 0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            Debug.Log("Level Completed");
        }
        
    }
}
