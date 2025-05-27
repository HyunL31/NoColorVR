using UnityEngine;
using UnityEngine.AI;

namespace MimicSpace
{
    //This script is based on https://assetstore.unity.com/packages/3d/characters/creatures/mimic-prototype-245997

    public class Movement : MonoBehaviour
    {
        [Range(0.5f, 7f)]
        public float velocity = 1f;
        public float DetectRange = 10f; 

        private NavMeshAgent agent;
        private Mimic myMimic;
        public GameObject target; // Set to Player
        AudioSource ac;


        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            myMimic = GetComponent<Mimic>();
            ac = GetComponent<AudioSource>();

            changeSpeed(velocity);
        }

        void Update()
        {
            // Move to target
            agent.SetDestination(target.transform.position);


            // Give moving direction(2D) to 'mimic' for making legs
            Vector3 direction = agent.desiredVelocity;
            direction.y = 0f;

            myMimic.velocity = direction;

            // When mimic can reach to target, check certain range
            NavMeshPath path = new NavMeshPath();
            bool pathFound = agent.CalculatePath(target.transform.position, path);
            float dir = Vector3.Distance(target.transform.position, transform.position);

            if (pathFound && path.status == NavMeshPathStatus.PathComplete && dir <= DetectRange)
            {
                // If checked, play the chasing sound with speed up
                if (!ac.isPlaying) ac.Play();
                changeSpeed(2f);
            }
            else
            {
                // If not or failed, stop the chasing sound and restore the origin speed
                ac.Stop();
                changeSpeed(1f);
            }

        }

        // Change mimic's speed
        public void changeSpeed(float valSpeed)
        {
            agent.speed = valSpeed;
        }
    }
}