using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class _MGR_ScoreManager : MonoBehaviour
{
    private static _MGR_ScoreManager p_instance = null;
    public static _MGR_ScoreManager Instance { get { return p_instance; } }

    public Text CurrentGameScoreGO;
    //public Text InputValueGO;
    //public Text LastHighGO;
    //public Text CurrentGameScoreT1GO;
    //public Text ScoreBundleGO;
    //public Text MultiplierGO;
    public Text HighlighterGO;
    public Text[] HSobj = new Text[11];
    public Text[] HSlab = new Text[11];
    public int[] HSint = new int[11];
    public int CurrentGameScore = 0;

    public int scoreMultiplier = 0;
    public Text scoreMultiplierGO;

    public Text yourScore;
    public Text[] highScore;
    //public void TestButton()
    //{
    //    CurrentGameScoreGO.text = "2";
    //    InputValueGO.text = "yaas";
    //}
    void Awake()
    {
        // ===>> SingletonMAnager
        //Check if instance already exists
        if (p_instance == null)
            //if not, set instance to this
            p_instance = this;
        //If instance already exists and it's not this:
        else if (p_instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }

    public void resethighscores()
    {
        for (int i = 0; i < 11; i++)
        {
            HSobj[i].text = "0";
            HSint[i] = 0;
            //LastHighGO.text = "0";
            HighlighterGO.text = "0";
        }
    }

    public void resetgamescore()
    {
        //CurrentGameScoreGO.text = "0";
        //CurrentGameScoreT1GO.text = "0";
        CurrentGameScore = 0;
        //InputValueGO.text = "0";
        //ScoreBundleGO.text = "0";
        //MultiplierGO.text = "0";
    }

    public void UpdateScore(int inputScore)
    {
        int scorebundle = inputScore * scoreMultiplier;
        CurrentGameScore += scorebundle;
        CurrentGameScoreGO.text = CurrentGameScore.ToString();
    }

    public void comboIncrement()
    {
        scoreMultiplier++;
        scoreMultiplierGO.text = scoreMultiplier.ToString();
    }

    public void comboReboot()
    {
        scoreMultiplier = 1;
        scoreMultiplierGO.text = scoreMultiplier.ToString();
    }

    public void gameover()
    {
        bool SearchHighscoreSpot;
        int NewHighscoreSpot = 0;
        int[] nuHSint = new int[12];
        for (int i = 0; i < 12; i++)
        {
            if (i < 10) nuHSint[i] = HSint[i];
            else { nuHSint[i] = 0; }
        }

        if (CurrentGameScore > nuHSint[9])
        {
            SearchHighscoreSpot = true;
            for (int i = 8; i >= 0; i--)
            {
                if (nuHSint[i] >= CurrentGameScore && SearchHighscoreSpot == true)
                {
                    NewHighscoreSpot = i + 1;
                    SearchHighscoreSpot = false;
                }
                else if (i == 0 && CurrentGameScore > nuHSint[i] && SearchHighscoreSpot == true)
                {
                    NewHighscoreSpot = i;
                    SearchHighscoreSpot = false;
                }
            }
            if (NewHighscoreSpot < 9)
            {
                for (int i = 8; i >= NewHighscoreSpot; i--)
                {
                    nuHSint[i + 1] = nuHSint[i];
                }
            }
            nuHSint[NewHighscoreSpot] = CurrentGameScore;
            nuHSint[11] = NewHighscoreSpot;
        }
        else
        {
            nuHSint[10] = CurrentGameScore;
            nuHSint[11] = 10;
        }
        yourScore.text = "Your Score : " +CurrentGameScore.ToString();
        nuHiScore(nuHSint);
    }

    public void nuHiScore(int[] displayable)
    {
        for (int i = 0; i < 10; i++)
        {
            highScore[i].text = displayable[i].ToString();
            HSint[i] = displayable[i];
        }
        HighlighterGO.text = HSlab[displayable[11]].text;
        resetgamescore();
        scoreMultiplier = 0;
    }
}