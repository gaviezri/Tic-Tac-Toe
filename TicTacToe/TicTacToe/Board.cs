using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        public int m_Size { get; set; }
        public Cell[,] m_Cells { get; }
        public int[][] m_LosingCombinations { get; }
        private int m_EmptyCells;

        public Board(int i_Size)
        {
            m_Size = i_Size;
            m_Cells = initializeCells();
            m_LosingCombinations = generateLosingCombinations();
            m_EmptyCells = m_Size * m_Size;
        }

        private Cell[,] initializeCells()
        {
            Cell[,] boardCells = new Cell[m_Size, m_Size];

            for (int row = 0; row < m_Size; row++)
            {
                for (int column = 0; column < m_Size; column++)
                {
                    boardCells[row, column] = new Cell(Cell.eSigns.Empty);
                }
            }

            return boardCells;
        }

        private int[][] generateLosingCombinations()
        {
            List<int[]> losingCombinations = new List<int[]>();
            
            for (int row = 0; row < m_Size; row++)
            {
                List<int> rowLosingCombination = new List<int>();
                for (int column = 0; column < m_Size; column++)
                {
                    rowLosingCombination.Add(row * m_Size + column);
                }
                losingCombinations.Add(rowLosingCombination.ToArray());
            }
            
            for (int column = 0; column < m_Size; column++)
            {
                List<int> columnLosingCombination = new List<int>();
                for (int row = 0; row < m_Size; row++)
                {
                    columnLosingCombination.Add(row * m_Size + column);
                }
                losingCombinations.Add(columnLosingCombination.ToArray());
            }
            
            List<int> topLeftDiagonalCombination = new List<int>();
            for (int i = 0; i < m_Size; i++)
            {
                topLeftDiagonalCombination.Add(i * m_Size + i);
            }
            losingCombinations.Add(topLeftDiagonalCombination.ToArray());
            
            List<int> topRightDiagonalCombination = new List<int>();
            for (int i = 0; i < m_Size; i++)
            {
                topRightDiagonalCombination.Add(i * m_Size + (m_Size - 1 - i));
            }
            losingCombinations.Add(topRightDiagonalCombination.ToArray());
            
            return losingCombinations.ToArray();
        }

        public void MakeMove(int i_RowWithOffset, int i_ColumnWithOffset, Cell.eSigns i_Sign)
        {
            m_Cells[i_RowWithOffset - 1, i_ColumnWithOffset - 1].m_Sign = i_Sign;
            m_EmptyCells--;
        }

        public bool IsBoardNotFull()
        {
            return m_EmptyCells > 0;
        }

        public bool IsValidMove(int i_RowWithOffset, int i_ColumnWithOffset)
        {
            return m_Cells[i_RowWithOffset - 1, i_ColumnWithOffset - 1].m_Sign == Cell.eSigns.Empty;
        }
    }
}