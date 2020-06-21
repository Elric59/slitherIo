using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyEnnemis : MonoBehaviour
{

    private int indice;
    private Transform head;

    void Start()
    {
        head = GameObject.FindWithTag("Ennemis").transform;     //récupère l'objet tagué "Ennemis" et le stock dans la variable head
        for (int i = 0; i < head.GetComponent<ActionsEnnemis>().bodyEnnemis.Count; i++) 
        {
            if (gameObject == head.GetComponent<ActionsEnnemis>().bodyEnnemis[i].gameObject)
            {
                indice = i; //Mets 
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
        if (indice == 0)
        {
            transform.position = Vector3.SmoothDamp(transform.position, head.position, ref movementVelocity, time);
            transform.LookAt(head.transform.position);

        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, head.GetComponent<ActionsEnnemis>().bodyEnnemis[indice - 1].position, ref movementVelocity, time);
            transform.LookAt(head.transform.position);
        }
    }
}

