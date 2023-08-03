using UnityEngine;
using System.Collections;
using Pathfinding;
public class trigger : MonoBehaviour
{

    GameObject[] CustomerObj_array;
    public mover_customer[] movercustomer_array;
    int j = 0;
    int k = 0;


    void Update() //this line updates every frame
    {


        //this segment is important as it updates frequently to find total no. of customers

        //find game objects with tag customer and assign to movercustomer1
        //this line is for array size for moverc
        CustomerObj_array = GameObject.FindGameObjectsWithTag("Customer");

        //create a new array of scripts of mover_customer with size movercustomer1
        movercustomer_array = new mover_customer[CustomerObj_array.Length];


        //loop for getting mover_customer script and assign to moverc by index
        //this loop basically find the customers and get their script attached
        for (int i = 0; i < CustomerObj_array.Length; i++)
        {

            movercustomer_array[i] = CustomerObj_array[i].GetComponent<mover_customer>();

        }

        j = Queue(j);


    }


    int Queue(int j) //this function is for assigning position of customer to queue
    {

        //loop with the total size of movercustomer1
        while (j < CustomerObj_array.Length)

        {

            //assign customer to each position with first come first served term

            //find position of queing and assign it to script moverc
            //moverc is a script and .afterpos is a variable in the script, this line aim is 
            //to access variable afterpos in moverc

            if (GameObject.Find("trigger" + k) != null)
            {
                movercustomer_array[j].afterpos = GameObject.Find("trigger" + k).transform.position;
                
            }
            else
            {
                movercustomer_array[j].afterpos = movercustomer_array[j].transform.position;

            }


            k++;
            j++;


        }
        return j;
    }


    public void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
    }



}
