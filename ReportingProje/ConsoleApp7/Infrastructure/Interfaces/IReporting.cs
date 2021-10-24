using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp7.Infrastructure.Models;
using System.Collections.Generic;

namespace ConsoleApp7.Infrastructure.Interfaces
{
   public   interface IReporting
    {
        List<Sale> Sales { get; }
 
        double MonthlySaleTotal(DateTime startDate, DateTime endDate);

        string MostSaledProduct();

        int GetSaleCountByCategoryName(string categoryName);

        double SaleTotal();

        double GetTotalSaleByProductName(string productName);

        void AddSale(Sale sale); 

        void RemoveSaleByIndex(int index);
    }
}
