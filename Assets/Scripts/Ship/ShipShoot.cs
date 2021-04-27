using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyGameObject", 7);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        Vector2 shootPosition = transform.position;
        shootPosition.x += speed * Time.deltaTime;
        transform.position = shootPosition;
    }

    void destroyGameObject ()
    {
        Destroy(this.gameObject);
    }

    public float GetSpeed()
    {
        return this.speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
