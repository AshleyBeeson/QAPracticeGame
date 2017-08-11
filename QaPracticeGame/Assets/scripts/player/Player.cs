using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int currentMoney;
    public int startingAmount,incomeAmount;
    public float incomeTimer;
    private float incomeTimerHold;

    // Use this for initialization
    void Start()
    {
        incomeTimerHold = incomeTimer;
		currentMoney = startingAmount;
    }

    // Update is called once per frame
    void Update()
    {
		addPassiveIncome();
    }

    public int getCurrentMoney()
    {
        return currentMoney;
    }


    private void addPassiveIncome()
    {
        incomeTimer -= Time.deltaTime;
        if (incomeTimer <= 0)
        {
            currentMoney += incomeAmount;
			incomeTimer = incomeTimerHold;
        }
    }

    internal void deductMoney(int cost)
    {
        currentMoney -= cost;
    }
}
