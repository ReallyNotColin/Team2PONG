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
            // make a new paddle game object
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
            // make a new ball game object
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
 
    void Update()
    {
        // create a random int to decide if a powerup should spawn
        int randomPowerUp = Random.Range(0, 5000);
        if (randomPowerUp == 2500)
        {
                transform.position = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0);
        }
    }
}
