using System;

namespace ConsoleApp7
{
    internal class ConsoleTable
    {
        private string v1;
        private string v2;
        private string v3;
        private string v4;
        private string v5;
        private string v6;
        private string v7;

        public ConsoleTable(string v1, string v2, string v3, string v4, string v5, string v6, string v7)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
            this.v7 = v7;
        }

        
        internal void AddRow(int i, string categoryName, string productName, DateTime date, int quantity, double amount, string v)
        {
            throw new NotImplementedException();
        }
    }
}