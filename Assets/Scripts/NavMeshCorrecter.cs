using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCorrecter : MonoBehaviour
{
    [SerializeField] private NavMeshAgent meshAgent1;
    [SerializeField] private NavMeshAgent meshAgent2;
    [SerializeField] private Transform car;

    private float timer =10f;

    private void FixedUpdate()
    {
        Correct();
    }

   private void Correct()
    {
        timer -= 0.1f;
        if(timer<0)
        {
            meshAgent1.destination = car.position;
            meshAgent2.destination = car.position;
            timer = 10f;
        }
    }

    public NavMeshAgent GetMeshAgent1() { return meshAgent1; }
    public NavMeshAgent GetMeshAgent2() { return meshAgent2; }
}
