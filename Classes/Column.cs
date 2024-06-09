namespace SODV1202_Connect4.Classes
{
    class Column
    {

        // counter field get, private set.
        /* 
         * separate class for columns so that a board size could potentially be variable
         * a user could define number or rows and columns on the board and the program
         * would create column objects for that number
         * 
         * Columns will need a counter that goes up every time a user add a symbol to that column
         * that way the program can track which symbol on the board needs to be changed
         * If column 3 has 2 symbols stacked already then it would have  a counter of 2,
         * then the symbol to be changed would be in row[number of rows - counter + 1].
         * 
         * there should also be a column list that contains all columns, in this way
         * we can easily access the correct column when the user enters, 1,2 3.. etc.
         * 
         * method to reset counters on game reset
         */
    }
}
