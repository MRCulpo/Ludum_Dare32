using UnityEngine;
using System.Collections;

public class AttackControler : MonoBehaviour {

	private int currentIdAttack;
    public int amountAttack;

	private bool isAttack;
	private bool otherAttack;
	private bool attackNow; 

	private MoveControler a_moveControler;
	private AnimatorControler a_animatorControler;

	#region GETTER AND SETTER
	public bool AttackNow {

		get {
			return this.attackNow;
		}
		set {
			attackNow = value;
		}
	}

	public bool OtherAttack {

		get {
			return this.otherAttack;
		}
		set {
			otherAttack = value;
		}

	}

	public bool IsAttack {

		get {
			return this.isAttack;
		}
		set {
			isAttack = value;
		}

	}
	#endregion

	void Start() {

		this.a_animatorControler = GetComponent<AnimatorControler>();
		this.a_moveControler = GetComponent<MoveControler>();
		this.isAttack = false;
		this.otherAttack = false;

	}

	void Update() {

		if(!this.isAttack && this.currentIdAttack != 0)
			this.currentIdAttack = 0;

		if(attackNow) 
		{
			this.playAttack();
			this.attackNow = false;
		}

	}

	public void addAttack() {

        if (a_moveControler != null)
        {
            if (!a_moveControler.DontAttackJump || a_moveControler.Ground)
            {
                if (this.isAttack)
                    this.otherAttack = true;
                else
                    this.attackNow = true;
            }
        }
        else
        {
            if (this.isAttack)
                this.otherAttack = true;
            else
                this.attackNow = true;
        }

	}

	void playAttack() {

		this.checkIdAttack();

		this.isAttack = true;

		a_animatorControler.setIdAttack(StatePlayer.Attack, currentIdAttack);

	}

	void checkIdAttack() {

        if (a_moveControler != null)
        {
            if (!a_moveControler.IsJump)
            {
                this.currentIdAttack = Random.Range(1, amountAttack);

            }
            else if (a_moveControler.IsJump)
                this.currentIdAttack = 10;
            else
                this.currentIdAttack = 0;
        }
        else if(a_moveControler == null)
        {
            this.currentIdAttack = Random.Range(1, amountAttack);
        }
	}
}
