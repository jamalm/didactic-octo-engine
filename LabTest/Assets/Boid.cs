using UnityEngine;
/*
public class Boid : MonoBehaviour
{
    public Vector3 Force = Vector3.zero;
    public Vector3 Acceleration = Vector3.zero;
    public Vector3 Velocity = Vector3.zero;
    SteeringBehaviour[] behaviours;
    public float Mass = 1;
    public float MaxVelocity = 5.0f;
    // Use this for initialization
    void Start()
    {
        behaviours = GetComponents<SteeringBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        Force = CalculateForces();

        Vector3 newAcceleration = Force / Mass;
        float smoothRate = Mathf.Clamp(9.0f * Time.deltaTime, 0.15f, 0.4f) / 2.0f;
        Acceleration = Vector3.Lerp(Acceleration, newAcceleration, smoothRate);

        //velocity is accumulated acceleration over time
        Velocity += Acceleration * Time.deltaTime;

        //vel is clamped to max velocity
        Velocity = Vector3.ClampMagnitude(Velocity, MaxVelocity);

        //dampen velocity
        if (Velocity.magnitude > 0.0001f)
        {
            //if we are moving
            Velocity *= 0.99f;
        }
        transform.position += Velocity * Time.deltaTime;
    }

    Vector3 CalculateForces()
    {
        Force = Vector3.zero;
        foreach (SteeringBehaviour b in behaviours)
        {
            if (b.isActiveAndEnabled)
                Force += b.Calculate();
        }
        return Force;
    }
}
*/
public class Boid : MonoBehaviour
{
    SteeringBehaviour[] behaviours;
    Vector3 force = Vector3.zero;
    Vector3 acceleration = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    public float mass = 1;
    public float maxvelocity = 5.0f;
    // Use this for initialization
    void Start()
    {
        behaviours = GetComponents<SteeringBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        force = CalculateForces();

        Vector3 newacc = force / mass;
        float smoothRate = Mathf.Clamp(9.0f * Time.deltaTime, 0.15f, 0.4f) / 2.0f;
        acceleration = Vector3.Lerp(acceleration, newacc, smoothRate);

        velocity += acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maxvelocity);
        //dampen
        if(velocity.magnitude > 0.0001f)
        {
            velocity *= 0.99f;
        }

        transform.position += velocity * Time.deltaTime;
    }

    Vector3 CalculateForces()
    {
        force = Vector3.zero;
        foreach(SteeringBehaviour b in behaviours)
        {
            if(b.isActiveAndEnabled)
                force += b.Calculate();
        }
        return force;
    }

    public Vector3 SeekForce(Vector3 target)
    {
        return (((target - transform.position).normalized) * maxvelocity) - velocity;
    }

    public Vector3 FleeForce(Vector3 target)
    {
        return (((transform.position - target).normalized) * maxvelocity) - velocity;
    }
}
