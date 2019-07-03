using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public int hitpoints = 10;
    public Vector3 stationPos;
    public DeathBeamScript deathBeam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider coll)
    {   
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "PlayerBullet")
        {
            if (hitpoints > 0)
            {
                hitpoints--;
            }
            else 
            {
                Destroy(this.gameObject);
                deathBeam.isActive = true;
            }
        }

    }
}
