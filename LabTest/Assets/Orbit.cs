using UnityEngine;
using System.Collections;
using System;

public class Orbit : SteeringBehaviour
{
    public GameObject pointCube;
    public Vector3[] points;
    public Vector3 currTarget;
    public int index = 0;
    public float radius;
    

    public override Vector3 Calculate()
    {
        
        //float distance = (target.transform.position - transform.position).magnitude;
        if (Vector3.Distance(currTarget, transform.position) < 5)
        {
            currTarget = NextPoint();
        }/*
        if(Vector3.Distance(target.transform.position, transform.position) > radius)
        {
            return boid.SeekForce(target.transform.position);
        }
        else if(Vector3.Distance(target.transform.position, transform.position) < radius)
        {
            return boid.FleeForce(target.transform.position);

        }*/

        return boid.SeekForce(currTarget);
       
    }

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Proton");
        boid = GetComponent<Boid>();
        points = CirclePoints(target.transform.position, radius, 36.0f);
        currTarget = points[0];
        for(int i=0;i<points.Length;i++)
        {
            if(Vector3.Distance(points[i], transform.position) < Vector3.Distance(currTarget, transform.position))
            {
                currTarget = points[i];
                index = i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 NextPoint()
    {
        if(index == points.Length-1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        return points[index];
    }



    Vector3[] CirclePoints(Vector3 center, float radius, float ang)
    {
        float angle = ang;
        int segs = (int) (360.0f / ang);
        Vector3[] points = new Vector3[segs];
        for(int i=0;i<segs;i++)
        {
            angle = ang * i;
            Vector3 point;
            point.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            point.z = center.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            point.y = center.y;
            points[i] = point;
            //Instantiate(pointCube, point, Quaternion.identity);
            
        }
        return points;
    }
}
