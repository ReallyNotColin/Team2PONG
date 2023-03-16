using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    // UI TEXT
    public TextMeshProUGUI txtScoreLeft;
    public TextMeshProUGUI txtScoreRight;

    private int scoreLeft;
    private int scoreRight;
    

    // VARIABLES 
    public float speed = 4;
    public Vector2 dir;
    private Vector2 origPos;
    private int winning_score = 11;
    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        // initialize score to 0 and text on screen to 0
        scoreLeft = 0;
        scoreRight = 0;
        txtScoreLeft.text = "0";
        txtScoreRight.text = "0";
        origPos = transform.position;
        // generate a random integer to decide the direction of the ball
        float result = Random.Range(0f, 1f);
        if (result < 0.5) {
            dir = Vector2.left;
        }
        else {
            dir = Vector2.right;
        }
        result = Random.Range(0f, 1f);
        if (result < 0.5) {
            dir.y = 1;
        }
        else {
            dir.y = -1;
        }
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        if (transform.position[0] > 9 || transform.position[0] < -9)
        {
            Time.timeScale = 0.1f;
        }
    }

    void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.transform.tag.StartsWith("Paddle")){
            // x direction reversed
            // reset the ball speed on collision
            if (speed > 4){
                speed = 4;
            }
            dir.x *= -1;
            audioSrc.clip = Resources.Load<AudioClip>("laserfire");
            audioSrc.Play();
        }
        else if (c.gameObject.CompareTag("TopBottom Boundary")){
            // y direction reversed 
            dir.y *= -1;
        }
        else if (c.gameObject.CompareTag("Left Boundary")){
            if (speed > 4){ 
                speed = 4;
            }
            scoreRight++;
            txtScoreRight.text = scoreRight.ToString();
            transform.position = origPos;
            // change the audio clip and play it
            audioSrc.clip = Resources.Load<AudioClip>("death");
            audioSrc.Play();
            if (Time.timeScale < 1)
            {
                Time.timeScale = 1;
            }

        }
        else if (c.gameObject.CompareTag("Right Boundary")){
            if (speed > 4){
                speed = 4;
            }
            // print("left scores");
            scoreLeft++;
            txtScoreLeft.text = scoreLeft.ToString();
            transform.position = origPos;
            // change the audio clip and play it
            audioSrc.clip = Resources.Load<AudioClip>("death");
            audioSrc.Play();
            if (Time.timeScale < 1)
            {
                Time.timeScale = 1;
            }
        }
        // IF RIGHT PADDLE WINS
        if (scoreRight >= winning_score && scoreLeft < winning_score)
        {
            Time.timeScale = 0; // stops time ; freezes game 
            txtScoreRight.text = ("Winner!  " + scoreRight).ToString();
            txtScoreLeft.text = ("Loser!    " + scoreLeft).ToString();

        }
        // IF LEFT PADDLE WINS 
        if (scoreRight < winning_score && scoreLeft >= winning_score)
        {
            Time.timeScale = 0; // stops time ; freezes game 
            txtScoreRight.text = ("Loser!   " + scoreRight).ToString();
            txtScoreLeft.text = ("Winner!   " + scoreLeft).ToString();
        }
    }
}
