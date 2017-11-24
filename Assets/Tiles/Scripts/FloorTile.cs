using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class FloorTile : Tile 
{
    [Header("Sprites 3")]
    [SerializeField] public Sprite[] sprites = new Sprite[3];

    public override void RefreshTile(Vector3Int location, ITilemap tilemap)
    {
        for (int yd = -1; yd <= 1; yd++)
            for (int xd = -1; xd <= 1; xd++)
            {
                Vector3Int position = new Vector3Int(location.x + xd, location.y + yd, location.z);
                if (HasFloorTile(tilemap, position))
                    tilemap.RefreshTile(position);
            }
    }


    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        int mask = HasFloorTile(tilemap, location + new Vector3Int(0, 1, 0)) ? 1 : 0;
        mask += HasFloorTile(tilemap, location + new Vector3Int(1, 0, 0)) ? 2 : 0;
        mask += HasFloorTile(tilemap, location + new Vector3Int(0, -1, 0)) ? 4 : 0;
        mask += HasFloorTile(tilemap, location + new Vector3Int(-1, 0, 0)) ? 8 : 0;
        int index = GetIndex((byte)mask);

        tileData.sprite = sprites[index];
        tileData.color = Color.white;
        tileData.flags = TileFlags.LockAll;
        tileData.colliderType = ColliderType.Sprite;
    }

    private bool HasFloorTile(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }

    private int GetIndex(byte mask)
    {
        switch (mask)
        {
            case 0:
            case 2:
            case 4:
            case 6:
            case 8:
            case 10:
            case 12:
            case 14:
                return 0;
            case 5:
            case 7:
            case 13:
            case 15:
                return 1;
            case 1:
            case 3:
            case 9:
            case 11:
                return 2;
        }
        return -1;
    }

    #if UNITY_EDITOR
    [MenuItem("Assets/Custom/Tile/Create/FloorTile")]
    public static void CreateFloorTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Floor Tile", "New Floor Tile", "Asset", "Save Floor Tile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<FloorTile>(), path);
    }
    #endif
}