using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public float currentRotation;
    public float rotationSensitivity = 20;
    public float speed=3.5f;
    public List<Transform> bodyParts = new List<Transform>();
    public Sprite spriteTete;

    void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().sprite = spriteTete;
    }
    void Update()
    {
        
        transform.Translate(new Vector2(0, speed) * Time.deltaTime);
        


        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
            currentRotation -= rotationSensitivity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-speed, 0) * Time.deltaTime);
            currentRotation += rotationSensitivity * Time.deltaTime;
        }

    }

    void Rotation()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentRotation));
    }
    

    public Material vert, bleu;
    void ColorationSnake()
    {
        for(int i = 0; i < bodyParts.Count; i++)
        {
            if(i%2 == 0)
            {
                bodyParts[i].GetComponent<Renderer>().material = vert;
            }
            else
            {
                bodyParts[i].GetComponent<Renderer>().material = bleu;
            }
        }
    }

    [Range(0.0f, 1.0f)]
    public float smoothTime = 0.5f;
    void CameraFollow()
    {
        Transform camera = GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform;
        Vector3 cameraVelocity = Vector3.zero;
        camera.position = Vector3.SmoothDamp(camera.position,
                                             new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -speed), ref cameraVelocity, smoothTime);
    }

    public Transform bodyObjet;
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("Orb"))
        {
            other.gameObject.SetActive(false);
            if (bodyParts.Count == 0)
            {
                Vector3 currentPos = transform.position;
                Transform newBodyPart = Instantiate(bodyObjet, currentPos, Quaternion.identity) as Transform;
                newBodyPart.transform.parent = transform.parent;
                bodyParts.Add(newBodyPart);
            }
            else
            {
                Vector3 currentPos = bodyParts[bodyParts.Count - 1].position;
                Transform newBodyPart = Instantiate(bodyObjet, currentPos, Quaternion.identity) as Transform;
                newBodyPart.transform.parent = transform.parent;
                bodyParts.Add(newBodyPart);
            }
        }

        if (other.gameObject.CompareTag("Ennemis"))
        {
            other.gameObject.SetActive(false);
            //GameObject.Destroy(other);
            //GameObject.Destroy(gameObject);
            gameObject.SetActive(false);

            for (int i=0;i<bodyParts.Count;i++)
				
            {
                //Destroy(bodyParts[i].GetComponent<Body>().gameObject); 
                bodyParts[i].GetComponent<Body>().gameObject.SetActive(false);
            }
			SceneManager.LoadScene ("Loose", LoadSceneMode.Additive);
        }
    }


    public float NombreOrbParSeconde;

    public GameObject Orb;
    void GestionSpawnOrb()
    {
        StartCoroutine("ChaqueSecondes",NombreOrbParSeconde);
    }

	public float nbOrb {

		set {
			float nbOrbs = value;
			NombreOrbParSeconde = nbOrbs;
			GestionSpawnOrb ();

		}
		get {
			return NombreOrbParSeconde;
		}

	}




    IEnumerator ChaqueSecondes(float x)
    {
        yield return new WaitForSeconds(x);
        StopCoroutine("ChaqueSecondes");
        Vector3 randomOrbPosition = new Vector3(Random.Range(Random.Range(GameObject.Find("TêteSnake").transform.position.x - 50, GameObject.Find("TêteSnake").transform.position.x - 20), Random.Range(GameObject.Find("TêteSnake").transform.position.x + 20, GameObject.Find("TêteSnake").transform.position.x + 50))
            ,Random.Range(Random.Range(GameObject.Find("TêteSnake").transform.position.y - 50, GameObject.Find("TêteSnake").transform.position.y - 20), Random.Range(GameObject.Find("TêteSnake").transform.position.y + 20, GameObject.Find("TêteSnake").transform.position.y + 50))
            ,0);

        GameObject nouvelleOrb = Instantiate(Orb, randomOrbPosition, Quaternion.identity) as GameObject;

        GameObject orbParent = GameObject.Find("Pilules");

        nouvelleOrb.transform.parent = orbParent.transform; 
    }

    void FixedUpdate()
    {
        Rotation();
        CameraFollow();
        ColorationSnake();
        GestionSpawnOrb();
    }
}
