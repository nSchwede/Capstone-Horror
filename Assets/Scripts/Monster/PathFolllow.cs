using System.Collections;
using UnityEngine;

public class PathFolllow : MonoBehaviour
{
    [SerializeField] int xPos = 10; //= start position;
    [SerializeField] int zPos = -12; //= start position;
    [SerializeField] int yPos = 2; //Monster roam hight
    [SerializeField] GameObject destination;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 playerPos;
    [SerializeField] int position = 1;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        destination.transform.position = new Vector3(xPos, yPos, zPos);
        position += 1;
        StartCoroutine(NextDestination());
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyVision.canSeePlayer)
        {
            //stopcorroutine
            playerPos.x = player.transform.position.x;
            playerPos.z = player.transform.position.z;
            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, 0.025f);
        }
        else if(!EnemyVision.canSeePlayer)
        {
            //startcorroutine if it is stopped
            transform.LookAt(destination.transform);
            transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, 0.025f);
        }
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
            xPos = -30;
            zPos = -33;
            destination.transform.position = new Vector3(xPos, yPos, zPos);
            position += 1;
        }
        if (position == 4)
        {
            yield return new WaitForSeconds(3);
            xPos = -30;
            zPos = 30;
            destination.transform.position = new Vector3(xPos, yPos, zPos);
            position += 1;
        }
        if (position == 5)
        {
            yield return new WaitForSeconds(3);
            xPos = 0;
            zPos = 0;
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
