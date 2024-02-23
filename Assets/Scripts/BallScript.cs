using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BallScript : MonoBehaviour
{
    
    public float minY = -5.5f;
    public float ballForce = 500f;
    public Transform explosion;
    public UiManager ui;
    public AudioSource audioPlayer;

    bool gameHasEnded = false;
    public float restartDelay = 5f;
    public GameObject gameOverUI;

    Rigidbody2D rb;
    bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        ui = GameObject.FindWithTag("ui").GetComponent<UiManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && gameStarted == false)
        {
            transform.SetParent (null);
            rb.isKinematic = false;

            rb.AddForce(new Vector2(ballForce, ballForce));
            gameStarted = true;
        }
        

        if (transform.position.y < minY)
        {
            EndGame();
        }
        
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            audioPlayer.Play();
            ui.IncrementScore();
            Destroy(collision.gameObject);
            GameManager.Instance.BrickDestroyed();
        }
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
            gameOverUI.SetActive(true);

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 01");
    }

}
