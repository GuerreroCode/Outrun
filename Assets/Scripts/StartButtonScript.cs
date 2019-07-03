using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButtonScript : MonoBehaviour
{
    public GameObject player;
    public bool moving = false;
    public Vector3 direction = Vector3.forward;
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
            player.transform.position +=  direction * speed * Time.deltaTime;
    }

    public void onClick()
    {
        Invoke("playGame", 1f);
        moving = true;
        
    }
    private void playGame()
    {
        SceneManager.LoadScene("_TEST");
    }
}
