using UnityEngine;

public class GhostScatter : GhostBehavior
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && !this.enabled && !this.ghost.frightened.enabled) 
        {
            int index = Random.Range(0, node.availableDirections.Count);

            if (node.availableDirections[index] == -this.ghost.movement.direction) 
            { 

            }
        }
    }
}
