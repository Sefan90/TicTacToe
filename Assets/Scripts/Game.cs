using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject X;
    public GameObject O;

    private bool nextplayer; //False = X & True = O
    private bool win;
    private int[,] grid;
    // Start is called before the first frame update
    void Start()
    {
        nextplayer = false;
        win = false;
        grid = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    }

    // Update is called once per frame
    void Update()
    {
        int mouseX = (int)Input.mousePosition.x / (Camera.main.pixelWidth / 3);
        int mouseY = (int)Input.mousePosition.y / (Camera.main.pixelHeight / 3);
        print(mouseX);
        if (Input.GetMouseButtonDown(0) && mouseX >= 0 && mouseX <= 2 && mouseY >= 0 && mouseY <= 2 && win == false)
        {
            if (grid[mouseX, mouseY] == 0)
            {
                if (nextplayer)
                {
                    Instantiate(X, new Vector3(mouseX, mouseY - 2, 0), Quaternion.identity);
                    grid[mouseX, mouseY] = 1;
                }
                else
                {
                    Instantiate(O, new Vector3(mouseX, mouseY - 2, 0), Quaternion.identity);
                    grid[mouseX, mouseY] = 2;
                }
                nextplayer = !nextplayer;
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        CheckIfWin();
    }

    void CheckIfWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if ((grid[i, 0] != 0 && grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2]) || (grid[0, i] != 0 && grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i])
                || (grid[0, 0] != 0 && grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2]) || (grid[0, 2] != 0 && grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0]))
            {
                if (win == false)
                    win = true;
                break;
            }
        }
    }
}
