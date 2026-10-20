using System.Collections;
using UnityEngine;

public class PathFolllow : MonoBehaviour
{
    [SerializeField] int xPos = 10; //= start position;
    [SerializeField] int zPos = -12; //= start position;
    [SerializeField] int yPos = -2; //Monster roam hight
    [SerializeField] GameObject destination;
    [SerializeField] int position = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destination.transform.position = new Vector3(xPos, yPos, zPos);
        position += 1;
        StartCoroutine(NextDestination());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(destination.transform);
        transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, 0.05f);
    }

    IEnumerator NextDestination()
    {
        if (position == 1)
        {
            yield return new WaitForSeconds(3);
            xPos = 10;
            zPos = -12;
            destination.transform.position = new Vector3(xPos, yPos, zPos);
            position += 1;
        }
        if (position == 2)
        {
            yield return new WaitForSeconds(3);
            xPos = 30;
            zPos = -33;
            destination.transform.position = new Vector3(xPos, yPos, zPos);
            position += 1;
        }
        if (position == 3)
        {
            yield return new WaitForSeconds(3);
            xPos = 20;
            zPos = -25;
            destination.transform.position = new Vector3(xPos, yPos, zPos);
            position += 1;
        }
        if (position == 4)
        {
            yield return new WaitForSeconds(3);
            xPos = 10;
            zPos = -30;
            destination.transform.position = new Vector3(xPos, yPos, zPos);
            position += 1;
        }
        if (position == 5)
        {
            yield return new WaitForSeconds(3);
            xPos = 0;
            zPos = -25;
            destination.transform.position = new Vector3(xPos, yPos, zPos);
            position += 1;
        }
        if (position == 6)
        {
            yield return new WaitForSeconds(3);
            xPos = -10;
            zPos = -30;
            destination.transform.position = new Vector3(xPos, yPos, zPos);
            position = 1;
        }
    }

}
