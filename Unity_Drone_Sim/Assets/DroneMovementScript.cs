using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovementScript : MonoBehaviour {

    public Transform[] cilj;
    public float hitrost;

    private int trenuten;


    /*Rigidbody ourDrone;
    public float upForce;

    public void Awake()
    {
        ourDrone = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        MovementUpDown();

        ourDrone.AddRelativeForce(Vector3.up * upForce);
    }
    
    public void MovementUpDown()
    {

    }*/

    ///*// Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position != cilj[trenuten].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, cilj[trenuten].position, hitrost * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);

        }
        else
        {
            trenuten = (trenuten + 1) % cilj.Length;
        }
	}//*/
}
