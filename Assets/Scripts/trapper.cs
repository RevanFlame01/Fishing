using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trapper : MonoBehaviour
{
    private int score;
    public Text scoreText;

    private int distPrice = 50;
    private int speedPrice = 50;

    public Text distPriceText;
    public Text speedPriceText;

    public GameObject panel;

    public BoxCollider2D rb;
    public static int caught;

    public AudioSource _audio;

    public GameObject TutorialPanel;
    public GameObject MenuPanel;
    public int tutorialNum;

    void Start()
    {
       score = PlayerPrefs.GetInt("score", score);
       distPrice = PlayerPrefs.GetInt("distPrice", distPrice);
       speedPrice = PlayerPrefs.GetInt("speedPrice", speedPrice);
       tutorialNum = PlayerPrefs.GetInt("Tutorial", tutorialNum);
       if (tutorialNum == 1)
       {
           MenuPanel.SetActive(true);
       }

     //  tutorialNum = 0;
    }

    
    void Update()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("distPrice", distPrice);
        PlayerPrefs.SetInt("speedPrice", speedPrice);
        PlayerPrefs.SetInt("Tutorial",tutorialNum);
        
        scoreText.text = "Score: " + score;
       // distPriceText.text = "Price: " + distPrice;
       // speedPriceText.text = "Price: " + speedPrice;

        if (caught == 3)
        {
            rb.gameObject.SetActive(false);
        }

        if (tutorialNum == 1)
        {
            TutorialPanel.SetActive(false);
        }

        if (tutorialNum == 0)
        {
            TutorialPanel.SetActive(true);
        }

        if (score < distPrice)
        {
            distPriceText.text = "Cannot be purchased";
        }
        else
        {
            distPriceText.text = "Price: " + distPrice;
        }

        if (score < speedPrice)
        {
            speedPriceText.text = "Cannot be purchased";
        }
        else
        {
            speedPriceText.text = "Price: " + speedPrice;
        }
    }

    public void DistPrice()
    {
        if (score >= distPrice)
        {
            score -= distPrice;
            distPrice += 50;
            hook.maxDistance += 0.2f;
        }
    }
    public void SpeedPrice()
    {
        if (score >= speedPrice)
        {
            score -= speedPrice;
            speedPrice += 50;
            hook.moveSpeed += 0.2f;
        }
    }

    public void LVLON()
    {
        panel.gameObject.SetActive(true);
        //Time.timeScale = 0;
    }
    public void LVLOFF()
    {
        panel.gameObject.SetActive(false);
       // Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audio.Play();
        caught = 0;
        rb.gameObject.SetActive(true);
        if (collision.gameObject.CompareTag("10"))
        {
            score += 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("15"))
        {
            score += 15;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("20"))
        {
            score += 20;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("30"))
        {
            score += 30;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("40"))
        {
            score += 40;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("50"))
        {
            score += 50;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("100"))
        {
            score += 100;
            Destroy(collision.gameObject);
        }

    }
}
