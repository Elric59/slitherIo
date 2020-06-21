using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyEnnemis2 : MonoBehaviour
{

    private int indice;
    private Transform head;

    void Start()
    {
        head = gameObject.transform.parent.GetChild(0);

        if (head.GetComponent<ActionsEnnemis2>().bodyEnnemis.Count!=null)
        {
            for (int i = 0; i < head.GetComponent<ActionsEnnemis2>().bodyEnnemis.Count; i++)
            {
                Debug.Log(head.GetComponent<ActionsEnnemis2>().bodyEnnemis.Count);
                if (gameObject == head.GetComponent<ActionsEnnemis2>().bodyEnnemis[i].gameObject)
                {
                    indice = i;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //GameObject.Destroy(other);
            other.gameObject.SetActive(false);
            for (int i = 0; i < GetComponent<Snake>().bodyParts.Count; i++)
            {
                //Destroy(bodyEnnemis[i].GetComponent<bodyEnnemis>().gameObject);
                GetComponent<Snake>().bodyParts[i].gameObject.SetActive(false);
            }
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
            transform.position = Vector3.SmoothDamp(transform.position, head.GetComponent<ActionsEnnemis2>().bodyEnnemis[indice - 1].position, ref movementVelocity, time);

            transform.LookAt(head.transform.position);
        }
    }
}

