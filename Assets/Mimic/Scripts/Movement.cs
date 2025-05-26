using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MimicSpace
{
    public class Movement : MonoBehaviour
    {
        [Header("Controls")]
        [Tooltip("Body Height from ground")]
        [Range(0.5f, 5f)]
        public float height = 0.8f;
        public float velocityLerpCoef = 4f;

        private NavMeshAgent agent;
        private Mimic myMimic;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            myMimic = GetComponent<Mimic>();

            // 높이 수동으로 조절 안 하게끔 끔
            agent.updatePosition = true;
            agent.updateRotation = false;
        }

        void Update()
        {
            // 플레이어 위치로 이동
            Vector3 playerPos = Camera.main.transform.position;
            agent.SetDestination(playerPos);

            // 방향 벡터 계산 (XZ 평면 기준)
            Vector3 direction = agent.desiredVelocity;
            direction.y = 0f;

            // Mimic에 velocity 전달
            myMimic.velocity = direction;

            // 바닥 높이 보정
            RaycastHit hit;
            Vector3 correctedPos = transform.position;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                correctedPos.y = hit.point.y + height;
                transform.position = Vector3.Lerp(transform.position, correctedPos, velocityLerpCoef * Time.deltaTime);
            }
        }
    }
}