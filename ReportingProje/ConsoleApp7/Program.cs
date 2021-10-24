using System;
using System.Text;
using ConsoleApp7.Infrastructure.Services;
using ConsoleApp7.Infrastructure.Models;
namespace ConsoleApp7
{
    class Program
    {
        private static ReportingService _reportingService= new ReportingService();

       
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int selectInt = 0;

            do 
            {
                Console.WriteLine("Seçimini edin:");
                Console.WriteLine("1.Satışların siyahısı");
                Console.WriteLine("2.Yeni Satış əlavə et");
                Console.WriteLine("3.Satışı ləğv et");
                Console.WriteLine("4.Kateqoriya adina gore satislarl ");
                Console.WriteLine("5.Mehsul adina gore satislari gor");
                Console.WriteLine("6.Ayliq satislarin toplamini gor");
                Console.WriteLine("7.En cox satilan mehsulu gor");
                Console.WriteLine("8.Toplam satisi gor");
                Console.WriteLine("0.Çıxış");

                string select = Console.ReadLine();
                while (!int.TryParse(select,out selectInt))
                {
                    Console.WriteLine("Rəqəm daxil etməlisiniz");
                    select = Console.ReadLine();
                }
                switch (selectInt)
                {
                    case 0:                       
                        continue;
                    case 1:
                        Salelist();
                        break;
                    case 2:
                        AddSale();
                        break;
                    case 3:
                        DeleteSale();
                        break;
                    case 4:
                        SaleByCategoryName();
                        break;
                    case 5:
                        SaleByProductName();
                        break;
                    case 6:
                        MonthlyTotalSale();
                        break;
                    case 7:
                        MostSaleProduct();
                        break;
                    case 8:
                        TotalSale();
                        break;
                    default:
                        Console.WriteLine("Siz yalniz secim etdiniz.0-8 arasinda secim ede bilerszi");
                        break;
                        
                }
            }
            while (selectInt != 0);
             
            static void Salelist()
            {
                Console.WriteLine("---------Movcud satislar-------");
                var table = new ConsoleTable("No", "Kateqoriya", "Mehsul", "Tarix", "Sayi", "Qiymeti", "Toplam");
                int i = 1;
                foreach (var item in _reportingService.Sales)
                {
                    table.AddRow(i, item.CategoryName, item.ProductName, item.Date, item.Quantity, item.Amount, (item.Amount * item.Quantity).ToString("#.##"));
                }
                

            }

            static void AddSale()
            {
                Console.WriteLine("-------------- Yeni satış əlavə et --------------");
                Sale sale = new Sale();

                #region Category Name
                Console.WriteLine("Kateqoriya daxil edin :");
                sale.CategoryName = Console.ReadLine();
                #endregion

                #region Product Name
                Console.WriteLine("Məhsul adı daxil edin :");
                sale.ProductName = Console.ReadLine();
                #endregion

                #region Date
                Console.WriteLine("Satış tarixi daxil edin (gun.ay.il):");
                string dateInput = Console.ReadLine();
                DateTime date;

                while (!DateTime.TryParse(dateInput, out date))
                {
                    Console.WriteLine("Tarixi duzgun daxil etməlisiniz!");
                    dateInput = Console.ReadLine();
                }

                sale.Date = date;
                #endregion

                #region Amount
                Console.WriteLine("Satış məbləğini daxil edin:");
                string amountInput = Console.ReadLine();
                double amount;

                while (!double.TryParse(amountInput, out amount))
                {
                    Console.WriteLine("Rəqəm daxil etməlisiniz!");
                    amountInput = Console.ReadLine();
                }

                sale.Amount = amount;
                #endregion

                #region Quantity
                Console.WriteLine("Satış sayını daxil edin:");
                string quantityInput = Console.ReadLine();
                int quantity;

                while (!int.TryParse(quantityInput, out quantity))
                {
                    Console.WriteLine("Rəqəm daxil etməlisiniz!");
                    quantityInput = Console.ReadLine();
                }

                sale.Quantity = quantity;
                #endregion

                _reportingService.AddSale(sale);

                Console.WriteLine("-------------- Yeni satış əlavə edildi --------------");

            }

            static void DeleteSale()
            {
                Console.WriteLine("-------------- Satişi ləğv et --------------");

                Console.WriteLine("Ləğv etmək üçün no daxil edin:");
                string indexInput = Console.ReadLine();
                int index;

                while (!int.TryParse(indexInput, out index))
                {
                    Console.WriteLine("Rəqəm daxil etməlisiniz!");
                    indexInput = Console.ReadLine();
                } 

                try
                {
                    _reportingService.RemoveSaleByIndex(index - 1);
                    Console.WriteLine("-------------- Satış ləğv edildi --------------");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Bu no-da satış yoxdur");
                }
            }

            static void SaleByCategoryName()
            { 

                Console.WriteLine("----Kateqoriya adina gore satisi goster");
                Console.WriteLine("Kateqoriya adi daxil edin : ");
                string CategoryName = Console.ReadLine();

                int result = _reportingService.GetSaleCountByCategoryName(CategoryName);
                if (result!=0)
                {
                    Console.WriteLine("-----------{0} kateqoriysina gore satis {1}dir-------" ,CategoryName,result);
                }  
                else
                {
                    Console.WriteLine("{0}kateqoriyasina gore satis yoxdur" ,CategoryName);
                }


            }

            static void SaleByProductName()
            {
                Console.WriteLine("-------------- Məhsul adına görə satış toplamını --------------");

                Console.WriteLine("Məhsul adı daxil edin:");
                string productName = Console.ReadLine();

                double result = _reportingService.GetTotalSaleByProductName(productName);

                if (result != 0)
                {
                    Console.WriteLine("-------------- {0} məhsuluna görə satış toplamı {1} azndir --------------", productName, result.ToString("#.##"));
                }
                else
                {
                    Console.WriteLine("{0} məhsuluna görə satış yoxdur", productName);
                }

            }

            static void MonthlyTotalSale()
            {
                Console.WriteLine("-------------- Tarix aralığında satışların toplamını --------------");

                #region Start Date
                Console.WriteLine("Başlanğıc tarixi daxil edin (gun.ay.il):");
                string startDateInput = Console.ReadLine();
                DateTime startDate; 

                while (!DateTime.TryParse(startDateInput, out startDate))
                {
                    Console.WriteLine("Tarixi daxil etməlisiniz!");
                    startDateInput = Console.ReadLine();
                }

                #endregion;

                #region End Date
                Console.WriteLine("Bitiş tarixi daxil edin (gun.ay.il):");
                string endDateInput = Console.ReadLine();
                DateTime endDate;

                while (!DateTime.TryParse(endDateInput, out endDate))
                {
                    Console.WriteLine("Tarixi daxil etməlisiniz!");
                    endDateInput = Console.ReadLine();
                }

                #endregion

                double result = _reportingService.MonthlySaleTotal(startDate, endDate);

                if (result != 0)
                {
                    Console.WriteLine("-------------- {0} - {1} aralığına görə satış toplamı {2} azndir --------------", startDate.ToString("dd.MM.yyyy"), endDate.ToString("dd.MM.yyyy"), result.ToString("#.##"));
                }
                else
                {
                    Console.WriteLine("-------------- {0} - {1} aralığına görə satış yoxdur --------------", startDate.ToString("dd.MM.yyyy"), endDate.ToString("dd.MM.yyyy"));
                }

            }

            static void MostSaleProduct()
            {
                Console.WriteLine("-------------- Məhsul adına görə satış toplamını --------------");


                Console.WriteLine("Ən çox satışı olan məhsul {0}-dir", _reportingService.MostSaledProduct());
            }      

            static void TotalSale()
            {
                Console.WriteLine("-------------- Butun  satış toplamını --------------");

                Console.WriteLine("Pütün satışların toplamı : {0} azndir", _reportingService.SaleTotal().ToString("#.##"));

            }


        }
    }
}
