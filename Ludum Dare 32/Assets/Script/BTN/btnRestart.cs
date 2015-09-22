using UnityEngine;
using System.Collections;

public class btnRestart : MonoBehaviour {

    public AudioClip audio;

    public void play()
    {
        AudioManager.instance.audioOnShot(audio);
        StartCoroutine(time());
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log(InventoryManager.currentScene);
        Application.LoadLevel(InventoryManager.currentScene);
    }
}
