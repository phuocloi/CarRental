namespace CarRentalWebService.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using CarRentalWebService.Models;
    using System.Collections.Generic;

    public class DbContextModel : DbContext
    {
        // Your context has been configured to use a 'DbContextModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CarRentalWebService.Models.DbContextModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbContextModel' 
        // connection string in the application configuration file.
        public DbContextModel()
            : base("name=DbContextModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<CarBrand> CarBrands { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<CarFeature> CarFeatures { get; set; }

        public virtual DbSet<CarModel> CarModels { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Request> Requests { get; set; }
    }

    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DbContextModel>
    {
        protected override void Seed(DbContextModel context)
        {
            var Brands = new List<CarBrand>
            {
                new CarBrand{Name = "Toyota"},
                new CarBrand{Name = "Suzuki"},
                new CarBrand{Name = "Honda"},
                new CarBrand{Name = "HuynDai"}
            };
            Brands.ForEach(b => context.CarBrands.Add(b));
            context.SaveChanges();

            var Cities = new List<City>
            {
                new City{Name = "Hồ Chí Minh", ZipCode = 700000},
                new City{Name = "Hà Nội", ZipCode = 100000},
                new City{Name = "Bà Rịa Vũng Tàu", ZipCode = 790000},
                new City{Name = "Bạc Liêu", ZipCode = 260000},
                new City{Name = "Bến Tre", ZipCode = 930000},
                new City{Name = "Bình Dương", ZipCode = 590000},
                new City{Name = "Cần Thơ", ZipCode = 270000},
                new City{Name = "Đà Nẵng", ZipCode = 550000},
                new City{Name = "Khánh Hoà", ZipCode = 650000},
                new City{Name = "Long An", ZipCode = 850000},
                new City{Name = "Nghệ An", ZipCode = 470000},
                new City{Name = "Thừa Thiên Huế", ZipCode = 530000},
                new City{Name = "Vĩnh Long", ZipCode = 890000}
            };
            Cities.ForEach(c => context.Cities.Add(c));
            context.SaveChanges();

            var Models = new List<CarModel>
            {
                new CarModel{Name = "Prius", Aircondition = true, AutoTransmission = true, Seats = 4, Doors = 4, LargeBags = 1, SmallBags = 1,
                    PricePerDay = 150, PricePerHour = 15, Brand_Id = 1, Quantity = 10,},
                new CarModel{Name = "Tacoma", Aircondition = true, AutoTransmission = true, Seats = 4, Doors = 4,  LargeBags = 1, SmallBags = 1,
                    PricePerDay = 170, PricePerHour = 17, Brand_Id = 1, Quantity = 10,},
                new CarModel{Name = "Corolla", Aircondition = true, AutoTransmission = true, Seats = 4, Doors = 4,  LargeBags = 1, SmallBags = 1,
                    PricePerDay = 200, PricePerHour = 20, Brand_Id = 1, Quantity = 10,},
                new CarModel{Name = "Yaris", Aircondition = true, AutoTransmission = true, Seats = 4, Doors = 4,  LargeBags = 1, SmallBags = 1,
                    PricePerDay = 140, PricePerHour = 14, Brand_Id = 1, Quantity = 10,},
                new CarModel{Name = "Camry", Aircondition = true, AutoTransmission = true, Seats = 4, Doors = 4,  LargeBags = 1, SmallBags = 1,
                    PricePerDay = 210, PricePerHour = 21, Brand_Id = 1, Quantity = 10,},
                new CarModel{Name = "RAV4", Aircondition = true, AutoTransmission = true, Seats = 4, Doors = 4,  LargeBags = 1, SmallBags = 1,
                    PricePerDay = 140, PricePerHour = 14, Brand_Id = 1, Quantity = 10,},
                new CarModel{Name = "Venza", Aircondition = true, AutoTransmission = true, Seats = 4, Doors = 4,  LargeBags = 1, SmallBags = 1,
                    PricePerDay = 300, PricePerHour = 30, Brand_Id = 1, Quantity = 10,},
                new CarModel{Name = "Accord", Aircondition = true, AutoTransmission = true, Seats = 4, Doors = 4,  LargeBags = 1, SmallBags = 1,
                    PricePerDay = 140, PricePerHour = 14, Brand_Id = 3, Quantity = 10,},
                new CarModel{Name = "Civic", Aircondition = true, AutoTransmission = true, Seats = 4, Doors = 4,  LargeBags = 1, SmallBags = 1,
                    PricePerDay = 300, PricePerHour = 30, Brand_Id = 3, Quantity = 10,},
                new CarModel{Name = "Crosstour", Aircondition = true, AutoTransmission = true, Seats = 4, Doors = 4,  LargeBags = 1, SmallBags = 1,
                    PricePerDay = 200, PricePerHour = 20, Brand_Id = 3, Quantity = 10,},
                new CarModel{Name = "CR-V", Aircondition = true, AutoTransmission = true, Seats = 4, Doors = 4,  LargeBags = 1, SmallBags = 1,
                    PricePerDay = 170, PricePerHour = 17, Brand_Id = 3, Quantity = 10,},
                new CarModel{Name = "Fit", Aircondition = true, AutoTransmission = true, Seats = 4, Doors = 4,  LargeBags = 1, SmallBags = 1,
                    PricePerDay = 140, PricePerHour = 14, Brand_Id = 3, Quantity = 10,},
            };
            Models.ForEach(m => context.CarModels.Add(m));
            context.SaveChanges();

            var Features = new List<CarFeature>
            {
                new CarFeature{Name = "Theft Protection"},
                new CarFeature{Name = "Amendments"},
                new CarFeature{Name = "Collision Damage Waiver"}
            };
            Features.ForEach(f => context.CarFeatures.Add(f));
            context.SaveChanges();

            var Requests = new List<Request>
            {
                new Request{Name="Henry", Phone="0988889999", FromDate=Convert.ToDateTime("11/11/2014 12:00:00"), ToDate= Convert.ToDateTime("12/11/2014 12:00:00"), Email="phuocloi@gmail.com", Model_Id=8, City_Id=2, PriceTotal=200,},
                new Request{Name="Ho Phuoc Loi", Phone="01694463475", FromDate=Convert.ToDateTime("12/11/2014 9:00:00"), ToDate= Convert.ToDateTime("13/11/2014 9:00:00"), Email="phuoc.loi@gmail.com", Model_Id=7, City_Id=1, PriceTotal=400,},
                new Request{Name="Vo Hoang Dang Khoa", Phone="0987656789", FromDate=Convert.ToDateTime("11/11/2014 7:00:00"), ToDate= Convert.ToDateTime("11/11/2014 17:00:00"), Email="phuocloiit@gmail.com", Model_Id=9, City_Id=3, PriceTotal=250,},
                new Request{Name="Nguyen Hoang Nam", Phone="01694463510", FromDate=Convert.ToDateTime("10/11/2014 12:00:00"), ToDate= Convert.ToDateTime("11/11/2014 12:00:00"), Email="phuocloi.it@gmail.com", Model_Id=7, City_Id=1, PriceTotal=150,},
                new Request{Name="Tim", Phone="0909090909", FromDate=Convert.ToDateTime("11/11/2014 8:00:00"), ToDate= Convert.ToDateTime("13/11/2014 18:00:00"), Email="phuoc.loi.it@gmail.com", Model_Id=6, City_Id=2, PriceTotal=300,}
            };
            Requests.ForEach(g => context.Requests.Add(g));
            context.SaveChanges();

            var Reviews = new List<Review>
            {
                new Review{Model_Id=8, Content="Good!", Stars=4, email="phuocloi@gmail.com",},
                new Review{Model_Id=7, Content="Great!", Stars=3, email="phuoc.loi@gmail.com",},
                new Review{Model_Id=9, Content="Excelent!", Stars=5, email="phuocloiit@gmail.com",},
                new Review{Model_Id=7, Content="Cool!", Stars=4, email="phuocloi.it@gmail.com",},
                new Review{Model_Id=6, Content="Cool!", Stars=4, email="phuoc.loi.it@gmail.com",}
            };
            Reviews.ForEach(h => context.Reviews.Add(h));
            context.SaveChanges();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}