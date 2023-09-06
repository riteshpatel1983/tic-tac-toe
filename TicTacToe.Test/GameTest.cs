namespace TicTacToe.Test;
public class GameTest
{
    Game _mockGame;
    [SetUp]
    public void Setup()
    {
        _mockGame = new Game();
    }

    [Test]
    public void IsWin_CheckFirstRowWithOAndX_ReturnInProgress()
    {
        //Arrange
        _mockGame.SetPositionValue(0);
        _mockGame.SetPositionValue(1);
        _mockGame.Icon = "X";
        _mockGame.SetPositionValue(2);

        //Act
        var result = _mockGame.IsWin();

        //Assert
        Assert.That(result, Is.EqualTo(Enums.Result.InProgress));
    }

    [Test]
    public void IsWin_CheckFirstRowWithO_ReturnWin()
    {
        //Arrange
        _mockGame.SetPositionValue(0);
        _mockGame.SetPositionValue(1);
        _mockGame.SetPositionValue(2);

        //Act
        var result = _mockGame.IsWin();

        //Assert
        Assert.That(result, Is.EqualTo(Enums.Result.Win));
    }

    //We can write the similar unit test cases to validate the row 2 and 3 for "O" and row 1, 2 and 3 for "X"

    [Test]
    public void IsWin_CheckFirstColumnWithX_ReturnWin()
    {
        //Arrange
        _mockGame.Icon = "X";
        _mockGame.SetPositionValue(0);
        _mockGame.SetPositionValue(3);
        _mockGame.SetPositionValue(6);

        //Act
        var result = _mockGame.IsWin();

        //Assert
        Assert.That(result, Is.EqualTo(Enums.Result.Win));
    }

    //We can write the similar unit test cases to validate the column 2 and 3 for "X" and row 1, 2 and 3 for "O"

    [Test]
    public void IsWin_CheckForTopLeftBottomRightWithO_ReturnWin()
    {
        //Arrange
        _mockGame.SetPositionValue(0);
        _mockGame.SetPositionValue(4);
        _mockGame.SetPositionValue(8);

        //Act
        var result = _mockGame.IsWin();

        //Assert
        Assert.That(result, Is.EqualTo(Enums.Result.Win));
    }

    //We can write the similar unit test cases to validate other diagonal lines.

    [Test]
    public void IsWin_CheckDraw_ReturnDraw()
    {
        //Arrange
        _mockGame.SetPositionValue(0);
        _mockGame.Icon = "X";
        _mockGame.SetPositionValue(1);
        _mockGame.Icon = "O";
        _mockGame.SetPositionValue(2);
        _mockGame.Icon = "X";
        _mockGame.SetPositionValue(5);
        _mockGame.Icon = "O";
        _mockGame.SetPositionValue(3);
        _mockGame.Icon = "X";
        _mockGame.SetPositionValue(6);
        _mockGame.Icon = "O";
        _mockGame.SetPositionValue(7);
        _mockGame.Icon = "X";
        _mockGame.SetPositionValue(4);
        _mockGame.Icon = "O";
        _mockGame.SetPositionValue(8);

        //Act
        var result = _mockGame.IsWin();

        //Assert
        Assert.That(result, Is.EqualTo(Enums.Result.Draw));
    }

    [Test]
    public void CheckPosition_ValidateIncorrectPosition_ReturnTrue()
    {
        //Act
        var result = _mockGame.CheckPosition(-1);

        //Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckPosition_ValidateCorrectPosition_ReturnFalse()
    {
        //Act
        var result = _mockGame.CheckPosition(6);

        //Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsPositionAvailable_CheckPositionAvailable_ReturnFalse()
    {
        //Arrange
        _mockGame.SetPositionValue(0);

        //Act
        var result = _mockGame.IsPositionAvailable(1); 

        //Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsPositionAvailable_CheckPositionAvailable_ReturnTrue()
    {
        //Arrange
        _mockGame.SetPositionValue(0);

        //Act
        var result = _mockGame.IsPositionAvailable(2);

        //Assert
        Assert.IsTrue(result);
    }
}