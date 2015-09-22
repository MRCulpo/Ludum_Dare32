using UnityEngine;
using System.Collections;

public class TheEndManager : MonoBehaviour {

	
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name.Equals("CollisionsMove"))
        {
            Application.LoadLevel("Creditos");
        }
    }

}
