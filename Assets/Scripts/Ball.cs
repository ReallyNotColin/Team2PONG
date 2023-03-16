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
    public float speed;
    public Vector2 dir;
    private Vector2 origPos;
    private int winning_score = 5;
    private AudioSource audioSrc;
    public GameObject exploPrefab;
    public GameObject startMenu;
    public GameObject gameRestart;
    public GameObject paddles;

    // Start is called before the first frame update

    public void Play()
    {
        // enable paddles and remove ui, initialize speed
        paddles.SetActive(true);
        startMenu.SetActive(false);
        gameRestart.SetActive(false);
        speed = 4;
        // initialize score to 0 and text on screen to 0
        scoreLeft = 0;
        scoreRight = 0;
        txtScoreLeft.text = "0";
        txtScoreRight.text = "0";
        StartGame();
    }

    void StartGame()
    {
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
        // if ball is about to score, slow down time scale
        if (transform.position[0] > 9 || transform.position[0] < -9)
        {
            Time.timeScale = 0.1f;
        }
    }

    void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.transform.tag.StartsWith("Paddle")){
            // reset the ball speed on collision
            if (speed > 8){
                speed = 4;
            }
            speed += 0.5f;
            // x direction reversed
            dir.x *= -1;
            audioSrc.clip = Resources.Load<AudioClip>("laserfire");
            audioSrc.Play();
        }
        else if (c.gameObject.CompareTag("TopBottom Boundary")){
            // y direction reversed 
            dir.y *= -1;
        }
        else if (c.gameObject.CompareTag("Left Boundary")){
            // reset the speed of the ball
            speed = 4;
            // create a particle  prefab
            var explo = Instantiate(exploPrefab, c.contacts[0].point, Quaternion.identity);
            Destroy(explo, 1f);
            scoreRight++;
            txtScoreRight.text = scoreRight.ToString();
            transform.position = origPos;
            // change the audio clip and play it
            audioSrc.clip = Resources.Load<AudioClip>("death");
            audioSrc.Play();
            // reset timescale

            if (Time.timeScale < 1)
            {
                Time.timeScale = 1;
            }

        }
        else if (c.gameObject.CompareTag("Right Boundary")){
            // reset the speed of the ball
            speed = 4;
            // create particle prefab
            var explo = Instantiate(exploPrefab, c.contacts[0].point, Quaternion.identity);
            Destroy(explo, 1f);
            // print("left scores");
            scoreLeft++;
            txtScoreLeft.text = scoreLeft.ToString();
            transform.position = origPos;
            // change the audio clip and play it
            audioSrc.clip = Resources.Load<AudioClip>("death");
            audioSrc.Play();
            // reset timescale
            if (Time.timeScale < 1)
            {
                Time.timeScale = 1;
            }
        }

        // win condition 
        if (scoreRight >= winning_score || scoreLeft >= winning_score)
        {
            // show the end screen, remove the baddles and set ball speed to 0
            gameRestart.SetActive(true);
            paddles.SetActive(false);
            speed = 0;
            transform.position = origPos;
        }

    }
}
