using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] maps;
    public GameObject playerprefab;
    // Start is called before the first frame update
    void Start()
    {
        int mapnumber = Random.Range(0, maps.Length);
        GameObject map = Instantiate(maps[mapnumber], new Vector3(0, 0, 1), Quaternion.identity);
        GameObject player = Instantiate(playerprefab, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
