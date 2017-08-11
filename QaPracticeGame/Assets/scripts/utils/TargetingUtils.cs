using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingUtils : MonoBehaviour
{

    public static GameObject findClosestTargetWithinRange(Transform transform, GameObject[] objs, float range)
    {
        GameObject closest = null;
        Vector3 position = transform.position;
        foreach (GameObject go in objs)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < range)
            {
                closest = go;
                range = curDistance;
            }
        }
        return closest;
    }

    public static GameObject findClosestTarget(Transform transform, GameObject[] objs)
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in objs)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }


    public static GameObject[] findGameobjectsWithTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }


    public static float returnRandomNumber(){
        Random rnd = new Random();
    
    }

    public static float returnRandomFloatFromRange(float lower, float upper)
    {
        return Random.Range(lower, upper);
    }


}
