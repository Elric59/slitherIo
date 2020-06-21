using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject enemy;
    public int NombreEnnemisTotal;
    public int nbEnnemisActuel;
    private Rigidbody2D rb2d;
    public List<string> nomEnnemis = new List<string>();
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        nbEnnemisActuel = GameObject.FindGameObjectsWithTag("Ennemis").Length;
        for (int i = 0; i < NombreEnnemisTotal; i++)
        {
            var go = new GameObject("ParentEnnemis" + i);
            go.transform.parent = GameObject.Find("GestionEnnemis").transform;
        }
    }
// Erreur a partir d'ici potenciellement
	public int ennemi{
		set{
			
			NombreEnnemisTotal=value;

		}
		get{
			return  NombreEnnemisTotal;

		}
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (nbEnnemisActuel < NombreEnnemisTotal)
        {
            GestionSpawnEnnemi();
            nbEnnemisActuel++;
        }
    }


    void GestionSpawnEnnemi()
    {
        float x = Random.Range(Random.Range(GameObject.Find("TêteSnake").transform.position.x - 150, GameObject.Find("TêteSnake").transform.position.x - 50), Random.Range(GameObject.Find("TêteSnake").transform.position.x + 50, GameObject.Find("TêteSnake").transform.position.x + 150));
        float y = Random.Range(Random.Range(GameObject.Find("TêteSnake").transform.position.y - 150, GameObject.Find("TêteSnake").transform.position.y - 50), Random.Range(GameObject.Find("TêteSnake").transform.position.y + 50, GameObject.Find("TêteSnake").transform.position.y + 150));

        Vector3 randomEnnemiPosition = new Vector3(x, y, -2);

        GameObject nouveauEnnemi = Instantiate(enemy, randomEnnemiPosition, Quaternion.identity) as GameObject;
        nouveauEnnemi.name = "Ennemis" + nbEnnemisActuel;
        nomEnnemis.Add(nouveauEnnemi.name);
        nouveauEnnemi.transform.parent = GameObject.Find("ParentEnnemis" + nbEnnemisActuel).transform;
    }
}

