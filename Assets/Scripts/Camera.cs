using Esquivo.Constants;

using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 cameraOffset;

    private Transform playerTransform;

    void Start()
    {
        var playerGameObject = GameObject.Find(GameObjectConstants.playerObject) 
            ?? throw new MissingReferenceException();

        this.playerTransform = playerGameObject.transform;
    }

    void Update()
    {
        this.transform.position = this.playerTransform.position + this.cameraOffset;
    }
}
