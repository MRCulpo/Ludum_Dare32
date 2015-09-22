using UnityEngine;
using System.Collections;

public class DamageEnemyBehaviour : MonoBehaviour {

    public float damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Equals("CollisionsMove"))
        {
            Debug.Log("Player" + other.name);
            other.transform.parent.GetComponent<LifeControler>().removeLife(damage);
            if(this.gameObject.name.Equals("Bullet"))
                Destroy(this.gameObject);
        }
    }
}
