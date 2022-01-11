using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayStartCtrl : MonoBehaviour
{
    public GameObject countDown;
    public GameObject drawArea;
    public GameObject Boarder;

    public GameObject BttPause;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine("StartDelay");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 5.5f;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        countDown.gameObject.SetActive(false);
        Boarder.gameObject.SetActive(false);
        drawArea.gameObject.SetActive(true);
        BttPause.gameObject.SetActive(true);
        Time.timeScale = 1;

    }

}
