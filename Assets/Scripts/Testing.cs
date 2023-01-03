using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gridHelper;

public class Testing : MonoBehaviour
{
    private Grid grid;
    private void Start() {
        grid = new Grid(4,2, new Vector3(0, 10), 10f);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) { // if you click the mouse...
            grid.SetValue(gridHelper.cameraMousePositioning.getMousePos(), 56); // change the value in the grid that corresponds to the mouse's position to 56 (if there is a cell there)
            // Debug.Log(gridHelper.cameraMousePositioning.getMousePos());
            // gridHelper.cameraMousePositioning.getMousePos();
        }

        if (Input.GetMouseButtonDown(1)) {
            int value = grid.GetValue(gridHelper.cameraMousePositioning.getMousePos());
            Debug.Log(value);
            // Debug.Log(gridHelper.cameraMousePositioning.getMousePos());
        }
    }
}
