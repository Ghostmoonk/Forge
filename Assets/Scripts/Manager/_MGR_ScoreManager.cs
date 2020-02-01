using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class _MGR_ScoreManager : MonoBehaviour
{
    public Text CurrentGameScoreGO;
    public Text InputValueGO;
    public Text LastHighGO;
    public Text CurrentGameScoreT1GO;
    public Text ScoreBundleGO;
    public Text MultiplierGO;
    public Text HighlighterGO;
    public Text[] HSobj = new Text[11];
    public Text[] HSlab = new Text[11];
    public int[] HSint = new int[11];
    public int CurrentGameScore = 0;

    public void TestButton()
    {
        CurrentGameScoreGO.text = "2";
        InputValueGO.text = "yaas";
    }

    public void resethighscores()
    {
        for (int i = 0; i < 11; i++)
        {
            HSobj[i].text = "0";
            HSint[i] = 0;
        }
    }

    public void resetgamescore()
    {
        CurrentGameScoreGO.text = "0";
        CurrentGameScoreT1GO.text = "0";
        CurrentGameScore = 0;
        HighlighterGO.text = "0";
        InputValueGO.text = "0";
        ScoreBundleGO.text = "0";
        MultiplierGO.text = "0";
        LastHighGO.text = "0";
    }

    public void GoodInput() { DiffertentInputs(2); }
    public void BadInput() { DiffertentInputs(1); }
    public void RandomInput() { DiffertentInputs(0); }

    public void DiffertentInputs(int mode)
    {
        int inputValue = UnityEngine.Random.Range(1, 10);
        int multiplier = UnityEngine.Random.Range(1, 10);
        if (mode == 2) inputValue = 10;
        if (mode == 1) inputValue = 1;
        InputValueGO.text = inputValue.ToString();
        MultiplierGO.text = multiplier.ToString();
        int scorebundle = inputValue * multiplier;
        ScoreBundleGO.text = scorebundle.ToString();

        CurrentGameScoreGO.text = (CurrentGameScore + scorebundle).ToString();
        CurrentGameScoreT1GO.text = CurrentGameScore.ToString();
        CurrentGameScore += scorebundle;
    }

    public void gameover()
    {
        bool SearchHighscoreSpot;
        int NewHighscoreSpot = 0;
        int FinalGameScore = CurrentGameScore;
        int[] nuHSint = new int[12];
        for (int i = 0; i < 10; i++)
        {
            nuHSint[i] = HSint[i];
        }

        if (FinalGameScore > nuHSint[9])
        {
            SearchHighscoreSpot = true;
            for (int i = 8; i >= 0; i--)
            {
                if (nuHSint[i] >= FinalGameScore && SearchHighscoreSpot == true)
                {
                    NewHighscoreSpot = i + 1;
                    SearchHighscoreSpot = false;
                }
                else if (i == 0 && FinalGameScore > nuHSint[i] && SearchHighscoreSpot == true)
                {
                    NewHighscoreSpot = i;
                    SearchHighscoreSpot = false;
                }
            }
            if (NewHighscoreSpot < 9)
            {
                for (int i = 8; i <= NewHighscoreSpot; i--)
                {
                    nuHSint[i + 1] = nuHSint[i];
                }
            }
            nuHSint[NewHighscoreSpot] = FinalGameScore;
            nuHSint[11] = NewHighscoreSpot;
        }
        else
        {
            nuHSint[10] = FinalGameScore;
            nuHSint[11] = 10;
        }
        LastHighGO.text = FinalGameScore.ToString();
        nuHiScore(nuHSint);
    }

    public void nuHiScore(int[] displayable)
    {
        for (int i = 0; i < 11; i++)
        {
            HSobj[i].text = displayable[i].ToString();
        }
        HighlighterGO.text = HSlab[displayable[11]].text;
        for (int i = 0; i < 10; i++)
        {
            HSobj[i].text = displayable[i].ToString();
            HSint[i] = displayable[i];
        }
        resetgamescore();
    }
}