using System.Drawing;

class Generation                    // represents 1 iteration of the game
{
    public struct Cell
    {
        public bool hasOrganism;    //does this square have a life form?
        public int state;           //what will happen to this life form (if present)?
        //public bool marked;         //is the cell marked?

        public const int EMPTY = 0;
        public const int SURVIVES = 1;
        public const int DEATH_BY_OVERCROWDING = 2;
        public const int DEATH_BY_LONELINESS = 3;
        public const int SPAWNING = 4;
        public const int UNMARKED = 5;
        public Cell(bool hasOrganism)
        {
            this.hasOrganism = hasOrganism;
            this.state = EMPTY;
            //this.marked = false;
        }
    }
    public const int BOARD_WIDTH = 30; // How many Cells wide the board is
    public const int BOARD_HEIGHT = 20; // How many Cells tall the board is
    public const int CELL_SIZE = 20;    // How big a cell is in pixels

    public Cell[,] board;               // 2d array of Cell structs
    public Image[] images = new Image[BOARD_WIDTH * BOARD_HEIGHT];
    public Generation nextGen;

    public Generation()
    {
        board = new Cell[BOARD_WIDTH, BOARD_HEIGHT];
        LoadImages();
    }

    void LoadImages() // initialize image for each cell state
    {
        images[Cell.EMPTY] = (Image)GameOfLife.Properties.Resources.ResourceManager.GetObject("life_empty");
        images[Cell.UNMARKED] = (Image)GameOfLife.Properties.Resources.ResourceManager.GetObject("life_unmarked");
        images[Cell.SPAWNING] = (Image)GameOfLife.Properties.Resources.ResourceManager.GetObject("life_birthing");
        images[Cell.DEATH_BY_OVERCROWDING] = (Image)GameOfLife.Properties.Resources.ResourceManager.GetObject("life_overcrowded");
        images[Cell.DEATH_BY_LONELINESS] = (Image)GameOfLife.Properties.Resources.ResourceManager.GetObject("life_sad");
        images[Cell.SURVIVES] = (Image)GameOfLife.Properties.Resources.ResourceManager.GetObject("life_happy");
    }

    public void Mark()
    {
        int bw = BOARD_WIDTH;
        int bh = BOARD_HEIGHT;
        //for (int i = 0; i < bw; i++)
        //{ for (int j = 0; j < bh; j++)    // Loop over all the rows and columns in the board
        //    { MarkCell(i,j); }              // and call MarkCell() on each of them
        //}
        for (int i = 0; i < bh; i++)
        {
            for (int j = 0; j < bw; j++)    // Loop over all the rows and columns in the board
            { MarkCell(j, i); }              // and call MarkCell() on each of them
        }
    }

    public void Draw(Graphics g, bool showInMarkedState)
    {
        for (int i = 0; i < BOARD_WIDTH; i++)
        {
            for (int j = 0; j < BOARD_HEIGHT; j++)  // Loop over all the rows and columns (i,j) using a nested loop
            {  // Look at the state flag in cell i,j and draw the appropriate icon
                if (showInMarkedState)          // draw the icon that represents what is going to happen to that organism
                {
                    switch (board[i, j].state)    // Look at the state flag in cell i,j and draw the appropriate icon
                    {
                        case Cell.EMPTY:
                            g.DrawImage(images[Generation.Cell.EMPTY],
                                    i * Generation.CELL_SIZE, j * Generation.CELL_SIZE);
                            break;
                        case Cell.DEATH_BY_LONELINESS:
                            g.DrawImage(images[Generation.Cell.DEATH_BY_LONELINESS],
                                    i * Generation.CELL_SIZE, j * Generation.CELL_SIZE);
                            break;
                        case Cell.SURVIVES:
                            g.DrawImage(images[Generation.Cell.SURVIVES],
                                    i * Generation.CELL_SIZE, j * Generation.CELL_SIZE);
                            break;
                        case Cell.DEATH_BY_OVERCROWDING:
                            g.DrawImage(images[Generation.Cell.DEATH_BY_OVERCROWDING],
                                    i * Generation.CELL_SIZE, j * Generation.CELL_SIZE);
                            break;
                        case Cell.SPAWNING:
                            g.DrawImage(images[Generation.Cell.SPAWNING],
                                    i * Generation.CELL_SIZE, j * Generation.CELL_SIZE);
                            break;
                        default:
                            g.DrawImage(images[Generation.Cell.UNMARKED],
                                    i * Generation.CELL_SIZE, j * Generation.CELL_SIZE);
                            break;
                    }
                }
                else
                {   // just draw the generic organism icon
                    if (board[i, j].hasOrganism) // Look at the state flag in cell i,j and draw the appropriate icon.
                    {
                        g.DrawImage(images[Generation.Cell.SURVIVES],
                                      i * Generation.CELL_SIZE, j * Generation.CELL_SIZE);
                    }
                    else
                    {
                        g.DrawImage(images[Generation.Cell.EMPTY],
                                  i * Generation.CELL_SIZE, j * Generation.CELL_SIZE);

                }
            }
        }
    }
}

public bool IsExtinct() // this function is called by Form1 to check if the game is over
{
    for (int i = 0; i < BOARD_WIDTH; i++)
    {  for (int j = 0; j < BOARD_HEIGHT; j++)
        {
            if (board[i, j].hasOrganism)
                return false;    // return true if any square on the board has an organism in it
        }
    }
    return true;               // otherwise, return false
}

void MarkCell(int x, int y)
{ /* This function sets the state flag on a Cell based on whether
         it is going to live or die (so the appropriate icon can be drawn)

        Count up the number of organisms in the surrounding 8 cells using CountOrganism(x,y) passing in the coordinates
        of the squares surrounding x,y. Based on that number, set
        the state flag in the cell to the appropriate constant (defined in the Cell struct) 
        based on the rules of the game outlined in the instructions.

        Hint: This is similar to FloodIt, where each square calls Fill() on its neighbors.
        */

        Cell TestCell = board[x, y];
        int orgCount = CountOrganism(x, y);

    switch (orgCount)
    {
        case 0:
        case 1:
            if (TestCell.hasOrganism)
            {
                //board[x, y].hasOrganism = false;
                board[x, y].state = Cell.DEATH_BY_LONELINESS;
            }
            break;
        case 2:
            if (TestCell.hasOrganism)
                board[x, y].state = Cell.SPAWNING;
            break;
        case 3:
            //board[x, y].hasOrganism = true;             // survives or born
            board[x, y].state = Cell.SPAWNING;
            break;
        case 4:
        case 5:
        case 6:
        case 7:
        case 8:
            if (board[x, y].hasOrganism)
            {
                //board[x, y].hasOrganism = false;
                board[x, y].state = Cell.DEATH_BY_OVERCROWDING;
            }
            break;
    }
}

public int CountOrganism(int x, int y)     // y max is BOARD_HEIGHT; x max is BOARD_WIDTH
{
    if (x < 0 || x > BOARD_WIDTH || y < 0 || y > BOARD_HEIGHT)
    {
        return 0; // If x or y is outside the 2d array bounds, return 0
    } // Otherwise if the Cell at x,y has a lifeform return 1, otherwise return 0.
        int orgCounter = 0;

        if (x > 0)
        {
            if (board[x - 1, y].hasOrganism) { orgCounter++; }
            if (y > 0) { if (board[x - 1, y - 1].hasOrganism) { orgCounter++; } }
            if (y < BOARD_HEIGHT - 1) { if (board[x - 1, y + 1].hasOrganism) { orgCounter++; } }
        }

        if (x < BOARD_WIDTH - 1)
        {
            if (board[x + 1, y].hasOrganism) { orgCounter++; }
            if (y > 0) { if (board[x + 1, y - 1].hasOrganism) { orgCounter++; } }
            if (y < BOARD_HEIGHT - 1)
            { if (board[x + 1, y + 1].hasOrganism) { orgCounter++; } }
        }

        if (y > 0) { if (board[x, y - 1].hasOrganism) { orgCounter++; } }
        if (y < BOARD_HEIGHT - 1) { if (board[x, y + 1].hasOrganism) { orgCounter++; } }

        return orgCounter;
    }

public Generation Update()
{ // This function is where the "state" flag is applied to produce the next iteration of the game
    nextGen = new Generation();         // Create a new Generation object (nextGen)

    for (int i = 0; i < BOARD_HEIGHT  ; i++)
    {
        for (int j = 0; j < BOARD_WIDTH; j++)
        { // Loop over all the rows and columns (i,j) of the new board using nested loops.
                //nextGen.board[i, j].hasOrganism = false;    // set the marked flag at i,j to false.
                //nextGen.board[i, j].state = Cell.EMPTY;     // set the state flags of the cell at i,j to EMPTY

                //if (board[i, j].hasOrganism && board[i, j].state == Cell.SURVIVES)
                //{   //  If the old board at i,j has an organism and is marked SURVIVES 
                //    nextGen.board[i, j].state = Cell.UNMARKED;  // set the new board’s cell at i,j to UNMARKED
                //    nextGen.board[i, j].hasOrganism = true;     // and its hasOrganism variable to true
                //}

                //if (board[i, j].state == Cell.SPAWNING) // If the old board at i,j ‘s state is SPAWNING
                //{   nextGen.board[i, j].state = Cell.UNMARKED;  // set the new board’s cell at i,j to UNMARKED
                //    nextGen.board[i, j].hasOrganism = true;     // and its hasOrganism variable to true
                //}

            if (board[j, i].state==Cell.SPAWNING)
            {
                nextGen.board[j, i].state = Cell.SURVIVES;  // set the new board’s cell at i,j to SURVIVES
                nextGen.board[j, i].hasOrganism = true;     // and its hasOrganism variable to true
            }

        }
    }
    return nextGen;
}

public void AddOrganism(int x, int y)
{
    board[x, y].hasOrganism = true;     // set the hasOrganism variable in the cell at x,y to true
    board[x, y].state = Cell.SURVIVES;
}

public bool Equals(Generation g)
{ // This function is used by the form to determine if the current state is identical to a previous state.
    for (int i = 0; i < BOARD_WIDTH; i++)
    {
        for (int j = 0; j < BOARD_HEIGHT; j++)
        { //Use nested loops to compare the hasOrganism variables in the two board arrays
            if (g.board[i, j].hasOrganism != board[i, j].hasOrganism)
                return false;   // If you find cells that don’t match, return false
        }
    }
    return true;                // After the loops, return true
}

}
