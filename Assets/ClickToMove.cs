using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public float speed;
    public CharacterController controller;

    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position; // instead of inittial position beeing 0 becomes the players position
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            //locate where we click on the terrain
            locatePosition();
        }
        moveToPosition();
    }

    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10000))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            // Debug.Log(position); will show on command line the variable position
        }
    }

    void moveToPosition()
    {
        //double const eps = 1e-12;

        if (Vector3.Distance(transform.position, position) > 1) //makes character stop when reaching destination
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);

            newRotation.x = 0f;
            newRotation.z = 0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 15);
            controller.SimpleMove(transform.forward * speed);
            //if (Quaternion.identity.y - newRotation.y < const) controller.SimpleMove(transform.forward * speed); tentativa de forçar player a virar e depois andar
        }


    }
}
