// See https://aka.ms/new-console-template for more information

using TicTacToe;

Console.WriteLine("Select the position in the below format");
Console.WriteLine("  1  2  3");
Console.WriteLine("  4  5  6");
Console.WriteLine("  7  8  9");

Console.WriteLine("-------------------");

Console.WriteLine("Player 1: O");
Console.WriteLine("Player 2: X");

Game game = new Game();
int playerNumber = 1;

for (int i = 0; i < 9; i++)
{
    Console.WriteLine("");
    Console.WriteLine("Player{0} select the position", playerNumber);

    int position = 0;
    var isParsed = Int32.TryParse(Console.ReadLine(), out position);

    if (game.CheckPosition(position))
    {
        Console.WriteLine("Enter the correct position");
        continue;
    }

    //if (!string.IsNullOrEmpty(game.BoardValue[position - 1]))
    if(!game.IsPositionAvailable(position))
    {
        Console.WriteLine("Position is already selected. Select position again:");
        continue;
    }
    game.SetPositionValue(position - 1);

    for (int j = 0; j < 9; j++)
    {
        if(j%3 == 0)
        {
            Console.WriteLine("");
        }
        Console.Write("  {0}", string.IsNullOrEmpty(game.BoardValue[j]) ? "-" : game.BoardValue[j]);
    }

    var result = game.IsWin();

    if(result == Enums.Result.Win)
    {
        Console.WriteLine("\n Player {0} is win", playerNumber);
        break;
    }
    else if(result == Enums.Result.Draw)
    {
        Console.WriteLine("\n No one win. Game is draw.");
        break;
    }

    if(playerNumber == 1)
    {
        playerNumber = 2;
        game.Icon = "X";
    }
    else
    {
        playerNumber = 1;
        game.Icon = "O";
    }
}