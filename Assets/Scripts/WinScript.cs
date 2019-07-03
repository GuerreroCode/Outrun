using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public int level = 0;
    public bool win = false;
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
        if (collidedWith.tag == "Player")
        {   if (win)
            {
                SceneManager.LoadScene("_Win_Screen");
            }
            else 
            {
                SceneManager.LoadScene("_Scene_" + level);
            }
        }
    }
}
