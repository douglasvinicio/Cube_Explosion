using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;


    // Start is called before the first frame update
    void Start()
    {

        //Calculate Pivot Distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;

        //Use the value to create pivot vector
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Floor"){

           explode();

        }
        
    }

    public void explode()
    {
        // Make object disappear
        gameObject.SetActive(false);

        

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //Get explosion postion
        Vector3 explosionPos = transform.position;
        //Get colliders in that postion d radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);

        foreach(Collider hit in colliders)
        {
            //Get rigidBody from collider
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void createPiece(int x, int y, int z){


        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

    }
}
