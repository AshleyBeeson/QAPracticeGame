using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel_Creator : MonoBehaviour
{

    public EnumCollection.UnitType type;

    public GameObject[] pixels;

    public float spawnTime;

    private float spawnThold;
    private string pixelType;

    // Use this for initialization
    void Start()
    {
        spawnThold = spawnTime;
        pixelType = type.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            spawnPixel();
            spawnTime = spawnThold;
        }
    }

    private void spawnPixel()
    {
        Vector3 bump = new Vector3(0, 0, z: 0.1f);
        if (pixelType.Equals("player"))
        {
            GameObject clone = pixels[0];
            clone.name = "Player_Pixel_" + TargetingUtils.returnRandomFloatFromRange(0, 1000000000);
            Instantiate(clone, this.transform.position + bump, Quaternion.identity);
        }
        else
        {
            GameObject clone = pixels[1];
            clone.name = "Enemy_Pixel_" + TargetingUtils.returnRandomFloatFromRange(0, 1000000000);
            Instantiate(clone, this.transform.position + bump, Quaternion.identity);
        }

    }
}
