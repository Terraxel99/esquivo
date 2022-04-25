using Esquivo.Constants;

using UnityEngine;

[CreateAssetMenu(menuName = "Game Informations")]
public class GameInformations : ScriptableObject
{
    public bool IsGameFinished { get; private set; } = false;
    
    public GameObject Player { get; private set; }
    public Vector3 PlayerStartPosition { get; private set; }
    public Vector3 TerrainSize { get; private set; } = Vector3.zero;
    public GameObject FinishLine { get; private set; }

    void OnEnable()
    {
        this.GatherMapData();
    }

    public void FinishGame()
        => this.IsGameFinished = true;

    private void GatherMapData()
    {
        this.Player = GameObject.FindGameObjectWithTag(TagConstants.playerTag) ?? throw new MissingReferenceException();
        this.PlayerStartPosition = this.Player.transform.position;

        var terrain = GameObject.FindGameObjectWithTag(TagConstants.groundTag) ?? throw new MissingReferenceException("No terrain found !");
        this.TerrainSize = terrain.GetComponent<MeshCollider>().bounds.size;

        this.FinishLine = GameObject.FindGameObjectWithTag(TagConstants.finishLineTag) ?? throw new MissingReferenceException();
    }
}
