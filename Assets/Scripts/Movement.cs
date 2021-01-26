using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform pointToMove;
    [SerializeField] private Transform car;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float modSpeed;
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask layerMask;
    //[SerializeField] private float timer;
    //[SerializeField] private SnowBrush snowBrush;
    [SerializeField] private NavMeshCorrecter meshCorrecter;
    private void Start()
    {
        Move();
    }
    private void Move()
    {
        direction = pointToMove.position - car.position;
        direction = direction.normalized;
        rigidbody.AddForce(direction * modSpeed, ForceMode.Force);
    }

    private void FixedUpdate()
    {
        MoveAfterStart();
       // if (snowBrush.GetOnSnow()) timer += 0.1f;
    }
    private void MoveAfterStart()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, layerMask))
            {
                car.LookAt(hit.point);
                car.rotation = Quaternion.Euler(90, car.rotation.y, 90);
                direction = hit.point - car.position;
                direction = direction.normalized;
                rigidbody.AddForce(direction * modSpeed, ForceMode.Force);
            }
        }
    }

    public void StopMoving()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        var temp = meshCorrecter.GetMeshAgent1();
        temp.speed = 0f;
        temp = meshCorrecter.GetMeshAgent2();
        temp.speed = 0f;
    }
}
