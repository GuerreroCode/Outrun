using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathBeamScript : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public float speed = 1f;
    public float speedRate = 2f;
    public bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (isActive)
            transform.position +=  direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider coll)
    {   
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Enemy")
        {
            Destroy(collidedWith);
        }
        else if (collidedWith.tag == "Player")
        {
            Destroy(collidedWith);
            Invoke("MainScreen", 2f);
        }
        if (collidedWith.tag == "Checkpoint")
        {
            speed += speedRate;
            Destroy(collidedWith);
        }

    }
    void MainScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
