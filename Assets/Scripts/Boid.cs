using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    private Rigidbody rb;
    private List<GameObject> neighbours;

    public float alignmentWeight, cohesionWeight, seperationWeight;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.value, Random.value, Random.value);
        neighbours = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 alignmentVec = Vector3.zero;
        Vector3 cohesionVec = Vector3.zero;
        Vector3 seperationVec = Vector3.zero;

        foreach(GameObject o in neighbours)
        {
            // Alignment
            alignmentVec += o.GetComponent<Rigidbody>().velocity;

            // Cohesion
            cohesionVec += o.transform.position;

            // Seperation
            seperationVec += this.transform.position - o.transform.position;
        }

        // Combine everything together
        alignmentVec /= neighbours.Count;
        alignmentVec.Normalize();

        cohesionVec /= neighbours.Count;
        cohesionVec = new Vector3(cohesionVec.x - this.transform.position.x, cohesionVec.y - this.transform.position.y, cohesionVec.z - this.transform.position.z);
        cohesionVec.Normalize();

        seperationVec /= neighbours.Count;
        seperationVec *= -1;
        seperationVec.Normalize();

        Vector3 v = rb.velocity;
        v += alignmentVec * alignmentWeight + cohesionVec * cohesionWeight + seperationVec * seperationWeight;
        v.Normalize();
        rb.velocity = v;
	}

    void OnTriggerEnter(Collider other)
    {
        if(neighbours == null)
        {
            neighbours = new List<GameObject>();
        }

        neighbours.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        neighbours.Remove(other.gameObject);
    }
}
