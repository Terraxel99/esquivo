using Esquivo.Constants;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameInformations gameInformations;

    void OnCollisionEnter(Collision collisionInfo)
    {
        // If finish line collides with player, game ends.
        if (collisionInfo.gameObject?.tag == TagConstants.playerTag)
        {
            this.gameInformations.FinishGame();
        }
    }
}
