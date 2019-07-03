using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    // Start is called before the first frame update

    public static float minVelocity = 0f;
    public float maxVelocity = 25f;
    public float curYVelocity = 0f;
    public float curXVelocity = 0f;
    public float maxXrotation = 30f;
    public float curXrotation = 0f;
    public float XrotationRate = 5f;
    public const float accelRate = 5f;
    public const float breakRate = 1f;
    public int numCannons = 1;
    public static int maxCannons = 3;
    public Vector3 pos;
    public Quaternion rot;
    public bool moveForward = false;

    void Start()
    {
        rot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        // Y axis movemont
        if (yAxis > 0 && curYVelocity < maxVelocity)
        {
            curYVelocity += accelRate;
            
        }
        else if (yAxis < 0 && curYVelocity > (-maxVelocity))
        {
            curYVelocity -= accelRate;
        }

        else if (yAxis == 0)
        {
            if (curYVelocity > minVelocity)
            {
                curYVelocity -= breakRate;
            }
            else if (curYVelocity < minVelocity)
            {
                curYVelocity += breakRate;
            }
        }

        //FOR STARTUP
        if (moveForward)
        {
            curYVelocity += accelRate;
        }

        //X axis movement
        if (xAxis > 0)
        {
            if(curXVelocity < maxVelocity)
            {
                curXVelocity += accelRate;
            }

            if (curXrotation > (-maxXrotation))
            {
                curXrotation -= XrotationRate;
            }
        }
        else if (xAxis < 0) 
        {
            if(curXVelocity > (-maxVelocity))
            {
                curXVelocity -= accelRate;
            }

            if (curXrotation < maxXrotation)
            {
                curXrotation += XrotationRate;
            }
        }

        else if (xAxis == 0)
        {
            if (curXVelocity > minVelocity)
            {
                curXVelocity -= breakRate;
            }
            else if (curXVelocity < minVelocity)
            {
                curXVelocity += breakRate;
            }

            if (curXrotation < 0)
            {
                curXrotation += XrotationRate;
            }
            else if (curXrotation > 0)
            {
                curXrotation -= XrotationRate;
            }
        }
            
        
        // apply all transfromations
        Vector3 YV3 = Vector3.forward;
        Vector3 XV3 = Vector3.right;
        
        YV3 = transform.rotation * YV3;      
        pos += YV3 * Time.deltaTime * curYVelocity;
        pos += XV3 * Time.deltaTime * curXVelocity;
        rot.z = curXrotation * Time.deltaTime;
        transform.rotation = rot;
        transform.position = pos;
    }
}
