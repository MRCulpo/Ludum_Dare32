using UnityEngine;
using System.Collections;

public class InputControler : MonoBehaviour {

	private MoveControler i_move;
	private AnimatorControler i_anim;
	private AttackControler i_attack;

	void Start() {

		i_move = GetComponent<MoveControler>();
		i_anim = GetComponent<AnimatorControler>();
		i_attack = GetComponent<AttackControler>();
		i_anim.setState(StatePlayer.falling);

	}

	void FixedUpdate() {

		if(Director.checkDirector().stateGame == StateGame.Play) {

			i_move.layerEvents();
			i_move.checkCharacterMove();

			if(!i_anim.isBlowAttack()) {

                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button2) )
                {

                    i_move.jumpCharacter();

                }

                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);

				if(Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0) {

                    i_move.moveCharacter(-1);

				}

				else if(Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0) {

                    i_move.moveCharacter(1);

				}
			}

            

			if(Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)) {

				i_attack.addAttack();

			}
		}
	}
}
