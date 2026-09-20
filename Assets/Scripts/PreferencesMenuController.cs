using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreferencesMenuController : MonoBehaviour
{
    public Slider timeSlider;
    public TMP_Dropdown piecesDropdown;
    public TMP_Text timeSelectionTooltip;
    public TMP_InputField playerNameTextBox;
    public TMP_Text playerNamePlaceholderText;

    void Start()
    {
        timeSlider.value = GlobalPreferences.GetTimePreference();
        piecesDropdown.value = GlobalPreferences.GetPiecesPreference();
        timeSelectionTooltip.text = GlobalPreferences.GetTimePreference()*10+10 + " seconds";
        playerNamePlaceholderText.text = PlayerPrefs.GetString("playerName");
    }

    public void UpdatePiecesPref()
    {
        GlobalPreferences.SetPiecesPreference(piecesDropdown.value);
    }

    public void UpdateTimePref()
    {
        GlobalPreferences.SetTimePreference(timeSlider.value);
    }

    public void UpdateTimePrefTooltip()
    {
        timeSelectionTooltip.text = GlobalPreferences.GetTimePreference()*10 + " seconds";
    }

    public void UpdatePlayerName()
    {
        PlayerPrefs.SetString("playerName", playerNameTextBox.text);
        PlayerPrefs.Save();
    }
}
