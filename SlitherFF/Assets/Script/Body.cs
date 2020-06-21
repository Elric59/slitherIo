using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    private int indice;
    private Transform head;

    void Start(){
        head = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        for (int i = 0; i < head.GetComponent<Snake>().bodyParts.Count; i++)
        {
            if(gameObject == head.GetComponent<Snake>().bodyParts[i].gameObject){             
                indice = i;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ennemis"))
        { 
            GameObject.Destroy(other.gameObject);
        }
    }
    private Vector3 movementVelocity;
    [Range(0.0f, 1.0f)]
    public float time = 0.5f;
    void FixedUpdate()
    {
        if(indice==0){
            transform.position = Vector3.SmoothDamp(transform.position, head.position, ref movementVelocity, time);
            transform.LookAt(head.transform.position);

        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, head.GetComponent<Snake>().bodyParts[indice - 1].position, ref movementVelocity, time);
            transform.LookAt(head.transform.position);
        }
    }
}

