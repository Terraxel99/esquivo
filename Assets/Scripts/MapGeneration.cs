using Esquivo.Constants;
using Esquivo.Exceptions;

using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public float mapBoundariesObstaclesOffset;
    public float minSpacingBetweenObstacles;
    public float maxSpacingBetweenObstacles;
    public GameInformations gameInformations;

    private Transform obstaclesParent;
    private GameObject[] obstaclePrefabs;

    void Start()
    {
        this.EnsureValidData();

        this.GatherObstaclesPrefabs();
        this.GatherMapData();

        this.GenerateMap();   
    }

    private void EnsureValidData()
    {
        if (this.minSpacingBetweenObstacles <= 0 
            || this.maxSpacingBetweenObstacles <= 0 
            || this.minSpacingBetweenObstacles >= this.maxSpacingBetweenObstacles)
        {
            throw new InvalidObstacleSpacingException("Invalid spacing between obstacles");
        }
    }

    private void GatherObstaclesPrefabs()
    {
        this.obstaclePrefabs = Resources.LoadAll<GameObject>(ResourcePathConstants.obstaclesPrefabs);
    }

    private void GatherMapData()
    {
        // Get the obstacles' parent transform in order to instantiate obstacles later
        var obstacleParentObj = GameObject.Find(GameObjectConstants.obstaclesObject) ?? throw new MissingReferenceException();
        this.obstaclesParent = obstacleParentObj.transform;
    }

    private void GenerateMap()
    {
        float position = this.gameInformations.PlayerStartPosition.z + mapBoundariesObstaclesOffset;
        float endPosition = this.gameInformations.FinishLine.transform.position.z - mapBoundariesObstaclesOffset;

        while (position <= endPosition)
        {   
            // Randomize position on X & randomize pattern of obstacle
            var indexOfObstacle = Random.Range(0, this.obstaclePrefabs.Length);

            // Place obstacle
            var obstaclePrefab = this.obstaclePrefabs[indexOfObstacle];
            var sizePrefabX = obstaclePrefab.GetComponent<Renderer>().bounds.size.x;
            Debug.Log(sizePrefabX);
            var halfTerrainSizeX = this.gameInformations.TerrainSize.x / 2.0f;
            Debug.Log(halfTerrainSizeX);
            var randomXPosition = Random.Range(-halfTerrainSizeX + sizePrefabX, halfTerrainSizeX - sizePrefabX);
            
            var newObstacle = Instantiate(obstaclePrefab, this.obstaclesParent);
            newObstacle.transform.SetPositionAndRotation(new Vector3(randomXPosition, 0.5f, position), newObstacle.transform.rotation);

            // Increment of a random value between min & max spacing
            position += Random.Range(minSpacingBetweenObstacles, maxSpacingBetweenObstacles);
        }
    }
}
