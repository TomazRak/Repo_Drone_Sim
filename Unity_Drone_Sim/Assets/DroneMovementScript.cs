using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovementScript : MonoBehaviour {

    Rigidbody ourDrone;
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

    }

    /*// Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
}
