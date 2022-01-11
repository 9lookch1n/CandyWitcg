using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public Text highScoreLevel_1;
    public Text highScoreLevel_2;
    public Text highScoreLevel_3;

    public int highScoreLevel1;
    public int highScoreLevel2;
    public int highScoreLevel3;

    private void Start()
    {
        highScoreLevel_1.text = PlayerPrefs.GetInt("HighScore_Level_1").ToString();
        highScoreLevel_2.text = PlayerPrefs.GetInt("HighScore_Level_2").ToString();
        highScoreLevel_3.text = PlayerPrefs.GetInt("HighScore_Level_3").ToString();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScoreLevel_1.text = "0";
        highScoreLevel_2.text = "0";
        highScoreLevel_3.text = "0";
    }


}
