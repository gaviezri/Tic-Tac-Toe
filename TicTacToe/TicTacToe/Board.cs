using System;

namespace TicTacToe
{
    public class Board
    {
        private int m_Size;
        private Cell[,] m_Cells;

        public Board(int i_Size)
        {
            m_Size = i_Size;
            m_Cells = new Cell[m_Size, m_Size];
            initializeCells(m_Cells);
        }

        private void initializeCells(Cell[,] i_Cells)
        {
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    i_Cells[i, j] = new Cell();
                }
            }
        }

        public void MakeMove(int i_Row, int i_Column, Cell.eSigns i_Sign)
        {
            m_Cells[i_Row, i_Column].m_Sign = i_Sign;
        }

        public bool IsValidMove(int i_Row, int i_Column)
        {
            return m_Cells[i_Row, i_Column].m_Sign == Cell.eSigns.Empty;
        }
    }
}