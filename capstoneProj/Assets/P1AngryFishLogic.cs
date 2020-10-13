using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class P1AngryFishLogic : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform == player)
        {
            Debug.Log("Grr fish eat u u die");
        }
        
    }
}
