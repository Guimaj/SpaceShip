using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Transform LaserInitialPosition;
    public GameObject destroyAnimation;
    public GameObject enemyLaser;
    private GameObject score;

    // Start is called before the first frame update
    void Start()
    {
       Invoke("shoot", 1f);
       this.score = GameObject.FindGameObjectWithTag("ScoreText");
       Invoke("destroyGameObject", 7f);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        Vector2 shootPosition = transform.position;
        shootPosition.x -= speed * Time.deltaTime;
        transform.position = shootPosition;
    }

    void shoot()
    {    
        Instantiate(enemyLaser, LaserInitialPosition.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
        Invoke("shoot", 2f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ShipLaser" || collider.gameObject.tag == "Ship")
        {    
            playDestroyAnimation();
            this.score.GetComponent<GameScore>().Score += 1;

            if (collider.gameObject.tag == "ShipLaser")
            {
                Destroy(collider.gameObject);
            }

            Destroy(this.gameObject);          
        }
    }

    void playDestroyAnimation()
    {
        GameObject explosion = (GameObject)Instantiate(destroyAnimation);
        explosion.transform.position = transform.position;
    }

    void destroyGameObject()
    {
        Destroy(this.gameObject);
    }
}
