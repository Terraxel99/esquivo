using Esquivo.Constants;

using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 cameraOffset;
    public GameInformations gameInformations;

    void Update()
    {
        var playerTransform = this.gameInformations.Player.transform;
        this.transform.position = playerTransform.position + this.cameraOffset;
    }
}
