using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textScore;
    public float score;


    public GameObject completeLevelUI; // added for money win

    void Start()
    {
        score = 0f;

        textScore.text = score.ToString() + " Collected Coins";
    }

    private void Update()
    {
        textScore.text = score.ToString() + " Collected Coins";

        if (score >= 5)
        {
            CoinWinGame();
            completelevel();
        }
    }

    void CoinWinGame()
    {
        Debug.Log("player has won the game!");


    }

    public void completelevel()// added to win game
    {
        completeLevelUI.SetActive(true);
    }


}
