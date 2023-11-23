using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public float sphereRange = 0.75f;
    private bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive){
            transform.Translate(0,0,speed*Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, sphereRange, out hit)){
                if (hit.distance < obstacleRange){
                    float angle = Random.Range(-110,110);
                    transform.Rotate(0,angle,0);
                } 
            }
        }
    }

    public void SetIsAlive(bool alive){
        isAlive = alive;
    }

}
