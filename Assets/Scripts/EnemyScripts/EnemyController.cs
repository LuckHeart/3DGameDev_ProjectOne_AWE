using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    private NavMeshAgent agent;

    [SerializeField] bool tracking = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NavMeshAgent>() != null)
        {
            agent = GetComponent<NavMeshAgent>();
            tracking = true;
        }
        InvokeRepeating("TrackPlayer", 0, 0.25f);
    }

    public void TrackPlayer()
    {

        if (tracking == true)
        {
            agent.destination = player.transform.position;
        }

    }

    public void DestroyIfHit()
    {
        tracking = false;
        Destroy(enemy);
    }

}
