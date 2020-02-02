using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateHUDScore : MonoBehaviour
{
    public TextMesh scoreMultiplierText;
    public TextMesh scoreText;

    void Start()
    {
        _MGR_ScoreManager.Instance.CurrentGameScoreGO = scoreText;
        _MGR_ScoreManager.Instance.scoreMultiplierGO = scoreMultiplierText;
    }
}
