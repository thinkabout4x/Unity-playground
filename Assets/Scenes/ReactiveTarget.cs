using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactToHit(){
        WanderingAI behaviour = GetComponent<WanderingAI>();
        if (behaviour != null){
            behaviour.SetIsAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die(){
        this.transform.Rotate(-75,0,0);
        
        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
