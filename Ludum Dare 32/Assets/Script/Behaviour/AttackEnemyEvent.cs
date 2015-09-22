using UnityEngine;
using System.Collections;

public class AttackEnemyEvent : MonoBehaviour
{
    private EnemyBehaviourIA enemy;
    public float velocity;
    public GameObject bullet;
    public Transform gun;

    void Start()
    {
        this.enemy = transform.parent.GetComponent<EnemyBehaviourIA>();
    }

    void OnEnterAllowableDistance(Transform other)
    {
        if (other.tag.Equals("Player"))
        {
            if (enemy.isAttackAgain)
                this.enemy.attack = true;
        }
    }

    void OnStayAllowableDistance(Transform other)
    {
        if (other.tag.Equals("Player"))
        {
            if (enemy.isAttackAgain)
                this.enemy.attack = true;
        }
    }

    public void shoot()
    {
        GameObject _bullet = Instantiate(bullet, gun.transform.position, Quaternion.identity) as GameObject;

        _bullet.GetComponent<SpeedObjectBehaviour>().addVelocity(transform.localScale.x < 0 ? -velocity : velocity);

        StartCoroutine(timeAttack());
        this.enemy.attack = false;
    }

    void destroy()
    {
        Destroy(transform.parent.gameObject);
    }

    public IEnumerator timeAttack()
    {
        yield return new WaitForSeconds(enemy.nextAttackTime);
        enemy.isAttackAgain = true;
    }

}
