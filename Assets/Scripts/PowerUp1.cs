
using UnityEngine;

// COLIN: Make this more general. An Abstract Class? 
public class PowerUp1 : MonoBehaviour
{
    public float speed_Increase = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag.StartsWith("Paddle"))
        {
            GameObject paddle = collision.gameObject;

            Paddle paddleScript = paddle.GetComponent<Paddle>();

            if (paddleScript)
            {
               paddleScript.speed += speed_Increase;

                Destroy(gameObject);
                
                
             
                
               
            }
        }
    }
   
}
