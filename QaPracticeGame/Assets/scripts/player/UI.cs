using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public Player player;
	public float messageDisplayTime;
	private float messageTimerHold;
    private CreateUnits creator;
    private string message = "";
	private bool timerStart;
    // Use this for initialization
    void Start()
    {
        creator = player.GetComponent<CreateUnits>();
        creator.setPlayer(player);
		messageTimerHold = messageDisplayTime;
    }

    // Update is called once per frame
    void Update()
    {
		if(message != ""){
			timerStart = true;
		}

		if(timerStart){
			messageDisplayTime -= Time.deltaTime;

			if(messageDisplayTime <= 0){
				message = "";
				timerStart = false;
				messageDisplayTime = messageTimerHold;
			}
		}
    }

    void OnGUI()
    {

        GUI.Label(new Rect(25, 25, 100, 50), "$$$:" + player.getCurrentMoney());


        if (GUI.Button(new Rect(25, Screen.height - 100, 100, 50), "Pixel Creator \n $$$: 100"))
        {
            message = creator.createBuilding(EnumCollection.buildingType.spawner);
        }


        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), message);
    }


}
