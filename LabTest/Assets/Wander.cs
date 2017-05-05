using System;
using UnityEngine;

public class Wander : SteeringBehaviour {

    public float radius = 5;
    public float distance = 15;
    public float jitter = 5;

    private new Vector3 randTarget;
    // Use this for initialization
    void Start()
    {
        boid = GetComponent<Boid>();
        randTarget = UnityEngine.Random.insideUnitSphere * radius;
    }
    public override Vector3 Calculate()
    {
        float jtime = jitter * Time.deltaTime;
        Vector3 displacement = jtime * UnityEngine.Random.insideUnitSphere;
        randTarget += displacement;
        randTarget.Normalize();
        randTarget *= radius;

        Vector3 localTarget = randTarget + (Vector3.forward * distance);
        Vector3 worldTarget = transform.TransformPoint(localTarget);
        return worldTarget - transform.position;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
