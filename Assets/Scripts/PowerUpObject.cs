using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Template to destroy a power up object and apply its effect
// COLIN: Will these effects stack? How will we spawn these effects? 
public class PowerUpObject : MonoBehaviour
{
    public Powerup powerup; // Calls PowerAbstract.cs
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag.StartsWith("Paddle"))
        {
            GameObject paddle = collision.gameObject;

            Paddle paddleScript = paddle.GetComponent<Paddle>();

            if (paddleScript)
            {
                // move the powerup off the screen
                transform.position = new Vector3(6, 7, 0);
                powerup.Apply(paddleScript.gameObject); // Calls PowerAbstract.cs
            }
        }
        if (collision.gameObject.transform.tag.StartsWith("Ball"))
        {
            GameObject ball = collision.gameObject;
            Ball ballScript = ball.GetComponent<Ball>();

            if (ballScript)
            {
                // move the powerup off the screen
                transform.position = new Vector3(6, 7, 0); 
                powerup.Apply(ballScript.gameObject); // Calls PowerAbstract.cs
            }
        }

         
    }
    void Start()
    {

    }

    void Update()
    {
        int randomPowerUp = Random.Range(0, 10000);
        if (randomPowerUp == 5000)
        {
            // pick a location to spawn the powerup
            int selectPowerUp = Random.Range(0, 3);
            if (selectPowerUp == 0) {
                transform.position = new Vector3(7.4f, 4, 0);
            }
            else if (selectPowerUp == 1) {
                transform.position = new Vector3(-7.2f, -4, 0);
            }
            else if (selectPowerUp == 2){
                transform.position = new Vector3(0, 4, 0);
            }


        }
    }
}
