using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Loader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public void LoadScene(int sceneIndex) 
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
        }
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }
}
