using UnityEngine;
using System.Collections;

public class EnemyBehaviourIA : MonoBehaviour
{
    public float velocity;
    public float distance;
    public float nextAttackTime;
    public float impulseHit;
    public Transform sprite;

    private AnimatorControler anim;
    private MovimentBehaviour enemyMoviment;
    private AttackControler enemyAttackController;
    private Transform myEnemy;

    public bool moving;
    public bool attack;
    public bool isAttackAgain;

    bool facing;   // face do Inimigo
    bool chargeFlip;


    void Start()
    {
        this.moving = false;
        this.attack = false;
        this.isAttackAgain = true;
        this.anim = GetComponent<AnimatorControler>();
        this.enemyMoviment = GetComponent<MovimentBehaviour>();
        this.enemyAttackController = GetComponent<AttackControler>();
    }

    void Update()
    {
        if (myEnemy != null)
        {
            if (this.moving)
            {
                if (this.attack)
                {
                    if (this.isAttackAgain)
                    {
                        this.enemyMoviment.stop();
                        this.enemyAttackController.addAttack();
                        this.isAttackAgain = false;
                    }
                }
                else if (transform.position.x > myEnemy.position.x + distance)
                {
                    this.enemyMoviment.move(-velocity);
                    if (this.chargeFlip)
                    {
                        this.chargeFlip = false;
                        Flip();
                    }
                    this.anim.setState(StatePlayer.run);
                }
                else if (transform.position.x <= myEnemy.position.x - distance)
                {
                    this.enemyMoviment.move(velocity);
                    if (!this.chargeFlip)
                    {
                        this.chargeFlip = true;
                        Flip();
                    }
                    this.anim.setState(StatePlayer.run);
                }
            }
        }
        else
        {
            this.anim.setState(StatePlayer.idle);
            this.enemyMoviment.stop();
        }
    }

    public void addImpulse()
    {
        this.moving = false;
        StartCoroutine(time(1));
        if (transform.position.x > myEnemy.position.x)
            enemyMoviment.addForce(impulseHit);
        else
            enemyMoviment.addForce(-impulseHit);
    }

    void Flip()
    {
        // faz a troca da face
        facing = !facing;
        Vector3 theScale = sprite.localScale;
        theScale.x *= -1;
        sprite.localScale = theScale;
    }


    void OnEnterAllowableDistance(Transform other)
    {
        this.myEnemy = other.FindChild("Sprite").transform;
        this.moving = true;
        //print("Este objeto entrou no meu raio" + " :: O nome é " + other.name);
    }
    /*
    void OnStayAllowableDistance(Transform other)
    {
        if (!isAttackAgain)
            this.moving = true;
        //print("Este objeto entrou no meu raio" + " :: O nome é " + other.name);
    }
    */
    void OnExitAllowableDistance(Transform other)
    {
        this.moving = false;
        this.anim.setState(StatePlayer.idle);
        this.enemyMoviment.stop();
        //print("Este objeto saiu do meu raio" + " :: O nome é " + other.name);
    }

    IEnumerator time(float time)
    {
        yield return new WaitForSeconds(time);
        this.moving = true;
    }
}
