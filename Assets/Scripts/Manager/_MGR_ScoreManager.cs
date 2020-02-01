using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGR_ScoreManager : MonoBehaviour
{
    //GameScore Display
    //Game Score is kept here
    public static int gameScore;

    //HighScores Display
    //High Score are kept here
    public static int[] HighScores = new int[11];

    //GameLaunch Trigger
    //Resets all HighScores to 0
    //Trigger upon gameLaunch [enter title screen]
    public static void ResetHighScores()
    {
        for (int i=0; i<11; i++)
        {
            highScores[i]=0;
        }
    }

    //GameStart Trigger
    //Resets GameScore to 0
    //Trigger upon gameStart [startGame ButtonDown]
    public static void ResetScore()
    {
        gameScore = 0;
    }

    //Score Increment
    //Imput was pressed, scoring happened
    //New extra-points to be sent in package
    //Trigger upon ~InputReseived [scoring needs to have been calculated]
    public static int[] ScoringBundle(int scoring)
    {
        int[] increaseScore = new int[2];
        increaseScore.[0]=gameScore;
        increaseScore.[1]=gameScore + scoring;
        gameScore = increaseScore[1];
        return increaseScore;
    }

    //EndGame Trigger
    //Current GameScore is added to HighScores
    //Trigger upon Game over
    //STRUCTURE OF RETURNED ITEM:
        //ARRAY - 12 INTs
        //INTs 0 to 9 : SPOTS 1 to 10 ON BOARD
        //INT 10 : GAME SCORE IS LOWER THAN HIGH SCORES
        //INT 11 : NUMBER OF THE INT TO HIGHLIGHT (=last game score)
    public static int[] GameOver()
    {
        bool searchPlace = false;
        int newPlace = 0;
        int finalScore = gameScore;
        int[] scoreBoard = new int[12];
        for (int i=0; i<10; i++)
        {
            scoreBoard[i] = gameScore[i];
        }

        //Is current game score worthy of High Scores?
        //yaas
        if (finalScore > scoreBoard[9])
        {
            searchPlace = true;
            while(searchPlace==true)
            {
                for(int i=8; i>=0; i--)
                {
                    if(scoreBoard[i]>=finalScore)
                    {
                        newPlace = i + 1;
                        searchPlace = false;
                    }
                        //NEW HIGH SCORE #1!!!
                    else if (i==0 && finalScore>scoreBoard[i])
                    {
                        searchPlace = false;
                    }
                }
            }
            //recalculate all scores @board
            if(newPlace<9)
            {
                for (int i = 8; i <= newPlace; i--)
                {
                    scoreBoard[i+1] = scoreBoard[i];
                }
            }
            scoreBoard[newPlace] = finalScore;
            scoreBoard[11] = newPlace;
            return scoreBoard;
        }

        //nope
        else
        {
            scoreBoard(10) = finalScore;
            scoreBoard(11) = 10;
            return scoreBoard;
        }
    }
}
