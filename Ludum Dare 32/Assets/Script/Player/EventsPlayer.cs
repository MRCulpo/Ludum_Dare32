using UnityEngine;
using System.Collections;

public class EventsPlayer : MonoBehaviour {

    public GameObject dead;

	public AttackControler e_attack;
	public AnimatorControler e_anim;

    void instanteDead()
    {
        GameObject obj = Instantiate(dead, transform.position, Quaternion.identity) as GameObject;
        Destroy(transform.parent.gameObject);
        Director.checkDirector().end();
    }

    

    public void play(AudioClip a)
    {
        AudioManager.instance.audioOnShot(a);
    }

	public void isAttack() {

        if (e_attack.OtherAttack == false)
        {
            e_anim.anim.SetInteger("Attack", 0);
            e_attack.IsAttack = false;
        }
        else
        {
            e_attack.OtherAttack = false;
            e_attack.AttackNow = true;
            e_anim.anim.SetInteger("Attack", 0);
        }
	}

	public void isAttackJump() {

		if(e_attack.OtherAttack == false) {

			e_anim.anim.SetInteger("Attack", 0);
			e_attack.IsAttack = false;

		}
		else {

			if(!MoveControler.checkMoveControler().DontAttackJump) {
				e_attack.AttackNow = true;
				e_attack.OtherAttack = false;
			}
			else
				e_attack.IsAttack = false;	
		}
	}
}
