using UnityEngine;
using TMPro;

public class UpdatePreviousScore : MonoBehaviour
{
    public TMP_Text previousscoreText;
    public string tooltip;

    void Start()
    {
        if (PlayerPrefs.HasKey("previousscore")) previousscoreText.text = tooltip + PlayerPrefs.GetInt("previousscore");
        else previousscoreText.text = tooltip + "0";
    }
}