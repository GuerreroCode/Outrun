using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
   public float xDirectionFactor = 1.0f;
    public float xMax = 5f;
    public float xMin = -5f;
    public float xSpeed = 5f;

    public float ySpeed = -.25f;
    public float shootInterval = 1f;
    public float shootOffset;
    public bool patternShooting = true;
    public float xPosition;
    public GameObject BulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        xMax += transform.position.x;
        xMin += transform.position.x;
        shootOffset = Random.Range(0.1f, 0.5f);
        Invoke("Shoot", shootOffset + shootInterval);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position; 
        pos.x += xDirectionFactor * xSpeed * Time.deltaTime;
        if (pos.x > xMax)
        {
            pos.x = xMax;
            xDirectionFactor = -1.0f;
        }
        else if (pos.x < xMin)
        {
            pos.x = xMin;
            xDirectionFactor = 1.0f;
        }
        transform.position = pos;
        xPosition = transform.position.x;
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        if (patternShooting)
            {
                Invoke("Shoot", shootInterval);
            }
        else
        {
            Invoke("Shoot", Random.Range(0.1f, shootInterval));
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
    
        if (collidedWith.tag == "PlayerBullet")
        {
            Destroy(collidedWith);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Environment" || collidedWith.tag == "Item")
        {
            xDirectionFactor *= -1.0f;
        }
        if (collidedWith.tag == "Player")
        {
            Destroy(collidedWith);
            Invoke("MainScreen", 2f);
        }
    }
    void MainScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
