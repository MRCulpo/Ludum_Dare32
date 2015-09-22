using UnityEngine;
using System.Collections;

public class TrapBehaviour : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	void OnEnterAllowableDistance(Transform other)
    {
        if(other.tag.Equals("Player"))
        {
            this.anim.SetTrigger("play");
        }
    }
    
    void OnStayAllowableDistance(Transform other)
    {
        if (other.tag.Equals("Player"))
        {
            this.anim.SetTrigger("play");
        }
    }
}
