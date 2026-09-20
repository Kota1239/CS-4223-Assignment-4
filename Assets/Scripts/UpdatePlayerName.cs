using UnityEngine;
using TMPro;

public class UpdatePlayerName : MonoBehaviour
{
    public TMP_Text playerNameText;
    public string tooltip;

    void Start()
    {
        if (PlayerPrefs.HasKey("playerName")) playerNameText.text = tooltip + PlayerPrefs.GetString("playerName");
        else playerNameText.text = tooltip + "player";
    }
}
