using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Hostage : MonoBehaviour
{
    NavMeshAgent pathfinder;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("rallyPoint").transform;
        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator UpdatePath()
    {
        float refreshRate = 0.25f;
        while(target!=null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
