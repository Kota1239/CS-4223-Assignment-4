using UnityEngine;

public class SaveHighscore : MonoBehaviour
{
    public void UpdateSavedHighscore()
    {
        PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("previousscore"));
        PlayerPrefs.Save();
    }
}
