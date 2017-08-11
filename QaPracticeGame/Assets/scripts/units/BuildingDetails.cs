using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDetails : MonoBehaviour {


	public string name;
	public int cost;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string getName(){
		return name;
	}
    public int getCost()
    {
        return cost;
    }
}
