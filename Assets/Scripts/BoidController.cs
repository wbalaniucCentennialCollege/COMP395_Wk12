using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour {

    public GameObject boid;
    public int numberOfBoids = 50;

    // Run on the first frame
    void Start () {

		for(int i = 0; i < numberOfBoids; i++)
        {
            Instantiate(boid, new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f)), Quaternion.identity);
        }
	}
}
