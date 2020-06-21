using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsEnnemis : MonoBehaviour {
    public List<GameObject> Ennemis = new List<GameObject>();
    public List<Transform> bodyEnnemis = new List<Transform>();
    private float currentRotation=2;
    private float rotationSensitivity = 200;
    private int speed = 8;
    // Use this for initialization
    void Start()
    {

    }


    void Rotation()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentRotation));
    }

    public Material vert, bleu;
    void ColorationSnake()
    {
        for (int i = 0; i < bodyEnnemis.Count; i++)
        {
            if (i % 2 == 0)
            {
                bodyEnnemis[i].GetComponent<Renderer>().material = vert;
            }
            else
            {
                bodyEnnemis[i].GetComponent<Renderer>().material = bleu;
            }
        }
    }
    public Transform bodyObjet;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Orb"))
        {
            
            if (bodyEnnemis.Count == 0)
            {
                Vector3 currentPos = GameObject.Find(gameObject.name).transform.position;
                Transform newBodyEnnemis = Instantiate(bodyObjet, currentPos, Quaternion.identity) as Transform;
                newBodyEnnemis.transform.parent = transform;
                bodyEnnemis.Add(newBodyEnnemis);
            }
            else
            {
                Vector3 currentPos = bodyEnnemis[bodyEnnemis.Count-1].position;
                Transform newBodyEnnemis = Instantiate(bodyObjet, currentPos, Quaternion.identity) as Transform;
                newBodyEnnemis.transform.parent = transform;
                bodyEnnemis.Add(newBodyEnnemis);
            }
        }

        if (other.gameObject.CompareTag("Player"))
        {
            //GameObject.Destroy(other);
            other.gameObject.SetActive(false);
            for (int i = 0; i < bodyEnnemis.Count; i++)
            {
                //Destroy(bodyEnnemis[i].GetComponent<bodyEnnemis>().gameObject);
                bodyEnnemis[i].GetComponent<bodyEnnemis>().gameObject.SetActive(false);
            }
        }

        if (other.gameObject.CompareTag("CorpsPlayer"))
        {
            gameObject.SetActive(false);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        //ColorationSnake();
        int x = Random.Range(0,360);
        transform.Translate(new Vector2(0, speed) * Time.deltaTime);
        if (x<(360/2))
        {
            transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
            currentRotation -= rotationSensitivity * Time.deltaTime;
        }
        else
        {
            transform.Translate(new Vector2(-speed, 0) * Time.deltaTime);
            currentRotation += rotationSensitivity * Time.deltaTime;
        }

        if ((transform.position.x - GameObject.Find("TêteSnake").transform.position.x>-150  || transform.position.x - GameObject.Find("TêteSnake").transform.position.x < 150)&& (transform.position.y - GameObject.Find("TêteSnake").transform.position.y >-150 || transform.position.y - GameObject.Find("TêteSnake").transform.position.y < 150))
			
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("TêteSnake").transform.position,(speed*Time.deltaTime));
        }
    }

    void FixedUpdate()
    {
        Rotation();
    }
}
