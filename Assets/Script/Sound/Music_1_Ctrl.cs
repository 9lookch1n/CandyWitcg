using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_1_Ctrl : MonoBehaviour
{
    public AudioClip newTrack;

    Music_Ctrl musicCtrl;

    private void Start()
    {
        musicCtrl = FindObjectOfType<Music_Ctrl>();

        if (newTrack != null)
        {
            musicCtrl.ChangeBGM(newTrack);
        }
    }
}
