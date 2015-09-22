using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MovimentBehaviour : MonoBehaviour 
{
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        this.rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void move(float velocity)
    {
        this.rigidbody2D.velocity = new Vector2(velocity * 1, rigidbody2D.velocity.y);
    }
    public void move(float velocity_x, float velocity_y)
    {
        this.rigidbody2D.velocity = new Vector2(velocity_x * 1, velocity_y);
    }

    public void addForce(float forceImpulse)
    {
        this.rigidbody2D.AddForce(new Vector2(forceImpulse, 0), ForceMode2D.Impulse);
    }

    public void stop()
    {
        this.rigidbody2D.velocity = new Vector2(0,0);
    }
}
