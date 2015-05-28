/*
    Working with multidimensional arrays can be (and should be) fun. Let's make a game out of it.
    
    You receive the layout of a board from the console.
    Assume it will always have 4 rows which you'll get as strings, each on a separate line.
    Each character in the strings will represent a cell on the board.
    Note that the strings may be of different length.
    You are the player and start at the top-left corner (that would be position [0, 0] on the board).
    On the fifth line of input you'll receive a string
    with movement commands which tell you where to go next,
    it will contain only these four characters
    '>' (move right), '<' (move left), '^' (move up) and 'v' (move down). 
    You need to keep track of two types of events
    – collecting coins (represented by the symbol '$', of course)
    and hitting the walls of the board (when the player tries to move off the board to invalid coordinates).
    When all moves are over, print the amount of money collected and the number of walls hit.
    
    Example:

    Sj0u$hbc      | Coins collected: 2 |  Starting from (0, 0), move down (coin),
    $87yihc87     |                    |  twice right, up, up again (wall), 
    Ewg3444       | Walls hit: 2       |  three times right (coin on second move), 
    $4$$          |                    |  twice down, down again (wall), 
    V>>^^>>>VVV<< |                    |  twice to the left – game over (no more moves).
    
    Total of two coins collected and two walls hit in the process.
*/

namespace CollectTheCoins
{
    using System;

    class CollectTheCoins
    {
        private static void Main()
        {
            //INIT BOARD
            string[][] board = new string[4][];

            //FILL BOARD
            for (int i = 0; i < 4; i++)
            {
                string inputLine = Console.ReadLine();
                board[i] = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            //GET MOVES
            string moves = Console.ReadLine();

            //INIT DEFAULT VALUES
            int wallsHit = 0,
                coinsCollected = 0,
                row = 0,
                rowLength = board.Length,
                col = 0,
                colLength = board[row].Length;


            for (int i = 0; i < moves.Length; i++)
            {
                //IF CAN MOVE ROW/COL ELSE HIT WALL++
                switch (moves[i])
                {
                    case '^':
                        if (row - 1 >= 0)
                        {
                            row--;
                            break;
                        }
                        wallsHit++;
                        break;
                    case '>':
                        if (col + 1 < colLength)
                        {
                            col++;
                            break;
                        }
                        wallsHit++;
                        break;
                    case 'v':
                        if (row + 1 < rowLength)
                        {
                            row++;
                            break;
                        }
                        wallsHit++;
                        break;
                    case '<':
                        if (col - 1 >= 0)
                        {
                            col--;
                            break;
                        }
                        wallsHit++;
                        break;
                    default: break;
                }

                //IF ROW/COL CONTAIN $, COINS COLLECTED++
                if (board[row][col] == "$")
                {
                    coinsCollected++;
                }
            }

            Console.WriteLine("Coins collected: {0}\r\nWall hits: {1}", coinsCollected, wallsHit);
        }
    }
}
