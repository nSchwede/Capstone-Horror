using UnityEngine;
using TMPro;

public class EnemyVision : MonoBehaviour
{
    [Header("Vision Settings")]
    public Transform player;          // Reference to the Player's transform
    public float viewDistance = 10f;  // How far the enemy can see
    [Range(0, 180)]
    public float viewAngle = 45f;     // Half of the total FOV (e.g., 45 means a 90-degree cone)

    [Header("Raycast Settings")]
    public LayerMask obstructionMask; // Layers that block vision (e.g., Walls, Obstacles)

    [Header("State")]
    static public bool canSeePlayer;

    [Header("Text To Update")]
    public TextMeshProUGUI myText;

    private void Update()
    {
        canSeePlayer = CheckVision();

        if (canSeePlayer)
        {
            myText.text = "I can See YOU!";
        }
        else if(!canSeePlayer)
        {
            myText.text = "Where'd you go?";
        }
        
    }

    private bool CheckVision()
    {
        if (player == null) return false;

        // 1. Check Distance
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > viewDistance) return false;

        // 2. Check Angle (Field of View)
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
        
        if (angleToPlayer > viewAngle) return false;

        // 3. Check Obstructions (Line of Sight)
        // Raycast from enemy to player. If it hits an obstruction before reaching the player, return false.
        if (Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstructionMask))
        {
            return false; 
        }

        // All conditions passed
        return true; 
    }

    // Draws the vision cone in the Scene view for easy debugging
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle, 0) * transform.forward;
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle, 0) * transform.forward;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, leftBoundary * viewDistance);
        Gizmos.DrawRay(transform.position, rightBoundary * viewDistance);

        if (canSeePlayer)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, player.position);
        }
    }
}