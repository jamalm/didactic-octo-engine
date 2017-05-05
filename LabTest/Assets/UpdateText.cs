using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateText : MonoBehaviour {
    Atom atom;
    
	// Use this for initialization
	void Start () {
        atom = GetComponent<Atom>();
        SetText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetText()
    {
        string atomType = atom.atom;
        string elecShell = atom.electronsPerShell;
        atom.GetComponent<TextMesh>().text = atomType + "\n" + elecShell;
    }
}
