using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpikes : MonoBehaviour
{
    [SerializeField] private Transform[] spikeDropPts;
    [SerializeField] private GameObject spikePreFab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("SpikeSpawner",0.5f,1f);
        }
    }

    void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        CancelInvoke("SpikeSpawner");
    }
}


    void SpikeSpawner()
    {
        int index = Random.Range(0,spikeDropPts.Length);
        Vector3 dropPos = new Vector3(spikeDropPts[index].position.x, 0 , spikeDropPts[index].position.z);

        Instantiate(spikePreFab, dropPos, Quaternion.identity);
    }
}
