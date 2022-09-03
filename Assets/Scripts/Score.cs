using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    public static int currentScore;

    /// <summary>
    /// First index is the highest score.
    /// </summary>
    public static int[] highScores = new int[3];


    public static void AssignHighScores()
    {
        // add all the high scores to a temporary list
        List<int> tempList = new List<int>();
        foreach (int score in highScores)
        {
            tempList.Add(score);
        }

        // place the current score in the right order
        for (int i = 0; i < tempList.Count; i++)
        {
            if (currentScore > tempList[i])
            {
                tempList.Insert(i, currentScore);
                break;
            }
        }

        // update the high scores array with new values
        for (int i = 0; i < highScores.Length; i++)
        {
            highScores[i] = tempList[i];
        }

    }
}
