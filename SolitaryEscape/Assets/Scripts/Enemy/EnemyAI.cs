using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    public ParticleSystem rightEye;
    public ParticleSystem leftEye;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rightEye.Stop();
        leftEye.Stop();
    }

    void Update()
    {
        if (target!= null)
        {
            agent.SetDestination(target.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.SetActive(false);
            GameLevelMgr.Instance.GameOver();
            rightEye.Play();
            leftEye.Play();
        }
    }
}
