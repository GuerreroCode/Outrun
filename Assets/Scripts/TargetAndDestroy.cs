using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAndDestroy : MonoBehaviour
{
    public int hitpoints = 1;
    public GameObject targetOne;
    public GameObject targetTwo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "PlayerBullet")
        {
            Destroy(collidedWith);
            if (hitpoints > 1)
            {
                hitpoints--;
            }
            else 
            {
                Destroy(targetOne);
                Destroy(targetTwo);
            }
        }
    }
}
