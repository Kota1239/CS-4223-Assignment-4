using UnityEngine;
using TMPro;

public class UpdateHighscore : MonoBehaviour
{
    public TMP_Text highscoreText;
    public string tooltip;

    void Start()
    {
        if (PlayerPrefs.HasKey("highscore")) highscoreText.text = tooltip + PlayerPrefs.GetInt("highscore");
        else highscoreText.text = tooltip + "0";
    }

    public void UpdateHighscoreText()
    {
        if (PlayerPrefs.HasKey("highscore")) highscoreText.text = tooltip + PlayerPrefs.GetInt("highscore");
        else highscoreText.text = tooltip + "0";
    }
}