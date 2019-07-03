using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public float speed = 20f;
    public float lifetime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        lifetime += Time.time;
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position +=  direction * speed * Time.deltaTime;
        if (lifetime < Time.time)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider coll)
    {   
        GameObject collidedWith = coll.gameObject;
        Destroy(this.gameObject);

    }
}
