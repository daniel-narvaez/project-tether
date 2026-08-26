using AYellowpaper.SerializedCollections;
using System;
using TileSystem;
using UnityEditor;
using UnityEngine;


/* IF we need to optimize, create a tile object pool that holds tile creation data,
 * stores them in a dict and looksup tile data whenever its required
 * 
 */

[CustomEditor(typeof(TilePlacementManager))]
public class CustomTilePlacementManagerEditor : Editor
{
    SerializedProperty _allTilesTypes;

    private void OnEnable()
    {
        _allTilesTypes = serializedObject.FindProperty("_allTilesTypes");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Draw EVERYTHING except "_allTilesTypes"
        DrawPropertiesExcluding(serializedObject, "_allTilesTypes");

        EditorGUILayout.Space();

        DrawTiles();

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawTiles()
    {
        EditorGUILayout.LabelField("Tiles", EditorStyles.boldLabel);

        for (int i = 0; i < _allTilesTypes.arraySize; i++)
        {
            EditorGUILayout.PropertyField(
                _allTilesTypes.GetArrayElementAtIndex(i),
                new GUIContent($"Tile {i + 1}")
            );
        }
    }
}


public class TilePlacementManager : MonoBehaviour
{
    #region GIZMO_SETTINGS
    [Header("Gizmo Settings")]
    [SerializeField] Material _plainMAT;
    [SerializeField] Material _waterMAT;
    [SerializeField] Material _lavaMAT;
    #endregion

    SerializedDictionary<Transform, TileType> _tileDict = new();

    const int requiredSize = 19;
    [SerializeField] 
    TileType[] _allTilesTypes = new TileType[requiredSize];

    [SerializeField] GameObject _allTiles;


    private void OnValidate()
    {
        if (_allTilesTypes.Length != requiredSize)
        {
            Debug.LogWarning($"Array size is locked to {requiredSize}!");
            Array.Resize(ref _allTilesTypes, requiredSize);
        }

        if (_allTiles == null)
        {
            Debug.LogWarning("_allTiles field is empty");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateAllTiles();
    }

    void GenerateAllTiles()
    {
        for (int i = 0, j = 0; i < _allTilesTypes.Length && j < _allTiles.transform.childCount; i++, j++)
        {
            _tileDict.Add(_allTiles.transform.GetChild(j), _allTilesTypes[i]);
        }

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

    void SetTileInfo(Transform tile, Tile tileInfo)
    {
        tile.GetComponent<TileContainer>().SetTile(tileInfo);
        tile.GetComponent<MeshFilter>().mesh = tileInfo.Mesh;
        tile.GetComponent<MeshCollider>().sharedMesh = tileInfo.Mesh;
    }

    private void OnDrawGizmos()
    {
        if(!Application.isPlaying)
        {
            SerializedDictionary<Transform, TileType> dict = new();

            for (int i = 0, j = 0; i < _allTilesTypes.Length && j < _allTiles.transform.childCount; i++, j++)
            {
                dict.Add(_allTiles.transform.GetChild(j), _allTilesTypes[i]);
            }

            foreach (var (tile, tileType) in dict)
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
