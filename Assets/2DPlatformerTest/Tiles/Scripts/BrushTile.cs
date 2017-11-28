using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PlatformerTest.Tiles
{
    public class BrushTile : Tile
    {
        [Header("Sprites 3")]
        [SerializeField] public Sprite[] sprites = new Sprite[3];

        public override void RefreshTile(Vector3Int location, ITilemap tilemap)
        {
            for (int yd = -1; yd <= 1; yd++)
                for (int xd = -1; xd <= 1; xd++)
                {
                    Vector3Int position = new Vector3Int(location.x + xd, location.y + yd, location.z);
                    if (HasThisTile(tilemap, position))
                        tilemap.RefreshTile(position);
                }
        }

        public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            int mask = HasThisTile(tilemap, location + new Vector3Int(-1, 0, 0)) ? 1 : 0;
            mask += HasThisTile(tilemap, location + new Vector3Int(1, 0, 0)) ? 2 : 0;
            int index = GetIndex((byte)mask);

            tileData.sprite = sprites[index];
            tileData.color = Color.white;
            tileData.flags = TileFlags.LockAll;
            tileData.colliderType = ColliderType.None;
        }

        private bool HasThisTile(ITilemap tilemap, Vector3Int position)
        {
            return tilemap.GetTile(position) == this;
        }

        private int GetIndex(byte mask)
        {
            switch (mask)
            {
                case 2:  
                    return 0;
                case 0:
                case 3:
                    return 1;
                case 1:
                    return 2;
            }
            return -1;
        }

        #if UNITY_EDITOR
        [MenuItem("Assets/Custom/Tile/Create/BrushTile")]
        public static void CreateBrushTile()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Brush Tile", "New Brush Tile", "Asset", "Save Brush Tile", "Assets");
            if (path == "")
                return;
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<BrushTile>(), path);
        }
        #endif
    }
}
