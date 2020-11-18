using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCut : MonoBehaviour
{
    [Range(0, 50)]
    public int beginRow, rowCount, targetBeginRow;
    [Range(0, 100)]
    public int beginColumn, columnCount, targetBeginColumn;

    private int[,] array = new int[50, 100];

    public void OnCutBtnClick()
    {
        Cut(beginRow, rowCount, beginColumn, columnCount, targetBeginRow, targetBeginColumn);
    }

    public void Cut(int beginRow, int rowCount, int beginColumn, int columnCount, int targetBeginRow, int targetBeginColumn)
    {
        if (targetBeginRow + rowCount >= 50 || targetBeginColumn + columnCount >= 100)
        {
            Debug.LogError("非法操作!超越数组边界");
            return;
        }
        //目标行与起始行相等
        if (targetBeginRow == beginRow)
        {
            //目标列在起始列的右侧：反向循环
            if (targetBeginColumn > beginColumn)
            {
                for (int col = targetBeginColumn + columnCount - 1; col >= targetBeginColumn; col--)
                {
                    for (int row = targetBeginRow; row < targetBeginRow + rowCount; row++)
                    {
                        array[row, col] = array[row, col - (targetBeginColumn - beginColumn)];
                    }
                }
            }
            //目标列在起始列的左侧：正向循环
            else if (targetBeginColumn < beginColumn)
            {
                for (int col = targetBeginColumn; col < targetBeginColumn + columnCount; col++)
                {
                    for (int row = targetBeginRow; row < targetBeginRow + rowCount; row++)
                    {
                        array[row, col] = array[row, col - (targetBeginColumn - beginColumn)];
                    }
                }
            }
            else
            {
                Debug.Log("目标行、列与起始行、列均相同，无需进行操作");
                return;
            }
        }

        //目标行在起始行上方：反向循环
        else if (targetBeginRow > beginRow)
        {
            for (int row = targetBeginRow + rowCount - 1; row >= targetBeginRow; row--)
            {
                //目标列在起始列的右侧：反向循环
                if (targetBeginColumn > beginColumn)
                {
                    for (int col = targetBeginColumn + columnCount - 1; col >= targetBeginColumn; col--)
                    {
                        array[row, col] = array[row - (targetBeginRow - beginRow), col - (targetBeginColumn - beginColumn)];
                    }
                }
                //目标列在起始列的左侧：正向循环
                else if (targetBeginColumn < beginColumn)
                {
                    for (int col = targetBeginColumn; col < targetBeginColumn + columnCount; col++)
                    {
                        array[row, col] = array[row - (targetBeginRow - beginRow), col - (targetBeginColumn - beginColumn)];
                    }
                }
            }
        }

        //目标行在起始行下方：正向循环
        else if (targetBeginRow < beginRow)
        {
            for (int row = targetBeginRow; row < targetBeginRow + rowCount; row++)
            {
                //目标列在起始列的右侧：反向循环
                if (targetBeginColumn > beginColumn)
                {
                    for (int col = targetBeginColumn + columnCount - 1; col >= targetBeginColumn; col--)
                    {
                        array[row, col] = array[row - (targetBeginRow - beginRow), col - (targetBeginColumn - beginColumn)];
                    }
                }
                //目标列在起始列的左侧：正向循环
                else if (targetBeginColumn < beginColumn)
                {
                    for (int col = targetBeginColumn; col < targetBeginColumn + columnCount; col++)
                    {
                        array[row, col] = array[row - (targetBeginRow - beginRow), col - (targetBeginColumn - beginColumn)];
                    }
                }
            }
        }

        //目标列与起始列相等
        else if (targetBeginColumn == beginColumn)
        {
            //目标行在起始行的上方：反向循环
            if (targetBeginRow > beginRow)
            {
                for (int row = targetBeginRow + rowCount - 1; row >= targetBeginRow; row--)
                {
                    for (int col = targetBeginColumn; col < targetBeginColumn + columnCount; col++)
                    {
                        array[row, col] = array[row - (targetBeginRow - beginRow), col];
                    }
                }
            }
            //目标行在起始行的下方：正向循环
            else if (targetBeginRow < beginRow)
            {
                for (int row = targetBeginRow; row < targetBeginRow + rowCount; row++)
                {
                    for (int col = targetBeginColumn; col < targetBeginColumn + columnCount; col++)
                    {
                        array[row, col] = array[row - (targetBeginRow - beginRow), col];
                    }
                }
            }
            else
            {
                Debug.Log("目标行、列与起始行、列均相同，无需进行操作");
                return;
            }
        }
    }

    public void RandomArray()
    {
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                array[i, j] = Random.Range(0, 9);
            }
        }
    }

    public void PrintArray()
    {
        for (int i = 0; i < 50; i++)
        {
            string row = "";
            for (int j = 0; j < 100; j++)
            {
                if (j < 99)
                {
                    row += array[i, j].ToString() + ",";
                }
                else
                {
                    row += array[i, j].ToString() + ";";
                }
            }
            Debug.Log(row);
        }
        Debug.Log("-------------------------------------------------");
        Debug.Log("-------------------------------------------------");
        Debug.Log("-------------------------------------------------");
    }
}
