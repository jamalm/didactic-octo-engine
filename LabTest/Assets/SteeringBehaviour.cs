using UnityEngine;
using System.Collections;

public abstract class SteeringBehaviour : MonoBehaviour
{
    public Boid boid;
    public GameObject target;
    // Use this for initialization
    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract Vector3 Calculate();
}
