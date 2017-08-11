using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{

    private GameObject[] enemyStore;

    public EnumCollection.UnitType pixelType;
    public float moveSpeed, damage, attackSpeed, maxHealth;
    private float moveStep, attackSpeedHold;
    private Health health;
    private string enemyTag;
	private bool hit;
    // Use this for initialization
    void Start()
    {
        health = this.gameObject.AddComponent(typeof(Health)) as Health;
        health.setHealth(maxHealth, this.name);
        moveStep = moveSpeed * Time.deltaTime;
        string t = pixelType.ToString();
        if (t.Equals("player"))
        {
            enemyTag = "enemy";
        }
        else
        {
            enemyTag = "Player";
        }
		hit = false;
        // Debug.Log(this.gameObject.name + ": t is: " + t);
        // Debug.Log(this.gameObject.name + ": type is: " + pixelType);
        // Debug.Log(this.gameObject.name + ": enemy is: " + enemyTag);
    }

    // Update is called once per frame
    void Update()
    {
		// Debug.Log(this.gameObject.name + ": health is: " + health.getRemainingHealth());
        enemyStore = TargetingUtils.findGameobjectsWithTag(enemyTag);
        movement();
    }

    private void movement()
    {
        GameObject closestTarget = TargetingUtils.findClosestTarget(this.transform, enemyStore);
        if (closestTarget != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, closestTarget.transform.position, moveStep);
        }
    }

    void OnCollisionStay(Collision col)
    {
        attackSpeed -= Time.deltaTime;
        if (attackSpeed <= 0)
        {
			hit = true;
            if (col.gameObject.tag == enemyTag && hit)
            {
				attackSpeed = attackSpeedHold;
                Health objectHealth = col.gameObject.GetComponent<Health>();
                objectHealth.damage(damage);
				hit = !hit;
            }
		
        }
    }





   








}
