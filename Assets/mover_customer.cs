using UnityEngine;
using System.Collections;
using Pathfinding;
public class mover_customer : MonoBehaviour
{
    
    public Vector3 originalpos;
    public Vector3 afterpos;
    public char instr = '0';
    spawn customer_spawn;
    IAstarAI ai;



    public void Start()
    {
        //get the scripts of trigger0
        customer_spawn = GameObject.Find("CustomerManager").GetComponent<spawn>();

        //get the position of customer's original position
        originalpos = this.transform.position;

        //starts with instruction A, queue first
        instr = 'A';

    }

    void OnEnable()
    {
        ai = GetComponent<IAstarAI>();
        if (ai != null) ai.onSearchPath += Update;
    }

    public void OnPathComplete(Path p)
    {
         Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
    }

    void OnDisable()
    {
        if (ai != null) ai.onSearchPath -= Update;
    }
    
    void Update()
    {
        StartCoroutine("ExecuteAfterTime", 1);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        Seeker seeker = GetComponent<Seeker>();

        switch (instr)
        {

            //case A, move customer to a new position
            case 'A':
                time = 1;

                yield return new WaitForSeconds(time);
                if (afterpos != null && ai != null) ai.destination = afterpos;

                break;


        }
    }
}
