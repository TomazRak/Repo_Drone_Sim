using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using System;

public class GameController : MonoBehaviour {
    private static GameController instance;
    public GameObject droneModel;
    public List<GameObject> Droni = new List<GameObject>();
    public Button buttonComponent;
    //public TextAsset Datoteka;

    //public List<List<Vector3>> trajektorjiDronov = new List<List<Vector3>>();
    //public List<Vector3> trajektorjiDronov = new List<Vector3>();
    //private List<int> trenuten = new List<int>();
    //public List<float> hitrostiDronov = new List<float>();
    //public List<MonoBehaviour> eventSubscribedScripts = new List<MonoBehaviour>();

    public void DodajDrona(Vector3 pozicija, Quaternion rotacija, int hitrost, List<Vector3> trajektorji)
    {
        GameObject newDrone = Instantiate(droneModel, pozicija, rotacija) as GameObject;
        Droni.Add(newDrone);
        DroneMovementScript DMS = newDrone.GetComponent<DroneMovementScript>();
        DMS.hitrost = hitrost;
        foreach (Vector3 cilj in trajektorji)
        {
            DMS.trajektorji.Add(cilj);
        }
    }

    [MenuItem("Tools/Read file")]
    void ReadString()
    {
        List<string> vsiPodatki = new List<string>();
        string data = "";
        string path = "Assets/Podatki.txt";
        StreamReader reader = new StreamReader(path);
        do
        {
            data = reader.ReadLine();
            vsiPodatki.Add(data);
            //Debug.Log(data);
        } while (data != null);
        
        reader.Close();


        Vector3 pozicija = new Vector3(0, 0, 0);
        Quaternion rotacija = new Quaternion(0, 0, 0, 0);
        int hitrost = 5;
        List<Vector3> cilji = new List<Vector3>();
        List<float> koordinate = new List<float>();
        float[] poz= new float [3];
        float[] rot = new float[4];

        string[] substing;
        foreach (string s in vsiPodatki)
        {
            substing = s.Split('@');
            int i = 0;
            foreach (string sub in substing)
            {
                //Debug.Log(sub);/***********************************************/
                string[] subsub;
                subsub = sub.Split('|');
                int j = 0;
                foreach(string subsubs in subsub)
                {
                    //Debug.Log(subsubs);/***********************************************/
                    if (i==0)
                    {//pozicija
                        poz[j] = float.Parse(subsubs);
                    }
                    else if( i== 1)
                    {//rotacija
                        rot[j] = float.Parse(subsubs);
                    }
                    else if(i == 2)
                    {//hitrost
                        hitrost = Int32.Parse(subsubs);
                    }
                    else
                    {//trajektorji po 3 i%3
                        koordinate.Add(float.Parse(subsubs));
                    }
                    j++;
                }
                if(i == 0)
                {
                    pozicija = new Vector3(poz[0], poz[1], poz[2]);
                }
                else if (i == 1)
                {
                    rotacija = new Quaternion(rot[0], rot[1], rot[2], rot[3]);
                }
                else if (i>2)
                {
                    //Debug.Log("*******************");
                    //foreach (var k in koordinate)
                    //{
                    //    Debug.Log(k.ToString());
                    //}
                    //Debug.Log("----------------------");
                    
                    for (int k=2; k<koordinate.Count;)
                    {
                        //Debug.Log(k + " " + koordinate[k] + "  " + koordinate.Capacity);
                        cilji.Add(new Vector3(koordinate[k - 2], koordinate[k - 1], koordinate[k]));
                        //Debug.Log(cilji[0].ToString());
                        k += 3;
                    }
                    //Debug.Log(i);
                }
                i++;
            }
            //Debug.Log("pozicija: " + pozicija.ToString());
            //Debug.Log("rotacija: " + rotacija.ToString());
            //Debug.Log("hitrost: " + hitrost.ToString());
            //Debug.Log("cilj: ");
            //foreach (var c in cilji)
            //{
            //    Debug.Log(c.ToString());
            //}
            //Debug.Log("/////////cilj: " + cilji.Count);


            DodajDrona(pozicija, rotacija, hitrost, cilji);
            cilji.Clear();
        }
    }

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
#endif
            }
            return instance;
        }
    }
    
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        //GameObject newDrone = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/DroneParent.prefab", typeof(GameObject));
        //Instantiate(newDrone, new Vector3(0, 0, 0), Quaternion.identity);
        //var newDron = GameObject.CreatePrimitive(PrimitiveType.);
        /*******************************************PROOF OF CONCEPT****************************************************/
        Vector3 pozicija = new Vector3(0, 0, 0);
        Quaternion rotacija = new Quaternion(0, 0, 0, 0);
        GameObject newDrone = Instantiate(droneModel, pozicija, rotacija) as GameObject;
        Droni.Add(newDrone);
        DroneMovementScript DMS = newDrone.GetComponent<DroneMovementScript>();
        DMS.trajektorji.Add(new Vector3((float)-1.48, 0, (float)-1.54));
        DMS.trajektorji.Add(new Vector3((float)3.23, (float)1.4, (float)4.04));
        DMS.trajektorji.Add(new Vector3((float)3.66, 0, (float)-0.311));
        DMS.hitrost = 5;
        /*******************************************PROOF OF CONCEPT****************************************************/
        buttonComponent.onClick.AddListener(HandleClick);
        buttonComponent.GetComponentInChildren<Text>().text = "DODAJ DRONA";
        ReadString();
    }

    // Update is called once per frame
    void Update () {

	}

    

    public void HandleClick()
    {
        //TODO: OPENS new WInDOW for ADDING DRONE with TRAJEKTORJI in HITROST*/
        Vector3 pozicija;
        Quaternion rotacija;
        int hitrost;
        List<Vector3> cilji = new List<Vector3>();

        
        pozicija = new Vector3(0, 0, 0);
        rotacija = new Quaternion(0, 0, 0, 0);
        cilji.Add(new Vector3((float)-6.48, 0, (float)-1.54));
        cilji.Add(new Vector3((float)4.23, (float)1.4, (float)4.04));
        cilji.Add(new Vector3((float)6.66, 0, (float)-0.311));
        hitrost = 5;

        DodajDrona(pozicija, rotacija, hitrost, cilji);
    }
}