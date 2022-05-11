using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float previousTime;
    private float fallTime = 0.8f;
    private static int width = 10, height = 20;
    private static Transform[,] grid = new Transform[width, height];
    private Vector3 rotationPoint;


    void Start()
    {
        transform.SetParent(Locator.i.gameManager.BlocksParent);
    }
    
    void Update()
    {
        if (Locator.i.gameManager.CurrentGameState != GameManager.GameState.Play) return;


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
            if (!ValidMove())
            {
                transform.position -= Vector3.left;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            if (!ValidMove())
            {
                transform.position -= Vector3.right;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), Vector3.forward, 90);

            if (!ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), Vector3.forward, -90);
            }
        }


        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += Vector3.down;
            if (!ValidMove())
            {
                transform.position -= Vector3.down;
                AddToGrid();
                CheckLines();
                this.enabled = false;
                Locator.i.gameManager.CreateBlock();
            }
            previousTime = Time.time;
        }
    }


    void CheckLines()
    {
        //y座標を１ずつチェック (20回)
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDownBlocks(i);
            }
        }
    }

    //ラインがあるかどうか
    bool HasLine(int i)
    {
        //x座標でブロックの有無を確認
        for (int j = 0; j < width; j++)
        {
            // (grid == null )=> グリットのx座標に空きがある状態
            if (grid[j, i] == null)
            {
                return false;
            }
        }
        // gridのx座標が全てブロックで埋まっている
        Locator.i.gameManager.AddScore();
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            grid[j, i].gameObject.SetActive(false);
            grid[j, i] = null;
        }
    }
    void RowDownBlocks(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position += Vector3.down;
                }
            }
        }
    }
    //グリットの情報を追加
    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundX, roundY] = children;
            if (roundY >= height - 1)
            {
                Locator.i.gameManager.CurrentGameState = GameManager.GameState.GameOver;
            }
        }

    }
    bool ValidMove()
    {
        foreach (Transform block in transform)
        {
            int roundX = Mathf.RoundToInt(block.transform.position.x);
            int roundY = Mathf.RoundToInt(block.transform.position.y);

            if (roundX < 0 || roundX >= width || roundY < 0 || roundY >= height)
            {
                return false;
            }

            if (grid[roundX, roundY] != null)
            {
                return false;
            }
        }
        return true;
    }
}

