using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public GameObject shipLaser;
    public GameObject destroyAnimation;
    public GameObject gameManager;
    private GameObject score;
    public float speed;
    public Vector2 minPositions;
    public Vector2 maxPositions;
    public Transform laserInitialPosition;
    public int maxLifes;
    private int currentLifes;
    public Text livesText;
    public Text scoreText;
    public float delayShoot;
    private float shootTimer;
    private bool canShoot = true;
    
    public void Start()
    {
        this.score = GameObject.FindGameObjectWithTag("ScoreText");
    }

    public void Init()
    {
        this.currentLifes = maxLifes;
        this.livesText.text = currentLifes.ToString();
        this.transform.position = new Vector2(0f, 0f);
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = getInputAxis();
        powerUpUnlocked();
        move(direction);
        shoot();
        
    }


    Vector2 getInputAxis()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        return new Vector2(x, y).normalized;
    }

    void move(Vector2 direction)
    {
        Vector2 shipPosition = transform.position;

        shipPosition += direction * speed * Time.deltaTime;

        if (shipPosition.x > this.maxPositions.x || shipPosition.y > this.maxPositions.y)
        {
            if (shipPosition.x > this.maxPositions.x)
            {
                shipPosition.x = this.maxPositions.x;
            }
            if (shipPosition.y > this.maxPositions.y)
            {
                shipPosition.y = this.maxPositions.y;
            }
        }
        if (shipPosition.x < this.minPositions.x || shipPosition.y < this.minPositions.y)
        {
            if (shipPosition.x < this.minPositions.x)
            {
                shipPosition.x = this.minPositions.x;
            }
            if (shipPosition.y < this.minPositions.y)
            {
                shipPosition.y = this.minPositions.y;
            }    
        }
      
        transform.position = shipPosition;
    }

    void shoot()
    {

        shootTimer += Time.deltaTime;

        if(shootTimer >= delayShoot)
        {
            canShoot = true;
        }

        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Instantiate(shipLaser, laserInitialPosition.position, Quaternion.identity);
                GetComponent<AudioSource>().Play();
                canShoot = false;
                shootTimer = 0f;
            }
        }  
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "EnemyLaser" || collider.gameObject.tag == "Enemy")
        {
            updateLife();
            isGameOver(this.currentLifes);
            Destroy(collider.gameObject);
        }
    }

    void playDestroyAnimation()
    {
        GameObject explosion = (GameObject)Instantiate(destroyAnimation);
        explosion.transform.position = transform.position;
    }

    void powerUpUnlocked()
    {
        if (this.score.GetComponent<GameScore>().Score > 20)
        {
            this.speed = 350f;
            this.shipLaser.GetComponent<ShipShoot>().SetSpeed(350f);
        }
    }

    void updateLife()
    {
        this.currentLifes = this.currentLifes - 1;
        this.livesText.text = this.currentLifes.ToString();
    }

    void isGameOver(int lives)
    {
        if (lives == 0)
        {
            this.gameManager.GetComponent<GameManager>().setGameState(GameManager.GameState.GameOver);
            playDestroyAnimation();
            this.gameObject.SetActive(false);
        }
    }
}
