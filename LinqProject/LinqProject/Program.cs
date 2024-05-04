using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinqProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var liste = new int[] { 3, 5, 8, 13, 21, 42, 61, 70, 87, 91 };

            //LINQ sorgu sözdizimi
            var tekler =
                         from sayi in liste
                         where sayi % 2 == 1
                         select sayi;

            
            var liste2 = new int[] { 1, 3, 5, 8, 22, 58, 61 ,33, 44, 56, 101 };

            //LINQ metod sözdizim
            var tekler2 = liste2.Where(sayi => sayi % 2 == 1);



            //Sorgu sözdizimi sonuçlarının ekrana basılması
            foreach (var tekSayi in tekler)
            {
                Console.WriteLine(tekSayi);
            }

            foreach (var tekSayi in tekler2)
            {
                Console.WriteLine(tekSayi);
            }

            Console.ReadKey();





            //Veritabanından gelicek özellikler.
            List<Category> categories = new List<Category>
            {
                new Category{CategoryID=1, CategoryName="Bilgisayar" },
                new Category{CategoryID=2, CategoryName="Telefon" }
            };

            List<Product> products = new List<Product>
            {
                new Product{ProductID=1, CategoryId=1,ProductName="Acer Laptop",QuantityPerUnit="32 GB Ram",UnitPrice=10000,UnitsInStock=5},
                new Product{ProductID=2, CategoryId=1,ProductName="Asus Laptop",QuantityPerUnit="16 GB Ram",UnitPrice=8000,UnitsInStock=3},
                new Product{ProductID=3, CategoryId=1,ProductName="Hp Laptop",QuantityPerUnit="8 GB Ram",UnitPrice=6000,UnitsInStock=2},
                new Product{ProductID=4, CategoryId=2,ProductName="Samsung Telefon",QuantityPerUnit="4 GB Ram",UnitPrice=5000,UnitsInStock=15},
                new Product{ProductID=5, CategoryId=2,ProductName="Apple Telefon",QuantityPerUnit="4 GB Ram",UnitPrice=8000,UnitsInStock=0},

            };

            Console.WriteLine("Algoritmik----------------");

            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                {
                    Console.WriteLine(product.ProductName);
                }

            }

            Console.WriteLine("Linq----------------");

            var result = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3);

            foreach(var product in result)
            {
                Console.WriteLine(product.ProductName);
            }

            GetProducts(products);
        }
         
        // Linq yoksa eğer bu yazılır.
        static List<Product> GetProducts(List<Product> products)
        {
            List<Product> filteredProduct = new List<Product>(); // filtrelenmiş ürünler
            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                {
                    filteredProduct.Add(product);
                }

            }
            return filteredProduct;
        }

        static List<Product> GetProductsLinq(List<Product> products)
        {
           return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList();
            // where => arka planda yeni nesne oluşturuyor şartlara uyuyor mu diye kontrol ediyor ve liste oluşturuyor ve return ediyoruz.
        }

        
    }

    class Product
    {
        public int ProductID { get; set; }
        public int CategoryId { get; set; } 
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

    }

    class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
