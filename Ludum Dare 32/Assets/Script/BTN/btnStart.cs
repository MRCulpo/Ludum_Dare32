using UnityEngine;
using System.Collections;

public class btnStart : MonoBehaviour 
{
    public string nameScene;
    public AudioClip audio;

    public void play()
    {
        AudioManager.instance.audioOnShot(audio);
        StartCoroutine(time());
    }
	
    IEnumerator time()
    {
        yield return new WaitForSeconds(1f);
        if (nameScene != InventoryManager.currentScene)
            InventoryManager.instance.resetCheckPoint();
        InventoryManager.currentScene = nameScene;
        Application.LoadLevel(nameScene);
    }
}
