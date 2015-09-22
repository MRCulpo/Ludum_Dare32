using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
    public static AudioManager instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Audio");

        if (obj.Length > 1)
            Destroy(obj[0]);

    }

    public void chargeAudioBackGround(AudioClip _audio)
    {
        audio.clip = _audio;
        audio.Play();
    }

    public void audioOnShot(AudioClip _audio)
    {
        audio.PlayOneShot(_audio);
    }

}
