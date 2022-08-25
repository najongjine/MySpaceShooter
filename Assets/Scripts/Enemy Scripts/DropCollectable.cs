using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollectable : MonoBehaviour
{
    [SerializeField]
    GameObject[] collectables;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckToSpawnCollectable()
    {
        if (Random.Range(0,2) > 0 )
        {
            Instantiate(collectables[Random.Range(0,collectables.Length)],transform.position,Quaternion.identity);
        }
    }
}
