using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _MGR_ScoreManager : MonoBehaviour
{
    ////GameScore Display
    ////Game Score is kept here
    //public static int currentGameScore;

    ////HighScores Display
    ////High Score are kept here
    //public static int[] highScoresBoard = new int[11];

    ////GameLaunch Trigger
    ////Resets all HighScores to 0
    ////Trigger upon gameLaunch [enter title screen]
    //public static void ResetHighScores()
    //{
    //    for (int i=0; i<11; i++)
    //    {
    //        highScoresBoard[i]=0;
    //    }
    //}

    ////GameStart Trigger
    ////Resets GameScore to 0
    ////Trigger upon gameStart [startGame ButtonDown]
    //public static void ResetGameScore()
    //{
    //    currentGameScore = 0;
    //}

    ////Score Increment
    ////Imput was pressed, scoring happened
    ////New extra-points to be sent in package
    ////Trigger upon ~InputReseived [scoring needs to have been calculated]
    //public static int[] DefinedScoringBundle(int scoreBundle)
    //{
    //    int[] oldAndNewGameScore = new int[2];
    //    oldAndNewGameScore[0]=currentGameScore;
    //    oldAndNewGameScore[1]=currentGameScore + scoreBundle;
    //    currentGameScore = oldAndNewGameScore[1];
    //    return oldAndNewGameScore;
    //}

    ////EndGame Trigger
    ////Current GameScore is added to HighScores
    ////Trigger upon Game over
    ////STRUCTURE OF RETURNED ITEM:
    //    //ARRAY - 12 INTs
    //    //INTs 0 to 9 : SPOTS 1 to 10 ON BOARD
    //    //INT 10 : GAME SCORE IS LOWER THAN HIGH SCORES
    //    //INT 11 : NUMBER OF THE INT TO HIGHLIGHT (=last game score)
    //public static int[] GameOver()
    //{
    //    bool searchHighScoreSpot = false;
    //    int newHighScoreSpot = 0;
    //    int finalGameScore = currentGameScore;
    //    int[] newHighScoreBoard = new int[12];
    //    for (int i=0; i<10; i++)
    //    {
    //        newHighScoreBoard[i] = highScoresBoard[i];
    //    }

    //    //Is current game score worthy of High Scores?
    //    //yaas
    //    if (finalGameScore > newHighScoreBoard[9])
    //    {
    //        searchHighScoreSpot = true;
    //        while(searchHighScoreSpot==true)
    //        {
    //            for(int i=8; i>=0; i--)
    //            {
    //                if(newHighScoreBoard[i]>=finalGameScore)
    //                {
    //                    newHighScoreSpot = i + 1;
    //                    searchHighScoreSpot = false;
    //                }
    //                    //NEW HIGH SCORE #1!!!
    //                else if (i==0 && finalGameScore>newHighScoreBoard[i])
    //                {
    //                    searchHighScoreSpot = false;
    //                }
    //            }
    //        }
    //        //recalculate all scores @board
    //        if(newHighScoreSpot<9)
    //        {
    //            for (int i = 8; i <= newHighScoreSpot; i--)
    //            {
    //                newHighScoreBoard[i+1] = newHighScoreBoard[i];
    //            }
    //        }
    //        newHighScoreBoard[newHighScoreSpot] = finalGameScore;
    //        newHighScoreBoard[11] = newHighScoreSpot;
    //        return newHighScoreBoard;
    //    }

    //    //nope
    //    else
    //    {
    //        newHighScoreBoard[10] = finalGameScore;
    //        newHighScoreBoard[11] = 10;
    //        return newHighScoreBoard;
    //    }
    //}

    public Text ResetHighScoresGO;
    public Text CurrentGameScoreGO;
    public GameObject InputValueGo;

    void Start()
    { }

    void Update()
    { }

    public void CurrentGameScoreDisp()
    {
        CurrentGameScoreGO.text = "2";
        InputValueGo.GetComponent<Text>().text = "yaas";
    }
}