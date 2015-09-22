using UnityEngine;
using System.Collections;
[RequireComponent(typeof(MovimentBehaviour))]
public class SpeedObjectBehaviour : MonoBehaviour 
{
    private MovimentBehaviour move;
    private float velocity = 0;

    void Start()
    {
        this.move = GetComponent<MovimentBehaviour>();
        Destroy(this.gameObject, 4f);
    }
	void Update () 
    {
        this.move.move(velocity, -0.7f);
	}

    public void addVelocity(float _velocity)
    {
        this.velocity = _velocity;
    }
}
