using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace gridHelper
{
    //public float cellSize;
    // Start is called before the first frame update
    public static class cellMaker {

        public static TextMeshPro createCell(string content, Vector3 position, int fontSize, Color color, TextAlignmentOptions alignment) {
            GameObject obj = new GameObject("cell", typeof(TextMeshPro));
            Transform transform = obj.GetComponent<Transform>();
            transform.position = position;
            TextMeshPro textmesh = obj.GetComponent<TextMeshPro>();
            textmesh.text = content;
            textmesh.color = color;
            textmesh.fontSize = fontSize;
            textmesh.alignment = alignment;
            return textmesh;
        }

    }

    public static class cameraMousePositioning {
        public static Vector3 getMousePos() {
            Vector3 vec = getMousePoswithZ(Input.mousePosition, Camera.main);
            vec.z = 0f; // 2d game doesnt need z, unless...?
            return vec;
        }

        public static Vector3 getMousePoswithZ(Vector3 screenPosition, Camera worldCamera) {
            Vector3 worldPos = worldCamera.ScreenToWorldPoint(screenPosition); // converts the point that you click on the screen to the point that's the same in the world
            return worldPos;
        }
    }
    

}
