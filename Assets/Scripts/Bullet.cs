﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    //base speed for bullet
    public float speed = 30;
    //private int counter = 0;
    private Rigidbody2D rigidBody;
    //public GameManager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        //get reference to the Rigidbody for the bullet
        rigidBody = GetComponent<Rigidbody2D>();

        //when bullet is created, it will move upward at the "speed"
        rigidBody.velocity = Vector2.up * speed;
    }

    //everytime the bullet collides it will call this
    void OnTriggerEnter2D(Collider2D col)
    {
        //if bullet hits a wall then it destroy the bullet
        if (col.tag == "Wall")
        {
            Destroy(gameObject);
        }

        //if bullet hits enemy, then increase score and destroy bullet and enemy
        if (col.tag == "Enemy")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.enemyDies);

            IncreaseScoreText();

            Destroy(gameObject);

            col.gameObject.GetComponent<Enemy>().Die();

        }

        //if bullet hits enemy of level 2, then increase score and destroy bullet and enemy
        if (col.tag == "Enemy2")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.enemyDies);

            IncreaseScoreText();

            Destroy(gameObject);

            col.gameObject.GetComponent<Enemy2>().Die();

        }

        //if bullet hits enemy of level 3, then increase score and destroy bullet and enemy
        if (col.tag == "Enemy3")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.enemyDies);

            IncreaseScoreText();

            Destroy(gameObject);

            col.gameObject.GetComponent<Enemy3>().Die();

        }

        //if bullet hits enemy of level 4, then increase score and destroy bullet and enemy
        if (col.tag == "Enemy4")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.enemyDies);

            IncreaseScoreText();

            Destroy(gameObject);

            col.gameObject.GetComponent<Enemy4>().Die();

        }

        if (col.tag == "Books")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.enemyDies);

            IncreaseScoreText();

            Destroy(gameObject);

            Destroy(col.gameObject, 0);
        }


    }

    //when bullet isn't used will call this and make invisible
    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }

    //increased the score in the text UI when called
    void IncreaseScoreText()
    {
        //find the text Score UI component
        var scoreTextComp = GameObject.Find("Score").GetComponent<Text>();
       
        //get string store in the text and covert into a int
        int score = int.Parse(scoreTextComp.text);

        score += 5;

        //PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("highscore") + 5);

        //gamemanager.score += 5;

        //covert the int score back into a string to update the text UI
        scoreTextComp.text = score.ToString();
    }
}
