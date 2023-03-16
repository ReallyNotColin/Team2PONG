using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Vector2 dir;
    float timer = 5f;
    [SerializeField] // what is a serializedfield
    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.CompareTag("PaddleRight"))
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, Mathf.Abs(Mathf.Sin(Time.time)));
            // Movement 
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(-Vector3.up * speed * Time.deltaTime);
            }

            // A timer needs to exist in the Update() function.
            // This is a very scuffed version of a timer. Not generalized at all. Very hardcoded and specific.
            // Find a better way to create, activate, and deactivate abilities.
            if (transform.GetComponent<Paddle>().speed >= 9)
            {
                timer-=Time.deltaTime;
                if(timer < 0)
                {
                   transform.GetComponent<Paddle>().speed = 4;
                }
            }
        }
        else if (transform.CompareTag("PaddleLeft"))
        {
            GetComponent<SpriteRenderer>().color = new Color(Mathf.Abs(Mathf.Sin(Time.time)), 0, Mathf.Abs(Mathf.Sin(Time.time)));
            // Movement
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-Vector3.up * speed * Time.deltaTime);
            }

            // reset the paddle speed
            if (transform.GetComponent<Paddle>().speed >= 9)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    transform.GetComponent<Paddle>().speed = 4;
                }
            }
        }
    }
    
}
