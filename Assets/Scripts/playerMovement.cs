using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //allows us to use navigation mesh

public class playerMovement : MonoBehaviour
{
    private Animator mAnimator;

    private NavMeshAgent mAgent;

    private bool mRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            
            if(Physics.Raycast(ray, out hit, 100))
            {
                mAgent.destination = hit.point;
            }
        }

        if (mAgent.remainingDistance <= mAgent.stoppingDistance)
        {
            mRunning = false;
        }
        else mRunning = true;

        mAnimator.SetBool("running", mRunning);
    }
}
