using UnityEngine;
using System.Collections;
using System;

public class Seek : SteeringBehaviour
{
    public override Vector3 Calculate()
    {
        return boid.SeekForce(target.transform.position);
    }

    // Use this for initialization
    void Start()
    {
        boid = GetComponent<Boid>();
        target = GameObject.FindGameObjectWithTag("Proton");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
