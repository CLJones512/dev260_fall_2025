**Game Rules**
    There is a three-by-three grid, labeled like a chessboard. Each player is asked to
    input a square using row and column labels (A1, A2, A3, B1, etc.) The program then checks
    to see that the input is in bounds and not occupied, then places a mark there. If one player
    gets three marks in a row, horizontally, vertically, or diagonally, that player wins. If the
    board fills up with no player getting three in a row, the game ends as a draw.

**Multidimensional Array Usage**
    I used a three-by-three array to simulate a tic-tac-toe grid. Each column has a letter, which
    is converted to an int, then both the ints for the columns and rows are subtracted by one to find
    the index (ie. A1 becomes board[0,0]).