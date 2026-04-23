using System;
using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        GameObject scoreTextObj = GameObject.Find("ScoreCounter");
        
          
        scoreText = scoreTextObj.GetComponent<TextMeshProUGUI>();
        scoreText.text = "0";
    }
    private void Update()
    {
        // Get current screen position of the mouse
        Vector3 mousePos2d = Input.mousePosition;
        mousePos2d.z = -Camera.main.transform.position.z;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousePos2d);

        Vector3 pos = this.transform.position;
        pos.x = mousePosition.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collideWith = collision.gameObject;
        if (collideWith.CompareTag("Apple"))
        {
            Destroy(collideWith);
        }

        int score = int.Parse(scoreText.text);
        score += 100;
        scoreText.text = score.ToString();

        if (score > HighScore.highScore)
            HighScore.highScore = score;
    }
}
