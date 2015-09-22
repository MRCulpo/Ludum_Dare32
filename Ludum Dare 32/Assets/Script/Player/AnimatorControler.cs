using UnityEngine;
using System.Collections;

public enum StatePlayer {
	idle,
	run,
	jump,
	dead,
	falling,
	Attack,
    hit
}

public class AnimatorControler : MonoBehaviour {

	public StatePlayer currentStatePlayer;
	private int idAttack;

	public Animator anim;

	public void setState (StatePlayer state) {

		currentStatePlayer = state;
		checkAnimator();
	}

	public StatePlayer getCurrentAnimation() { return this.currentStatePlayer; }

	public void setIdAttack(StatePlayer state ,int value) {

		this.currentStatePlayer = state;
		this.idAttack = value;
		this.checkAnimator();

	}

	public bool isBlowJump() {
		if(anim.GetBool("Jump"))
			return true;
		else
			return false;
	}

	public bool isBlowAttack() {
		if(anim.GetInteger("Attack") == 1 || anim.GetInteger("Attack") == 2 || anim.GetInteger("Attack") == 3) 
			return  true;
		
		else return false;
	}

	public bool isBlowAttackJump() {
		if(anim.GetInteger("Attack") == 4 ) 
			return  true;
		
		else return false;
	}

	void checkAnimator () {

		switch ( currentStatePlayer ) {

			case StatePlayer.idle : {

				anim.SetFloat("Speed", 0.0f);
				anim.SetBool ("Jump", false);
				anim.SetInteger("Attack", 0);

				break;
			}	

			case StatePlayer.dead : {

                anim.SetTrigger("Die");

				break;
			}

			case StatePlayer.jump : {

				anim.SetBool ("Jump", true);
				//anim.SetBool ("Falling", false);
				anim.SetInteger("Attack", 0);
				break;
			}

			case StatePlayer.run : {

				anim.SetFloat("Speed", 1.0f);
                //anim.SetInteger("Attack", 0);

				break;
			}

			case StatePlayer.falling : {
				
				//anim.SetBool("Falling", true);
				//anim.SetBool("Jump", false);
				//anim.SetInteger("Attack", 0);
				break;
			}

            case StatePlayer.hit:
            {
                anim.SetTrigger("Hit");
                break;
            }

			case StatePlayer.Attack : {

				anim.SetFloat("Speed", 0.0f);
				switch (idAttack) {
	
					case 1 : {
						
						anim.SetInteger("Attack", 1);
						break;
					}
         
					case 2 : {

						anim.SetInteger("Attack", 2);
						break;
					}
					
					case 3 : {

						anim.SetInteger("Attack", 3);
						break;

					}
					case 10 : {
						
						anim.SetInteger("Attack", 10);
						break;
			
					}
                   
				}
				break;
			}
		}
	}
}
