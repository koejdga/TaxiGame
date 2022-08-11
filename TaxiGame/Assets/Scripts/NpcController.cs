using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{

    public bool reachedDestination;
    public Vector3 destination;

    float stopDistance = 2.5f;
    int rotationSpeed = 120;
    int movementSpeed = 1;


    private void Start()
    {
        movementSpeed = Random.Range(1, 6);
    }

    private void Update()
    {
         if (transform.position != destination)
         {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;

            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopDistance)
            {
                reachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            else
            {
                reachedDestination = true;
            }
         }
    }

        public void SetDestination(Vector3 destination)
        {
            this.destination = destination;
            reachedDestination = false;
        }
    
}
