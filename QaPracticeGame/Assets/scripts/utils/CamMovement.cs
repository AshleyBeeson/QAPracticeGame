using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{

    private GameObject player;

    public bool follow;
    public float moveSpeed, cameraZoomSpeed;

    private float moveStep;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moveStep = moveSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        zoom();
        if (follow)
        {
            followPlayer();
        }
        else
        {
            move();
        }
    }


    private void move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-moveStep, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(moveStep, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0, 0, moveStep);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(0, 0, -moveStep);
        }
    }

    private void zoom()
    {
        float lower = 5, upper = 100;
        if (this.transform.position.y >= lower && this.transform.position.y <= upper)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                this.transform.position -= new Vector3(0, cameraZoomSpeed * Time.deltaTime, 0);
                this.transform.position = isWithinbounds(this.transform, lower, upper);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                this.transform.position += new Vector3(0, cameraZoomSpeed * Time.deltaTime, 0);
                this.transform.position = isWithinbounds(this.transform, lower, upper);
            }
        }
    }

    private void followPlayer()
    {
        Vector3 playerPos = player.transform.position;
        playerPos.y = this.transform.position.y;
        this.transform.position = playerPos;
    }

    private Vector3 isWithinbounds(Transform transform, float lowerBounds, float upperBounds)
    {
        float yPos = transform.position.y;
        if (yPos < lowerBounds)
        {
            return new Vector3(transform.position.x, lowerBounds, transform.position.z);
        }
        else if (yPos > upperBounds)
        {
            return new Vector3(transform.position.x, upperBounds, transform.position.z);
        }
        else
        {
            return transform.position;
        }
    }

}
