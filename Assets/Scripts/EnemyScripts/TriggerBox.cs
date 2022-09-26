using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{

    public GameObject enemy;
    public GameObject triggerBox;
    public GameObject spawnPoint;

    public bool triggered;


    // Start is called before the first frame update
    void Start()
    {
        triggerBox = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            if (other.CompareTag("Player"))
            {
                triggered = true;
                Instantiate(enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
        }
    }
}
