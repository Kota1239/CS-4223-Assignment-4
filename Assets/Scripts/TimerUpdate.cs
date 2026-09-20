using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUpdate : MonoBehaviour
{
    public Scenes sceneManager;
    public TMP_Text timerText;
    public string timerTooltip;
    public float totalTime;
    public float timeLeft = 60f;
    bool timerOn = true;
    void Start()
    {
        totalTime = GlobalPreferences.GetTimePreference()*10f;
        timeLeft = totalTime;
    }

    void Update()
    {
        if(timerOn) TickTimer();
    }

    void TickTimer()
    {
        if (timeLeft <= 0f)
        {
            sceneManager.LooseGame();
        }
        timeLeft -= Time.deltaTime;
        timerText.text = timerTooltip + Mathf.RoundToInt(timeLeft) + " seconds";
    }

    public void StopTimer()
    {
        timerOn = false;
    } 
}
