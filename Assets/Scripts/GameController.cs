using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class GameController : MonoBehaviour
{
    bool canWin = true;
    static int totalPieces = 0;
    static int currentPieces = 0;

    public TimerUpdate timer;
    public Scenes sceneManager;
    public SplitImage imageSplitter;

    void Start()
    {
        currentPieces = 0;
        int piecesPref = GlobalPreferences.GetPiecesPreference();
        if (piecesPref == 0) totalPieces = 4;
        else if (piecesPref == 1) totalPieces = 9;
        else if (piecesPref == 2) totalPieces = 16;
        else if (piecesPref == 3) totalPieces = 32;
        else if (piecesPref == 4) totalPieces = 64;
    }

    void Update()
    {
        if (currentPieces == totalPieces && canWin)
        {
            StartCoroutine(WinGame());
        }
    }

    public static void CollectPiece()
    {
        currentPieces++;
    }

    public IEnumerator WinGame()
    {
        timer.StopTimer();
        calculateScore();
        yield return new WaitForSeconds(2f);
        // confetti or sumn
        //yield return new WaitForSeconds(4f);
        sceneManager.WinGame();
    }

    void calculateScore()
    {
        canWin = false;
        float baseScore = 500f;
        float piecesScoreMultiplier = 1f;
        int piecesPref = GlobalPreferences.GetPiecesPreference();
        if (piecesPref == 0) piecesScoreMultiplier = 1f;
        else if (piecesPref == 1) piecesScoreMultiplier = 1.25f;
        else if (piecesPref == 2) piecesScoreMultiplier = 1.75f;
        else if (piecesPref == 3) piecesScoreMultiplier = 2.5f;
        else if (piecesPref == 4) piecesScoreMultiplier = 4f;
        int finalScore = Mathf.RoundToInt((baseScore - (timer.totalTime - timer.timeLeft)) * piecesScoreMultiplier);
        PlayerPrefs.SetInt("previousscore", finalScore);
        PlayerPrefs.Save();
    } 
}
