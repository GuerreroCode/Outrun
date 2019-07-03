using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public float lastShootTime = 0f;
    public float shootInterval = 0.05f;
    public GameObject BulletPrefab;
    public AudioSource blastSound;
    public PlayerScript player;
    //directions 0 up, 1 left, 2 right
    private Vector3[] directions = new Vector3[] {new Vector3(0, 0, 1), new Vector3(0.1f, 0, 1), new Vector3(-0.1f, 0, 1)};
    void Start()
    {
    }


    void Update()
    {
        bool fire = Input.GetKeyDown(KeyCode.Space);

        if (fire)
        {
            blastSound.Play();
            lastShootTime = Time.time;
            switch (player.numCannons)
            {
                case 1:
                    GameObject newBulletFront = Instantiate(BulletPrefab, transform.position, transform.rotation);
                    newBulletFront.GetComponent<BulletScript>().direction = directions[0];
                    if (player.numCannons == 3)
                        goto case 2;
                    else
                        break;
                case 2:
                    GameObject newBulletLeft = Instantiate(BulletPrefab, transform.position, transform.rotation);
                    newBulletLeft.GetComponent<BulletScript>().direction = directions[1];
                    if (player.numCannons == 2)
                        goto case 3;
                    else
                        break;
                case 3:
                    GameObject newBulletRight = Instantiate(BulletPrefab, transform.position, transform.rotation);
                    newBulletRight.GetComponent<BulletScript>().direction = directions[2];
                    if (player.numCannons == 3)
                        goto case 1;
                    else
                        break;
                default: 
                    break;
            }
            
            
        }
        
    }
}
