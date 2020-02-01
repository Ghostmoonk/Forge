﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _MGR_ScoreManager : MonoBehaviour
{
    public static int currentgamescore;

    public Text CurrentGameScoreGO;
    public GameObject InputValueGO;

    public void CurrentGameScoreDisp()
    {
        CurrentGameScoreGO.text = "2";
        InputValueGO.GetComponent<Text>().text = "yaas";
    }

    public Text[] HSobj = new Text[11];

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
    }
    
    public static int[] definedscoringbundle(int scorebundle)
    {
        int[] oldandnewgamescore = new int[2];
        oldandnewgamescore[0] = currentgamescore;
        oldandnewgamescore[1] = currentgamescore + scorebundle;
        currentgamescore = oldandnewgamescore[1];
        return oldandnewgamescore;
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