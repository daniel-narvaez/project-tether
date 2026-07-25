using AYellowpaper.SerializedCollections;
using UnityEngine;
using TileSystem;

/* IF we need to optimize, create a tile object pool that holds tile creation data,
 * stores them in a dict and looksup tile data whenever its required
 * 
 */


public class TilePlacementManager : MonoBehaviour
{
    #region GIZMO_SETTINGS
    [Header("Gizmo Settings")]
    [SerializeField] Material _plainMAT;
    [SerializeField] Material _waterMAT;
    [SerializeField] Material _lavaMAT;
    #endregion

    public SerializedDictionary<GameObject, TileType> _tileDict = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateAllTiles();
    }

    void GenerateAllTiles()
    {
        foreach (var (tile, tileType) in _tileDict)
        {
            switch (tileType)
            {
                case TileType.Plain:
                    SetTileInfo(tile, TileManager.Instance.CreatePlainTile());
                    break;
                case TileType.Lava:
                    SetTileInfo(tile, TileManager.Instance.CreateLavaTile());
                    break;
            }
        }
    }

    void SetTileInfo(GameObject tile, Tile tileInfo)
    {
        tile.GetComponent<TileContainer>().SetTile(tileInfo);
        tile.GetComponent<MeshFilter>().mesh = tileInfo.Mesh;
        tile.GetComponent<MeshCollider>().sharedMesh = tileInfo.Mesh;
    }

    private void OnDrawGizmos()
    {
        if(!Application.isPlaying)
        {
            foreach (var (tile, tileType) in _tileDict)
            {
                switch (tileType)
                {
                    case TileType.Plain:
                        tile.GetComponent<Renderer>().material = _plainMAT;
                        break;
                    case TileType.Water:
                        tile.GetComponent<Renderer>().material = _waterMAT;
                        break;
                    case TileType.Lava:
                        tile.GetComponent<Renderer>().material = _lavaMAT;
                        break;
                }
            }
        }
    }
}
