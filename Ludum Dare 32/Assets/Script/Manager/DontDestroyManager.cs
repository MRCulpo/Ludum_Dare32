using UnityEngine;
using System.Collections;

public class DontDestroyManager : MonoBehaviour
{
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}

}
