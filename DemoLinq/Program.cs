using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoLinq
{
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // cá màu
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng

        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }

        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";
    }

    public class Brand
    {
        public string Name { set; get; }
        public int? ID { set; get; }

    }

    public class Program
    {
        private static void Main(string[] args)
        {
            var brands = new List<Brand>() {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"},
            };
            var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               4),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng","Đen", "Vàng"},               3),
                new Product(0, "Tủ áo",      600, new string[] {"Trắng","Đen", "Vàng"},               4),
            };

            // truy vấn điều kiện cơ bản
            var query = from p in products
                        where (p.Price == 400 || p.Price == 600 )
                        select p;

            // truy vấn tập hợp con 
            //var query = products.SelectMany(
            //    p =>
            //    {
            //        return p.Colors;
            //    }
            //    );


            //left join
            //var query = from p in products
            //            join b in brands on p.Brand equals b.ID into gj
            //            from subpet in gj.DefaultIfEmpty(new Brand())
            //            select new
            //            {
            //                BRAND_ID = subpet.ID,
            //                ID = p.ID,
            //                NAME = p.Name,
            //                PRICE = p.Price,
            //                BRAND_NAME = subpet.Name
            //            };

            //in
            //List<int> arr = new List<int>();
            //arr.Add(1);
            //arr.Add(2);
            //var query = from p in products
            //            select p;
            //query = query.Where(x => arr.Contains(x.Brand));

            // group by
            //var query = products.GroupBy(x => new { x.Brand,x.ID});
            //var query = products.GroupBy(x =>  x.Brand);
            //var query = from p in products
            //            group p by new {
            //                p.Price,
            //                p.ID
            //            };

            //var query = from p in products
            //            group p by p.Price;

            // order by
            //var query = from p in products
            //            orderby p.Price, p.Brand,p.ID
            //            select p;
            //var query = products.OrderBy(x => x.Price).ThenBy(x => x.Brand).ThenBy(x=>x.ID);

            foreach (var item in query)
            {
                Console.WriteLine(item);
                //foreach (var item2 in item)
                //{
                //    Console.WriteLine(item2);

                //}

            }
            Console.ReadKey();
        }
    }
}