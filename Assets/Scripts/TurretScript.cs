using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float shootInterval = 1f;
    public float shootOffset;
    public Vector3 direction;

    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Shoot",shootInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        if (direction != null)
        {
        newBullet.GetComponent<BulletScript>().direction = direction;
        }
        Invoke("Shoot", shootInterval);
    }
}
