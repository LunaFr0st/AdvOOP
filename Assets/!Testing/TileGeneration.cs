using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    Texture[] mapTiles;

    public void CreateMap()
    {

    }
}
public class TilePrefabs
{
    GameObject _prefab = new GameObject();
    Color _colour = new Color();

    public void Tile(GameObject prefab, Color prefabColour)
    {
        prefab = _prefab;
        prefabColour = _colour;
    }
}
