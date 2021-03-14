using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    public bool isXTurn;
    public bool isXWon;
    public bool inProcess;
    public bool modeSelected = false;
    public bool isAIMoveEnded = false;
    public int movesCount;
    public int gameMode;
    public WinController popup;
    public CellController[] cells;

    #region //--function to swap players turn
    public void SwapTurn() {
        isXTurn = !isXTurn;
    }
    #endregion

    #region //--WIP make an AI move 
    public void makeMove() {
        //Debug.Log("make move...");
        //check for a AI move
        inProcess = true;
        if (gameMode == 1) {
            
            if (isAIMoveEnded == false) {
                //var i=0;
                //for (i=0; i<9; i++) {
                    var num = Random.Range(0,8);
                    if (cells[num].state == 0) {
                        cells[num].UpdateCellState();
                        
                        AddMove();
                        CheckMatch();
                        isAIMoveEnded = true;
                        SwapTurn();
                    } else {
                        //makeMove();
                    }
                //}
            }
        }
    }
    #endregion

    #region //--WIP attempt to AI make a move
    public void AttemptMove() {
        inProcess = true;
        //Debug.Log("attempt to move...");
        isAIMoveEnded = false;
        if (gameMode == 1) {
            makeMove();
            //Debug.Log("make move in attempt");
        }
        //Debug.Log("end of attempt...");
        SwapTurn();
    }
    #endregion

    #region //--checkout if there is a match on the field
    public void CheckMatch() {
        inProcess = true;
        SaveState();
        //Debug.Log("check match...");
        //brute checkout all sides
        //  ---
        // hor top - 1,2,3
        // hor mid - 4,5,6
        // hor bot - 7,8,9

        // ver left - 1,4,7
        // ver cent - 2,5,8
        // ver right - 3,6,9

        // diag right - 3,5,7
        // diag left - 1,5,9
        // ---

        //not the best way to choose first cell to understand who is a  winner, but its fast...

        // hor top 
        if (cells[0].state == cells[1].state  && cells[1].state == cells[2].state)
        {
            if (cells[0].state != 0)
            {
                popup.MakeMatch();
            }
        }

        //hor mid
        if (cells[3].state == cells[4].state  && cells[4].state == cells[5].state)
        {
            if (cells[3].state != 0)
            {
                popup.MakeMatch();
            }
        }

        //hor bot
        if (cells[6].state == cells[7].state  && cells[7].state == cells[8].state)
        {
            if (cells[6].state != 0)
            {
                popup.MakeMatch();
            }
        }

        //ver left
        if (cells[0].state == cells[3].state && cells[3].state == cells[6].state)
        {
            if (cells[0].state != 0)
            {
                popup.MakeMatch();
            }
        }

        //ver cent
        if (cells[1].state == cells[4].state && cells[4].state == cells[7].state)
        {
            if (cells[1].state != 0)
            {
                popup.MakeMatch();
            }
        }

        //ver right 
        if (cells[2].state == cells[5].state && cells[5].state == cells[8].state)
        {
            if (cells[2].state != 0)
            {
                popup.MakeMatch();
            }
        }

        //diag right
        if (cells[2].state == cells[4].state && cells[4].state == cells[6].state)
        {
            if (cells[2].state != 0)
            {
                popup.MakeMatch();
            }
        }

        //diag left
        if (cells[0].state == cells[4].state && cells[4].state == cells[8].state)
        {
            if (cells[0].state != 0)
            {
                popup.MakeMatch();
            }
        }
    }
    #endregion

    #region //--setup game mode
    public void SetMode(int mode) {
        gameMode = mode;
        modeSelected = true;
    }
    #endregion

    #region //--reset mode to defaults
    public void ResetMode() {
        modeSelected = false;
        ResetMoves();
        inProcess = false;
    }
    #endregion

    #region //--increment moves count and check for maximum moves
    public void AddMove() {
        inProcess = true;
        movesCount++;

        if (movesCount == 9) {
            movesCount = 0;
            popup.MakeTie();
        }
    }
    #endregion

    #region //--reset moves counter
    public void ResetMoves() {
        movesCount = 0;
        isXTurn = false;
        inProcess = false;
    }
    #endregion

    #region //--save state
    public void SaveState() {
        if (inProcess == true) {
            PlayerPrefs.SetInt("process",1);
        } else {
            PlayerPrefs.SetInt("process",0);
        }
        PlayerPrefs.SetInt("moves",movesCount);
        PlayerPrefs.SetInt("mode",gameMode);
        if (isXTurn == true) {
            PlayerPrefs.SetInt("team",1);
        } else {
            PlayerPrefs.SetInt("team",0);
        }

        var i = 0;
        for (i=0; i<cells.Length; i++) {
            var stringName = "cell"+i;
            PlayerPrefs.SetInt(stringName,cells[i].state);
        }
        PlayerPrefs.Save();
    }
    #endregion

    #region //--load game state
    public void LoadState() {
        if (PlayerPrefs.HasKey("process")) {
            if (PlayerPrefs.GetInt("process",0) == 0)
            {
                var i = 0;
                for (i=0; i<cells.Length; i++) {
                    var stringName = "cell"+i;
                    PlayerPrefs.DeleteKey(stringName);
                    
                }
                PlayerPrefs.DeleteKey("moves");
                PlayerPrefs.DeleteKey("mode");
                PlayerPrefs.DeleteKey("team");
                PlayerPrefs.DeleteKey("process");
            } else {
                inProcess = true;
                modeSelected = true;
                gameMode = PlayerPrefs.GetInt("mode",0);
                movesCount = PlayerPrefs.GetInt("moves",0);
                if (PlayerPrefs.GetInt("team",0) == 1) {
                    isXTurn = true;
                } else {
                    isXTurn = false;
                }
                var i = 0;
                for (i=0; i<cells.Length; i++) {
                    var stringName = "cell"+i;
                    cells[i].state = PlayerPrefs.GetInt(stringName,0);
                }
            }
        }
    }
    #endregion

    #region //--clear saved data
    public void ClearState() {
        var i = 0;
        for (i=0; i<cells.Length; i++) {
            var stringName = "cell"+i;
            PlayerPrefs.DeleteKey(stringName);
        }
                
        PlayerPrefs.DeleteKey("moves");
        PlayerPrefs.DeleteKey("mode");
        PlayerPrefs.DeleteKey("process");
    }
    #endregion
}
