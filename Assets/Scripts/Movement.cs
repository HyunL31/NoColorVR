using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

namespace MimicSpace
{
    public class Movement : MonoBehaviour
    {
        [Range(0.5f, 7f)]
        [SerializeField] float velocity = 3f;          // Base movement speed
        [Range(0.5f, 2f)]
        [SerializeField] float chaseWeight = 1.5f;     // Additional speed when chasing
        [SerializeField] float DetectRange = 10f;     // Detection range for target

        private NavMeshAgent agent;            
        private Mimic myMimic;
        [SerializeField] GameObject target;               
        private AudioSource ac;                 
                                
        private bool isStunned = false;     // Whether mimic is stunned (cannot move)
        private bool isConfused = false;    // Whether mimic is confused (run away)

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            myMimic = GetComponent<Mimic>();
            ac = GetComponent<AudioSource>();

            // Initialize agent speed
            ChangeSpeed(velocity);          
        }

        void Update()
        {
            // Skip movement if stunned or confused
            if (!isStunned && !isConfused)
            {
                agent.SetDestination(target.transform.position);
            }
            Vector3 direction = agent.desiredVelocity; 
            direction.y = 0f;                         
            myMimic.velocity = direction;              

            float dir = Vector3.Distance(target.transform.position, transform.position);
            if (dir <= DetectRange)
            {
                if (!ac.isPlaying) ac.Play();

                // Increase speed while chasing
                ChangeSpeed(velocity + chaseWeight); 
            }
            else
            {
                ac.Stop();

                // Restore base speed
                ChangeSpeed(velocity);                
            }
        }

        // Change the agent's speed
        public void ChangeSpeed(float valSpeed)
        {
            agent.speed = valSpeed;
        }

        // Apply slow effect: reduce movement speed by half
        public float ApplySlow()
        {
            float time = 4f ;

            StartCoroutine(SlowRoutine(time));
            
            return time;
        }

        // Apply confuse effect: move opposite direction for a duration
        public float ApplyConfuse()
        {
            float time = 2f;
            StartCoroutine(ConfuseRoutine(time));
            return time;
        }

        // Apply stun effect: stop movement temporarily
        public float ApplyStun()
        {
            float time = 3f;
            StartCoroutine(StunRoutine(time));
            return time;
        }

        // Apply trap effect (same as stun)
        public float ApplyTrap()
        {
            return ApplyStun(); // same effect
        }


        // Coroutine for slow state
        private IEnumerator SlowRoutine(float time)
        {
            

            Debug.Log("Slow applied: speed reduced");
            ChangeSpeed(velocity * 0.5f);

            yield return new WaitForSeconds(time);

            ChangeSpeed(velocity);
        }

        // Coroutine for confuse state
        private IEnumerator ConfuseRoutine(float time)
        {
            Debug.Log("Confuse applied: moving opposite direction");
            isConfused = true;

            // Calculate opposite direction to target and move away
            Vector3 reverse = -(target.transform.position - transform.position).normalized;
            agent.SetDestination(transform.position + reverse * 3f);

            yield return new WaitForSeconds(time);
            isConfused = false;
        }

        // Coroutine for stun state
        private IEnumerator StunRoutine(float time)
        {
            Debug.Log("Stun applied: stop chasing");
            isStunned = true;
            ChangeSpeed(0f); // Stop movement

            yield return new WaitForSeconds(time);
            isStunned = false;
            ChangeSpeed(velocity);
        }
    }
}