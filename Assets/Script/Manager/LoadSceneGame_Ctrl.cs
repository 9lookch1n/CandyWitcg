using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneGame_Ctrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayStartGame(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayStartGame(int sec)
    {
        yield return new WaitForSeconds(sec);

        SceneManager.LoadScene("StartScene");
    }
}
