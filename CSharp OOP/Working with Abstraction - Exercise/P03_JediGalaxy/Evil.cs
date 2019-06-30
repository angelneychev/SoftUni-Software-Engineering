using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    class Evil
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public long Score { get; private set; }

        public void UpdateCoordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
