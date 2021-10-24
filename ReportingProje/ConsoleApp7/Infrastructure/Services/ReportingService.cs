using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp7.Infrastructure.Interfaces;
using ConsoleApp7.Infrastructure.Models;
using System.Linq;

namespace ConsoleApp7.Infrastructure.Services
{
    class ReportingService : IReporting
    {
        private List<Sale> _sales;
        public List<Sale> Sales => _sales;
        public ReportingService()
        {
            _sales = new List<Sale>();
        }

        public void AddSale(Sale sale)
        {
            _sales.Add(sale);
        }

        public int GetSaleCountByCategoryName(string categoryName)
        {
           return _sales.Where(s => s.CategoryName == categoryName).Sum(s => s.Quantity);
        }

        public double GetTotalSaleByProductName(string productName)
        {
            return _sales.Where(s => s.ProductName == productName).Sum(s => s.Amount * s.Quantity);
        }

        public double MonthlySaleTotal(DateTime startDate, DateTime endDate)
        {
            return _sales.Where(s => s.Date >= startDate && s.Date <= endDate).Sum(s => s.Quantity * s.Amount); 
        }

        public string MostSaledProduct()
        {
            //int max = 0;
            //int maxindex = 0;
            //for (int i = 1; i < _sales.Count; i++)
            //{
            //    if (_sales[i].Quantity>max)
            //    {
            //        max = _sales[i].Quantity;
            //        maxindex = i;
            //    }
            //}
            //return _sales[maxindex].ProductName;

            return _sales.OrderByDescending(s => s.Quantity).FirstOrDefault().ProductName;
          
        }

        public void RemoveSaleByIndex(int index)
        {
            _sales.RemoveAt(index);
        }

        public double SaleTotal()
        {
           return  _sales.Sum(s => s.Quantity * s.Amount);
        }
    }
}
