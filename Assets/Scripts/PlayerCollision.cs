using Esquivo.Constants;

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement movementScript;

    void Start()
    {
        this.movementScript = this.GetComponent<PlayerMovement>() ?? throw new MissingComponentException("No movement script on player !");
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == TagConstants.obstacleTag) 
        {
            this.movementScript.enabled = false;
        }
    }
}
