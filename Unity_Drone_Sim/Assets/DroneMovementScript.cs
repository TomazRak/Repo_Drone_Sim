using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovementScript : MonoBehaviour {

    public Transform[] cilj;
    public float hitrost;


    private int trenuten;
    public List<Vector3> trajektorji = new List<Vector3>();
    //trajektorji.Add(new Vector3(-1.48, 0, -1.54));
    

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

    ///*// Use this for initialization
    void Start () {
        //trajektorji.Add(new Vector3((float)-1.48, 0, (float)-1.54));
        //trajektorji.Add(new Vector3((float)-1.48, 0, (float)2.94));
        //trajektorji.Add(new Vector3((float)3.23, (float)1.4, (float)4.04));
        //trajektorji.Add(new Vector3((float)3.66, 0, (float)-0.311));
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position != trajektorji[trenuten])
        {
            //Vector3 pos = Vector3.MoveTowards(transform.position, cilj[trenuten].position, hitrost * Time.deltaTime);
            Vector3 pos = Vector3.MoveTowards(transform.position, trajektorji[trenuten], hitrost * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);

        }
        else
        {
            trenuten = (trenuten + 1) % trajektorji.Count;
        }
	}//*/
}
