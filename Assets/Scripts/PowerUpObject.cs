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
                Destroy(gameObject);

                powerup.Apply(paddleScript.gameObject); // Calls PowerAbstract.cs
            }
        }
    }


}
