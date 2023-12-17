using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviMeshMove : MonoBehaviour
{
    [SerializeField] Transform _goal;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent nav = GetComponent<NavMeshAgent>();
        nav.destination = _goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
