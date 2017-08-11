using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnits : MonoBehaviour
{

    public GameObject[] buildings;

    private Player player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPlayer(Player p)
    {
        player = p;
    }


    public string createBuilding(EnumCollection.buildingType building)
    {
        switch (building)
        {
            case EnumCollection.buildingType.spawner:
                return create(buildings[0]);
            default:
                return "";
        }
    }


    private string create(GameObject toBuild)
    {
        BuildingDetails details = toBuild.GetComponent<BuildingDetails>();
        int cost = details.getCost();
        if (player.getCurrentMoney() >= cost)
        {
            //build
            place(toBuild);
            player.deductMoney(cost);
        }
        else
        {
            return "Insufficient Funds";
        }
		return "";
    }

    private void place(GameObject toBuild)
    {

		Debug.Log("Placing");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("player_buildings");
		int i = (int)TargetingUtils.returnRandomFloatFromRange(0,objs.Length);
		GameObject obj = objs[i];
		float x = TargetingUtils.returnRandomFloatFromRange(-10,10);
		float z = TargetingUtils.returnRandomFloatFromRange(-10,10);
		Vector3 bump = new Vector3(x,0,z);
		Instantiate(toBuild, obj.transform.position + bump, Quaternion.identity);
    }
}
