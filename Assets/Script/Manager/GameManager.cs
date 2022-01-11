using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score Settings")]
    public int score;
    public int endScoreWinLevel_1;
    public int scoreValue;
    public int growthRate;

    public int endScoreLose;

    [Header("Multiplier Settings")]
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] MultiplierTresholds;

    [Header("Text Settings")]
    public Text scoreVal;
    public Text multipliersText;
    public Text endScoreWinLevel1Text;
    public Text endScorLoseText;

    public static GameManager instance;
    [Header("----------")]
    public GameObject spawner;

    public Animator multiplier;
    public Animator scoreChange;

    [Header("Bool Settings")]
    public bool gameFinish;
    public bool gameOver;

    void Start()
    {
        instance = this;
        currentMultiplier = 1;
    }
    public void Update()
    {
        //SCORE TEXT--------
        scoreVal.text = score.ToString("0");

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            endScoreWinLevel1Text.text = endScoreWinLevel_1.ToString("0,0");
            if (endScoreWinLevel_1 > PlayerPrefs.GetInt("HighScore_Level_1", 0))
            {
                PlayerPrefs.SetInt("HighScore_Level_1", endScoreWinLevel_1);
            }
        }
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level2"))
        {
            endScoreWinLevel1Text.text = endScoreWinLevel_1.ToString("0,0");
            if (endScoreWinLevel_1 > PlayerPrefs.GetInt("HighScore_Level_2", 0))
            {
                PlayerPrefs.SetInt("HighScore_Level_2", endScoreWinLevel_1);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level3"))
        {
            endScoreWinLevel1Text.text = endScoreWinLevel_1.ToString("0,0");
            if (endScoreWinLevel_1 > PlayerPrefs.GetInt("HighScore_Level_3", 0))
            {
                PlayerPrefs.SetInt("HighScore_Level_3", endScoreWinLevel_1);
            }
        }

        if (endScoreLose < 100)
        {
            endScorLoseText.text = endScoreLose.ToString("0");
        }
        else
        {
            endScorLoseText.text = endScoreLose.ToString("0,0");
        }

        multipliersText.text = "x" + currentMultiplier;

        if (gameFinish == true)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level3"))
            {
                StartCoroutine(DelayLevel3(9.3f));
            }
            else
            {
                GameWin();
            }

        }
    }
    public void Hit()
    {
        scoreChange.SetTrigger("Change_Score");
        if (currentMultiplier - 1 < MultiplierTresholds.Length)
        {
            multiplier.SetTrigger("Change");
            multiplierTracker++;

            if (MultiplierTresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multipliersText.text = "x" + currentMultiplier;
        score += scoreValue * currentMultiplier;
        scoreChange.SetTrigger("Change_Idle");

    }
    public void Multiplier_leLevel3()
    {
        scoreChange.SetTrigger("Change_Score");
        if (currentMultiplier - 1 < MultiplierTresholds.Length)
        {
            multiplier.SetTrigger("Change");
            multiplierTracker++;

            if (MultiplierTresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
    }
    public void HitLevel3()
    {
        scoreChange.SetTrigger("Change_Score");
        if (currentMultiplier - 1 < MultiplierTresholds.Length)
        {
            multiplier.SetTrigger("Change");
            multiplierTracker++;

            if (MultiplierTresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multipliersText.text = "x" + currentMultiplier;
        score += scoreValue * currentMultiplier * 2;
        scoreChange.SetTrigger("Change_Idle");
    }
    public void Miss()
    {
        score -= 50;
        if (score < 0)
        {
            score = 0;
        }
        currentMultiplier = 1;
        multiplierTracker = 0;
    }
    public void GameWin()
    {
        if (endScoreWinLevel_1 != score && score > endScoreWinLevel_1)
        {
            endScoreWinLevel_1 += growthRate;

            if(Input.anyKeyDown)
            {
                endScoreWinLevel_1 = score;
            }
        }
    }
    public void GameOver()
    {
        if(endScoreLose != score && score > endScoreLose)
        {
            endScoreLose += growthRate;

            if (Input.anyKeyDown)
            {
                endScoreWinLevel_1 = score;
            }
        }
    }
    IEnumerator DelayLevel3(float sec)
    {
        yield return new WaitForSeconds(sec);
        GameWin();
    }

}
