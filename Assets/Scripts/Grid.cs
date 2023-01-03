using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using gridHelper;

public class Grid
{
    public int width;
    public int height;

    public Vector3 originPos;
    private int[,] gridArray;
    private TextMeshPro[,] debugTextArray;

    private float cellSize;

    
    public Grid(int width, int height, Vector3 originPos, float cellSize)  { // "origin" is bottom left, careful counting rows and columns
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPos = originPos;
        

        gridArray = new int[width, height];
        debugTextArray = new TextMeshPro[width, height];

        Debug.Log(width + " " + height);

        for (int x = 0; x < gridArray.GetLength(0); x++) {
            for (int y = 0; y < gridArray.GetLength(1); y++) { // [x,y] refers to the lower left position of each cell
                debugTextArray[x,y] = gridHelper.cellMaker.createCell(gridArray[x,y].ToString(), GetWorldPosition(x,y) + new Vector3(1,1) * cellSize * 0.5f, 20, Color.white, TMPro.TextAlignmentOptions.CenterGeoAligned);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y+1), Color.white, 100f); // left vertical line of each cell
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x+1, y), Color.white, 100f); // bottom horizontal line of each cell
                Debug.Log(x + " " + y);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f); // height is literally the int specified
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    
        //SetValue(2,1,56);
    }

    private Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x,y) * cellSize + originPos;
    }

    private Vector2Int GetXY(Vector3 worldPosition) {
        Vector2Int retVec = new Vector2Int(Mathf.FloorToInt((worldPosition.x - originPos.x) / cellSize), Mathf.FloorToInt((worldPosition.y - originPos.y) / cellSize)); // peform calc then floor and make it an int
        return retVec;
    }

    public void SetValue(int x, int y, int value) {
        if (x >= 0 && y >= 0 && y < height && x < width ) {
            gridArray[x,y] = value;
            debugTextArray[x,y].text = value.ToString(); // get component is apparently pretty costly, beware!
        }
    }

    public void SetValue(Vector3 worldPosition, int value) {
        Vector2Int XYpos = GetXY(worldPosition); // if the world position is out of the grid, itll throw an error!!!
        SetValue(XYpos.x, XYpos.y, value); // use previously created version to make this version of the function
    }

    public int GetValue(int x, int y) {
        if (x >= 0 && y >= 0 && y < height && x < width) { // must deal with invalid values
            return gridArray[x,y]; // unique way of retrieving values from 2 dimensional arrows in c#
        } else {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPosition) {
        Vector2Int XYpos = GetXY(worldPosition);
        return GetValue(XYpos.x, XYpos.y);
    }
}


