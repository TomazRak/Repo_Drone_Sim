using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameController : MonoBehaviour {
    //public List<MonoBehaviour> eventSubscribedScripts = new List<MonoBehaviour>();
    public List<GameObject> Droni = new List<GameObject>();

    private static GameController instance;

    public static GameController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameController>();
#if UNITY_EDITOR
                if(FindObjectsOfType<GameController>().Length > 1)
                {
                    Debug.LogError("V scene je več kot 1 GameController");
                }
            }
            return instance;
        }
    }



	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        GameObject newDrone = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/DroneParent.prefab", typeof(GameObject));
        Instantiate(newDrone, new Vector3(0, 0, 0), Quaternion.identity);
        //var newDron = GameObject.CreatePrimitive(PrimitiveType.);

        Droni.Add(newDron);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}

public class nekaj
{
    public GameObject Drone { set; get; }
}