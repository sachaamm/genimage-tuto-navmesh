using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAgent : MonoBehaviour
{
    public Camera camera;
    public NavMeshAgent agent;

    public GameObject hitPoint;

    public float walkSpeed = 1.0f;
    public float jumpSpeed = 1.0f;

    public float accelerationInWalkable = 1.0f;
    public float accelerationInJump = 1.0f;

    public Animator animator;
    void Start(){

        
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out hit)) {
                Transform objectHit = hit.transform;
                // Quand mon raycast touche un objet, je déplace le NavMeshAgent vers la position
                var position = hit.point;
                agent.SetDestination(position);
                Debug.Log("set destination. Collide with " + objectHit);
                hitPoint.transform.position = position;
                
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
            }
        }
        
        
        NavMeshHit nhit;
        if (NavMesh.SamplePosition(agent.transform.position, out nhit, 1.0f, NavMesh.AllAreas))
        {
            // result = nhit.position;
            print (nhit.mask);
            
            // mask 4 

            if (nhit.mask == 1)
            {
                // je suis sur une zone Walkable
                agent.speed = walkSpeed;
                agent.acceleration = accelerationInWalkable;
                
                animator.SetBool("jump", false);
            }

            if (nhit.mask == 4)
            {
                // je suis sur une zone Jump
                agent.speed = jumpSpeed;
                agent.acceleration = accelerationInJump;
                
                animator.SetBool("jump", true);
                
            }
            
            // return true;
        }

        if (agent.isOnNavMesh && !agent.pathPending)
        {
            if (agent.remainingDistance > 0.01f)
            {
                animator.SetBool("walk", true);
            }
            else
            {
                animator.SetBool("walk", false);
            }
        }
        
    }
}
