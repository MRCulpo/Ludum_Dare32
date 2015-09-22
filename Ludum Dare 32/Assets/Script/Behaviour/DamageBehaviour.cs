using UnityEngine;
using System.Collections;

public class DamageBehaviour : MonoBehaviour 
{
    public float damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Enemy"))
        {
            other.GetComponent<LifeControler>().removeLife(damage);
            other.GetComponent<EnemyBehaviourIA>().addImpulse();
        }
    }
}
