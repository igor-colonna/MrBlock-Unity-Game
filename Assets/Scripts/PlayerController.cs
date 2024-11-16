using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody2D rigidBody;
    public float speed;
    public GameObject gameWonPanel;
    public GameObject gamePausePanel;
    public GameObject gameLosePanel;

    private bool isGameOver = false;
    
    void FixedUpdate()
    {
        if (isGameOver)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            gamePausePanel.SetActive(true);
            Time.timeScale = 0;
        }
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
            gameWonPanel.SetActive(true);
            isGameOver = true;
            Debug.Log("Level Completed");
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            gameLosePanel.SetActive(true);
            Debug.Log("Level Lost");
            isGameOver = true;
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResumeGame()
    {
        gamePausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
