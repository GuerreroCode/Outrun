using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerResources : MonoBehaviour
{
    public int maxHitpoints = 5;
    public int curHitpoints;
    public Slider hitpointSlider;
    public PlayerScript player;
    public static float velocityIncrease = 1f;


    // Start is called before the first frame update
    void Start()
    {
        curHitpoints = maxHitpoints;
        player = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeHit()
    {
        curHitpoints--;
        hitpointSlider.value = curHitpoints;
        if (curHitpoints == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }

    }

    private void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "EnemyBullet")
        {
           TakeHit();
        }
        else if (collidedWith.tag == "Item")
        {
            ItemScript item = coll.GetComponent<ItemScript>();

            if (item == null)
            {
                return;
            }

            switch (item.itemType)
            {
                case ItemScript.eType.health:
                    if (curHitpoints == maxHitpoints)
                        return;
                    curHitpoints = maxHitpoints;
                    hitpointSlider.value = curHitpoints;
                    break;
                case ItemScript.eType.cannon:
                    if (player.numCannons < 3)
                        player.numCannons++;
                    break;
                case ItemScript.eType.speed:
                    player.maxVelocity += velocityIncrease;
                    break;
            }
        Destroy(coll.gameObject);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Item")
        {
            ItemScript item = collidedWith.GetComponent<ItemScript>();

            if (item == null)
            {
                return;
            }

            switch (item.itemType)
            {
                case ItemScript.eType.health:
                    if (curHitpoints == maxHitpoints)
                        return;
                    curHitpoints = maxHitpoints;
                    hitpointSlider.value = curHitpoints;
                    break;
                case ItemScript.eType.cannon:
                    if (player.numCannons < 3)
                        player.numCannons++;
                    break;
                case ItemScript.eType.speed:
                    player.maxVelocity += velocityIncrease;
                    break;
            }
        Destroy(coll.gameObject);
        }
    }

}
