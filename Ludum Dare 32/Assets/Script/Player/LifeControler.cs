using UnityEngine;
using System.Collections;

public class LifeControler : MonoBehaviour {

	[SerializeField]
    private float life;
	private float currentLife;
	private AnimatorControler animation;

	void Awake () {

		animation = GetComponent<AnimatorControler>();
		life = 100;
        currentLife = life;
	}

	public void addLife( float value) {

		currentLife += value;

		if(currentLife >= life)
			currentLife = life;

	}

	public void removeLife ( float value) {
		currentLife -= value;

		if(currentLife <= 0) 
        {
			currentLife = -1;
			animation.setState(StatePlayer.dead);
		}
        else
        {
            animation.setState(StatePlayer.hit);
        }
	}
}
