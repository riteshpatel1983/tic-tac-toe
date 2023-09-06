using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe;

public class Game
{
    public string[] BoardValue = new string[] { "", "", "", "", "", "", "", "", "" };

    public string Icon = "O";

    /// <summary>
    /// Set the position value with selected icon for the current user
    /// </summary>
    /// <param name="position">Position value between 0 to 8</param>
    public void SetPositionValue(int position)
    {
        BoardValue[position] = Icon;
    }

    /// <summary>
    /// Determine the player is win 
    /// </summary>
    /// <returns>Player is Win, Draw or Inprogress</returns>
    public Enums.Result IsWin()
    {
        if (IsLine(0, 1) || IsLine(3, 1) || IsLine(6, 1) ||      //Horizontal Lines
           IsLine(0, 3) || IsLine(1, 3) || IsLine(2, 3) ||      //Vertical Lines
           IsLine(0, 4) || IsLine(2, 2)) //Diagonal Lines
        {
            return Enums.Result.Win;
        }
        else if (!BoardValue.Contains(""))
        {
            return Enums.Result.Draw;
        }
        else
        {
            return Enums.Result.InProgress;
        }
    }

    /// <summary>
    /// Check the line has same icon
    /// </summary>
    /// <param name="startIndex">Start index</param>
    /// <param name="skipCount">Skip number to next position</param>
    /// <returns>True if line has same Icon</returns>
    private bool IsLine(int startIndex, int skipCount)
    {
        return IsAllValueSame(startIndex, (startIndex + skipCount), (startIndex + skipCount + skipCount));
    }

    /// <summary>
    /// Check all position has same icon
    /// </summary>
    /// <param name="firstPosition">Frist position</param>
    /// <param name="secondPosition">Second position</param>
    /// <param name="thirdPosition">Third position/param>
    /// <returns>True if line has same Icon</returns>
    private bool IsAllValueSame(int firstPosition, int secondPosition, int thirdPosition)
    {
        return (BoardValue[firstPosition] == Icon && BoardValue[secondPosition] == Icon && BoardValue[thirdPosition] == Icon);
    }

    /// <summary>
    /// Check the position number between range
    /// </summary>
    /// <param name="position">Range from 1 to 9</param>
    /// <returns>Return true if position between 1 to 9</returns>
    public bool CheckPosition(int position)
    {
        return (position < 1 || position > 9);
    }
    /// <summary>
    /// Check the position is used by another player
    /// </summary>
    /// <param name="position">Range from 0 to 8</param>
    /// <returns>Return true is position available</returns>
    public bool IsPositionAvailable(int position)
    {
        return (string.IsNullOrEmpty(BoardValue[position - 1]));
    }

}
