using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {

    void destroyThis(GameObject obj)
    {
        Destroy(obj);
    }
	void destroy() 
    {
        Destroy(this.gameObject);
	}
    void destroyParent()
    {
        Destroy(transform.parent.gameObject);
    }
}
