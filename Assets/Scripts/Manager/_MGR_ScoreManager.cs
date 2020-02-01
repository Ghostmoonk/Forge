using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class _MGR_ScoreManager : MonoBehaviour
{
    public Text CurrentGameScoreGO;
    public GameObject InputValueGO;
    public Text[] HSobj = new Text[11];
    public Text LastHighGO;
    public Text CurrentGameScoreT1GO;
    public Text ScoreBundleGO;
    public Text MultiplierGO;
    public int CurrentGameScore = 0;

    public void TestButton()
    {
        CurrentGameScoreGO.text = "2";
        InputValueGO.GetComponent<Text>().text = "yaas";
    }

    public void resethighscores()
    {
        for (int i = 0; i < 11; i++)
        {
            HSobj[i].text = "0";
        }
    }
    
    public void resetgamescore()
    {
        CurrentGameScoreGO.text = "0";
        CurrentGameScoreT1GO.text = "0";
        CurrentGameScore = 0;
    }

    public void GoodInput()  { DiffertentInputs(2); }
    public void BadInput() { DiffertentInputs(1); }
    public void RandomInput() { DiffertentInputs(0); }

    public void DiffertentInputs(int mode)
    {
        int inputValue = UnityEngine.Random.Range(1, 10);
        int multiplier = UnityEngine.Random.Range(1, 10);
        if (mode == 2) inputValue = 10;
        if (mode == 1) inputValue = 1;
        InputValueGO.GetComponent<Text>().text = inputValue.ToString();
        MultiplierGO.text = multiplier.ToString();
        int scorebundle = inputValue * multiplier;
        ScoreBundleGO.text = scorebundle.ToString();

        CurrentGameScoreGO.text = (CurrentGameScore + scorebundle).ToString();
        CurrentGameScoreT1GO.text = CurrentGameScore.ToString();
        CurrentGameScore += scorebundle;
    }

    //public static int[] gameover()
    //{
    //    bool searchhighscorespot = false;
    //    int newhighscorespot = 0;
    //    int finalgamescore = currentgamescore;
    //    int[] newhighscoreboard = new int[12];
    //    for (int i = 0; i < 10; i++)
    //    {
    //        newhighscoreboard[i] = highscoresboard[i];
    //    }
        
    //    if (finalgamescore > newhighscoreboard[9])
    //    {
    //        searchhighscorespot = true;
    //        while (searchhighscorespot == true)
    //        {
    //            for (int i = 8; i >= 0; i--)
    //            {
    //                if (newhighscoreboard[i] >= finalgamescore)
    //                {
    //                    newhighscorespot = i + 1;
    //                    searchhighscorespot = false;
    //                }
    //                else if (i == 0 && finalgamescore > newhighscoreboard[i])
    //                {
    //                    searchhighscorespot = false;
    //                }
    //            }
    //        }
    //        if (newhighscorespot < 9)
    //        {
    //            for (int i = 8; i <= newhighscorespot; i--)
    //            {
    //                newhighscoreboard[i + 1] = newhighscoreboard[i];
    //            }
    //        }
    //        newhighscoreboard[newhighscorespot] = finalgamescore;
    //        newhighscoreboard[11] = newhighscorespot;
    //        return newhighscoreboard;
    //    }
    //    else
    //    {
    //        newhighscoreboard[10] = finalgamescore;
    //        newhighscoreboard[11] = 10;
    //        return newhighscoreboard;
    //    }
    //}
}