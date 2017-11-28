﻿using System;
using UnityEngine;
using UnityEditor;
using PlatformerTest.Tiles;

namespace PlatformerTest.Tiles.EditorScripts
{
    [CustomEditor(typeof(FloorTile))]
    public class FloorTileEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //aux
            Vector2 size;
            Vector2 position;

            FloorTile script = (FloorTile)target;

            base.OnInspectorGUI();

            EditorGUILayout.Separator();
            EditorGUILayout.HelpBox("Preview", MessageType.Info);

            if (script.sprites.Length < 3)
            {
                EditorGUILayout.HelpBox("Not enough sprites.", MessageType.Error);
                return;
            }
            if (script.sprites.Length > 3)
            {
                EditorGUILayout.HelpBox("This tile only works with 3 sprites.", MessageType.Warning);
                return;
            }

            bool error = false; 
            for (int i = 0; i < 3; i++)
            {
                if (script.sprites[i] == null)
                {
                    EditorGUILayout.HelpBox(String.Format("Sprite {0} cannot be null.", i), MessageType.Error);
                    error = true; 
                }
            }

            float height = script.sprites[0].texture.height;
            float width = script.sprites[0].texture.width;

            size = new Vector2(width, height);

            for (int i = 1; i < 3; i++)
            {
                if (new Vector2(script.sprites[i].texture.width, script.sprites[i].texture.height) != size)
                {
                    EditorGUILayout.HelpBox("All sprites must have the same size.", MessageType.Error);
                    error = true; 
                }
            }

            if (error)
            {
                return;
            }

            Rect rect0 = EditorGUILayout.GetControlRect(true, height, null);
            EditorGUILayout.Separator();
            Rect rect1 = EditorGUILayout.GetControlRect(true, height, null);
            EditorGUILayout.Separator();
            Rect rect2 = EditorGUILayout.GetControlRect(true, height * 2, null);
            EditorGUILayout.Separator();
            Rect rect3 = EditorGUILayout.GetControlRect(true, height * 2, null);
            EditorGUILayout.Separator();
            Rect rect4 = EditorGUILayout.GetControlRect(true, height * 3, null);
            EditorGUILayout.Separator();
            Rect rect5 = EditorGUILayout.GetControlRect(true, height * 3, null);

            //preview 0
            position = new Vector2(rect0.center.x - width / 2, rect0.min.y);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[0].texture);

            //preview 1
            position = new Vector2(rect1.center.x - width, rect1.min.y);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[0].texture);
            position = new Vector2(rect1.center.x, rect1.min.y);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[0].texture);

            //preview 2
            position = new Vector2(rect2.center.x - width / 2, rect2.min.y);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[0].texture);
            position = new Vector2(rect2.center.x - width / 2, rect2.min.y + height);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[2].texture); 

            //preview 3
            position = new Vector2(rect3.center.x - width, rect3.min.y);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[0].texture);
            position = new Vector2(rect3.center.x, rect3.min.y);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[0].texture);
            position = new Vector2(rect3.center.x - width, rect3.min.y + height);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[2].texture);
            position = new Vector2(rect3.center.x, rect3.min.y + height);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[2].texture);

            //preview 4
            position = new Vector2(rect4.center.x - width / 2, rect4.min.y);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[0].texture);
            position = new Vector2(rect4.center.x - width / 2, rect4.min.y + height);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[1].texture);
            position = new Vector2(rect4.center.x - width / 2, rect4.min.y + height * 2);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[2].texture);

            //preview 5
            position = new Vector2(rect5.center.x - width, rect5.min.y);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[0].texture);
            position = new Vector2(rect5.center.x, rect5.min.y);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[0].texture);
            position = new Vector2(rect5.center.x - width, rect5.min.y + height);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[1].texture);
            position = new Vector2(rect5.center.x, rect5.min.y + height);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[1].texture);
            position = new Vector2(rect5.center.x - width, rect5.min.y + height * 2);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[2].texture);
            position = new Vector2(rect5.center.x, rect5.min.y + height * 2);
            EditorGUI.DrawPreviewTexture(
                new Rect(position, size),
                script.sprites[2].texture);

            // TODO for
        }
    }
}
