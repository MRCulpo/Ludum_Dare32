using UnityEngine;
using System.Collections;

public class MoveControler : MonoBehaviour {
	
	public float moveJump; // velocidade do pulo
	public float moveForce; // velocidade para correr
    public float maxSpeed = 5;
	public float amountJump; // Quantidade de pulos possiveis
	private float speed; // velocidade que vai ser passada para fazer o movimento
	private float countJump; // contador dos pulos

	[SerializeField]private Transform grounded; // Objeto para identificar o chao
	[SerializeField]private Transform dontAttackJumped;

	[SerializeField]private GameObject spriteSheet; // Game object quue vai virar de lado (onde tem a sprite do personagem

	private AnimatorControler anim; // Componente da animaçao do personagem
	private AttackControler attackControl; // Componente do attackControl

	[SerializeField]private bool ground;   // chao onde o player esta
	private bool facing;   // face do player
	private bool isJump;   // seta que o player ainda esta no ar depois do pulo
	[SerializeField]private bool dontAttackJump; // verifica se pode atacar pulando

	void Start() {

		this.countJump = 0;
        this.Flip();
		this.anim = GetComponent<AnimatorControler>();
		this.attackControl = GetComponent<AttackControler>();

	}

	public void layerEvents() {

		dontAttackJump = Physics2D.Linecast (transform.position, dontAttackJumped.position, 1 << LayerMask.NameToLayer("Ground"));
		ground = Physics2D.Linecast (transform.position, grounded.position, 1 << LayerMask.NameToLayer("Ground"));

	}

    public void falling()
    {
        
    }

	public void moveCharacter (float h) {

        float _maxSpeed = ground ? maxSpeed : maxSpeed / 1.6f;


        if (h * rigidbody2D.velocity.x < _maxSpeed)
            // ... add a force to the player.
            rigidbody2D.velocity = new Vector2(moveForce * h, rigidbody2D.velocity.y);
            //rigidbody2D.AddForce(Vector2.right * h * moveForce);

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(rigidbody2D.velocity.x) > _maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            //rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * _maxSpeed, rigidbody2D.velocity.y);

        this.anim.setState(StatePlayer.run);

		if( h > 0 && facing) 
			Flip();
		
		else if  ( h < 0 && !facing) 
			Flip();
	}

	public void jumpCharacter ( ) {
		
		if(countJump < amountJump) {
			
			bool _jump = true;
			
			if(_jump) {

                rigidbody2D.AddForce(new Vector2(0f, moveJump));
				anim.setState(StatePlayer.jump);
				isJump = true;
				_jump = false;
				countJump++;
			}
		}
	}
	
	public void checkCharacterMove () {
		
		speed = ground ? moveForce : 1;
		
		// Quando player estiver atacando ele para sua velocidade
		//if(anim.isBlowAttack()) 
		    //rigidbody2D.velocity = new Vector2 (0,0);

		// se o player estiver atacando no ar sua velocidade de decida diminui
		if (anim.isBlowAttackJump())
			rigidbody2D.velocity = new Vector2 (0,rigidbody2D.velocity.y/1.2f);

	    /*
		if( this.dontAttackJump && rigidbody2D.velocity.y < 0 && anim.getCurrentAnimation() != StatePlayer.falling) { 

			EventsPlayer _events = GameObject.Find("spritePlayerSheet").GetComponent<EventsPlayer>();
			_events.isAttackJump();
			anim.setState(StatePlayer.falling);

		}
		*/
		if( ground && !attackControl.IsAttack) {
			
			rigidbody2D.velocity = new Vector2 (0,0);
			anim.setState(StatePlayer.idle);
			countJump = 0;
			isJump = false;
		}
		/*
		if( rigidbody2D.velocity.y < 0 && !anim.isBlowAttackJump()) {
			anim.setState(StatePlayer.falling);
			isJump = true;
		}*/
	}
	
	#region GETTERS and SETTERs

	public bool Ground {
		get {
			return this.ground;
		}
		set {
			ground = value;
		}
	}
	public bool DontAttackJump {
		get {
			return this.dontAttackJump;
		}
		set {
			dontAttackJump = value;
		}
	}

	public bool IsJump {
		get {
			return this.isJump;
		}
		set {
			isJump = value;
		}
	}

	#endregion

	void Flip () {

		// faz a troca da face
		facing = !facing;
		Vector3 theScale = spriteSheet.transform.localScale;
		theScale.x *= -1;
		spriteSheet.transform.localScale = theScale;

	}
	
	public static MoveControler checkMoveControler () {
		
		return GameObject.FindGameObjectWithTag("Player").GetComponent<MoveControler>();
		
	}
}
