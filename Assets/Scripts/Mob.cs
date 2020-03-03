using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    public float rangeAttack;
    public float rangeSee;
    public Transform player;

    private NavMeshAgent mAgent;
    private Animator mAnimator;
    private bool mRunning = false;
    private bool mAttack = false;

    void Start()
    {
        mAgent = GetComponent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRangeSee())
        {
            mRunning = true;
            chase();
        }

        if (inRangeAttack())
        {
            mAgent.GetComponent<NavMeshAgent>().isStopped = true;
            mRunning = false;
            mAttack = true;
        }
        else
        {
            mAgent.GetComponent<NavMeshAgent>().isStopped = false;
            mAttack = false;
        }

        mAnimator.SetBool("running", mRunning);
        mAnimator.SetBool("canAttack", mAttack);
    }

    bool inRangeSee()
    {
        return Vector3.Distance(transform.position, player.position) < rangeSee;
    }

    bool inRangeAttack()
    {
        return Vector3.Distance(transform.position, player.position) < rangeAttack;
    }

    void chase()
    {
        mAgent.destination = player.position;
    }
    /*
    void OnMouseOver()
    {
        player.GetOponent<combatPlayer>().opponent = GameObject;
    }
    */
}
