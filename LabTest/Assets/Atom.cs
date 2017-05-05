using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public string electronsPerShell;
    public string atom;
    public GameObject protonPrefab;
    public GameObject electronPrefab;

    public int[] shells;
    float shellRadius = 20.0f;


    // Use this for initialization
    void Start()
    {
        ParseElectronData();
        CreateElectrons();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ParseElectronData()
    {
        //get each electron separately
        string[] electrons = electronsPerShell.Split(',');
        //number of shells is the same as the electrons
        shells = new int[electrons.Length];

        for (int i = 0; i < electrons.Length; i++)
        {
            shells[i] = int.Parse(electrons[i]);
        }
    }
    void CreateElectrons()
    {
        for (int i = 0; i < shells.Length; i++)
        {
            //get the segments of the circle
            float angle = 360 / shells[i];
            for (int j = 0; j < shells[i]; j++)
            {

                Vector3 pos = CirclePoints(transform.position, shellRadius * (i + 1), angle + (angle * j));
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, transform.position - pos);

                GameObject electron = Instantiate(electronPrefab, pos, rot);
                electron.GetComponent<Orbit>().radius = shellRadius * (i + 1);
                electron.GetComponent<Boid>().maxvelocity = ((shellRadius * (i + 1))+(i+1)) / 2;
                electron.transform.SetParent(transform);

            }
        }

        GameObject proton = Instantiate(protonPrefab, transform.position, Quaternion.identity);
        proton.transform.SetParent(transform);

    }
    


    Vector3 CirclePoints(Vector3 center, float radius, float angle)
    {

        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.z = center.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        pos.y = center.y;
        return pos;
    }
}
