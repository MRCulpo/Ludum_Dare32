using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class MamadeiraBehaviour : MonoBehaviour 
{
    public bool mamadeira;
    public AudioClip audio;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            if(mamadeira)
                InventoryManager.instance.addMamadeira();
            else
                InventoryManager.instance.addCandy();

            AudioManager.instance.audioOnShot(audio);
            Destroy(this.gameObject);
        }
    }

}
