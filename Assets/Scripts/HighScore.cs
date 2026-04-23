using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighScore : MonoBehaviour
{
    public static int highScore = 100;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
        {
            highScore = PlayerPrefs.GetInt("ApplePickerHightScore");
        }
        PlayerPrefs.SetInt("ApplePickerHighScore", highScore);
    }
    private void Start()
    {
        TextMeshProUGUI highScoreText = this.GetComponent<TextMeshProUGUI>();
        highScoreText.text =highScore.ToString();
    }

    private void Update()
    {
        TextMeshProUGUI highScoreText = this.GetComponent<TextMeshProUGUI>();
        highScoreText.text = highScore.ToString();

        if (highScore > PlayerPrefs.GetInt("ApplePickerHighScore"))
            PlayerPrefs.SetInt("ApplePickerHighScore", highScore);
    }
}
