using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechTestNetApp.Data;

namespace TechTestNetApp.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>());
            {
                // Look for any movies.
                if (context.Address.Any())
                {
                    return;   // DB has been seeded
                }
            context.Address.AddRange(
                new Address() {Id = 1, houseNumber = 23, street = "Strandvejen", town = "Humlebæk", zipCode = 3050, country = "Denmark"},
                new Address() {Id = 2, houseNumber = 42, street = "Kirkeskov Alle", town = "Kokkedal", zipCode = 3060, country = "Denmark"},
                new Address() {Id = 3, houseNumber = 25, street = "Strandvejen", town = "Humlebæk", zipCode = 3050, country = "Denmark"},
                new Address() {Id = 4, houseNumber = 53, street = "Kildestien", town = "Espergærde", zipCode = 3060, country = "Denmark"},
                new Address() {Id = 5, houseNumber = 123, street = "Askevænget", town = "Lyngby", zipCode = 4000, country = "Denmark"},
                new Address() {Id = 6, houseNumber = 51, street = "Danmarksvej", town = "Kolding", zipCode = 6000, country = "Denmark"},
                new Address() {Id = 7, houseNumber = 19, street = "Humlevej", town = "Helsingør", zipCode = 3050, country = "Denmark"},
            new Address() {Id = 8, houseNumber = 22, street = "Strandvejen", town = "Humlebæk", zipCode = 3050, country = "Denmark"},
            new Address() {Id = 9, houseNumber = 4, street = "Kirkeskov Alle", town = "Kokkedal", zipCode = 3060, country = "Denmark"},
            new Address() {Id = 10, houseNumber = 51, street = "Strandvejen", town = "Humlebæk", zipCode = 3050, country = "Denmark"},
            new Address() {Id = 11, houseNumber = 25, street = "Kildestien", town = "Espergærde", zipCode = 3060, country = "Denmark"},
            new Address() {Id = 12, houseNumber = 167, street = "Askevænget", town = "Lyngby", zipCode = 4000, country = "Denmark"},
            new Address() {Id = 13, houseNumber = 12, street = "Danmarksvej", town = "Kolding", zipCode = 6000, country = "Denmark"},
            new Address() {Id = 14, houseNumber = 7, street = "Humlevej", town = "Helsingør", zipCode = 3050, country = "Denmark"}
            );
            context.SaveChanges();
            context.Car.AddRange(
                new Car() {Id = 1, color = "Green", make = "Volvo", model = "V6", extras = "Automat Gear", recommendPrice = 500000},
                new Car() {Id = 2, color = "Purple", make = "Mercedes", model = "S", extras = "Automat Gear", recommendPrice = 43000},
                new Car() {Id = 3, color = "Blue", make = "Opel", model = "Astra", extras = "Automat Gear", recommendPrice = 9000},
                new Car() {Id = 4, color = "White", make = "Fiat", model = "Punto", extras = "Automat Gear", recommendPrice = 32000},
                new Car() {Id = 5, color = "Yellow", make = "Volks Wagen", model = "Golf", extras = "Automat Gear", recommendPrice = 16000},
                new Car() {Id = 6, color = "Black", make = "Skoda", model = "Citigo", extras = "N/A", recommendPrice = 28000},
            new Car() {Id = 7, color = "Green", make = "Volvo", model = "V12", extras = "Automat Gear", recommendPrice = 500000},
            new Car() {Id = 8, color = "Purple", make = "Mercedes", model = "S20", extras = "Automat Gear", recommendPrice = 43000},
            new Car() {Id = 9, color = "Blue", make = "Opel", model = "Corsa", extras = "Automat Gear", recommendPrice = 9000},
            new Car() {Id = 10, color = "White", make = "Fiat", model = "500", extras = "Automat Gear", recommendPrice = 32000},
            new Car() {Id = 11, color = "Yellow", make = "Volks Wagen", model = "Golf", extras = "Automat Gear", recommendPrice = 16000},
            new Car() {Id = 12, color = "Black", make = "Skoda", model = "Citigo", extras = "N/A", recommendPrice = 28000},
            new Car() {Id = 13, color = "Black", make = "Volvo", model = "V6", extras = "Automat Gear", recommendPrice = 500000},
            new Car() {Id = 14, color = "Black", make = "Mercedes", model = "S", extras = "Automat Gear", recommendPrice = 43000},
            new Car() {Id = 15, color = "Purple", make = "Opel", model = "Astra", extras = "Automat Gear", recommendPrice = 9000},
            new Car() {Id = 16, color = "Purple", make = "Fiat", model = "Punto", extras = "Automat Gear", recommendPrice = 32000},
            new Car() {Id = 17, color = "Black", make = "Volks Wagen", model = "Golf", extras = "Automat Gear", recommendPrice = 16000},
            new Car() {Id = 18, color = "Yellow", make = "Skoda", model = "Citigo", extras = "N/A", recommendPrice = 28000},
            new Car() {Id = 19, color = "Green", make = "Volvo", model = "V12", extras = "Automat Gear", recommendPrice = 500000},
            new Car() {Id = 20, color = "White", make = "Mercedes", model = "S20", extras = "Automat Gear", recommendPrice = 43000},
            new Car() {Id = 21, color = "White", make = "Opel", model = "Corsa", extras = "Automat Gear", recommendPrice = 9000},
            new Car() {Id = 22, color = "Purple", make = "Fiat", model = "500", extras = "Automat Gear", recommendPrice = 32000},
            new Car() {Id = 23, color = "Purple", make = "Volks Wagen", model = "Golf", extras = "Automat Gear", recommendPrice = 16000},
            new Car() {Id = 24, color = "White", make = "Skoda", model = "Citigo", extras = "N/A", recommendPrice = 28000}
            );
            context.SaveChanges();
            context.Customer.AddRange(
                new Customer() {Id = 1, name = "Anders", surname = "Andersen",addressID = 1, age = 27, created = DateTime.Now},
                new Customer() {Id = 2, name = "Bjarne", surname = "Sørensen",addressID = 2, age = 27, created = DateTime.Now},
                new Customer() {Id = 3, name = "Mads", surname = "Larsen",addressID = 3, age = 27, created = DateTime.Now},
                new Customer() {Id = 4, name = "Knud", surname = "Knudsen",addressID = 2, age = 27, created = DateTime.Now},
                new Customer() {Id = 5, name = "Børge", surname = "Andersen",addressID = 4, age = 27, created = DateTime.Now},
                new Customer() {Id = 6, name = "Anders", surname = "Christiansen",addressID = 5, age = 27, created = DateTime.Now},
                new Customer() {Id = 7, name = "Børge", surname = "Jørgensen",addressID = 6, age = 27, created = DateTime.Now},
                new Customer() {Id = 8, name = "Mads", surname = "Christiansen",addressID = 10, age = 27, created = DateTime.Now},
                new Customer() {Id = 9, name = "Børge", surname = "Jørgensen",addressID = 12, age = 27, created = DateTime.Now},
                new Customer() {Id = 10, name = "Mads", surname = "Sørensen",addressID = 13, age = 27, created = DateTime.Now}
            );
            context.SaveChanges();
            context.SalesPerson.AddRange(
                new SalesPerson(){Id = 1, name = "Bjarne", jobTitle = "Salesman", addressID = 2, salary = 21000},
                new SalesPerson(){Id = 2, name = "Arne", jobTitle = "Sales Boss", addressID = 4, salary = 40000},
                new SalesPerson(){Id = 3, name = "Søren", jobTitle = "Salesman", addressID = 5, salary = 22000},
                new SalesPerson(){Id = 4, name = "Klaus", jobTitle = "Salesman", addressID = 3, salary = 24000},
                new SalesPerson(){Id = 5, name = "Frederik", jobTitle = "Sales intern", addressID = 6, salary = 10000},
                new SalesPerson(){Id = 6, name = "Susan", jobTitle = "Salesman", addressID = 1, salary = 53000},
                new SalesPerson(){Id = 7, name = "Arne", jobTitle = "Sales Boss", addressID = 4, salary = 40000},
                new SalesPerson(){Id = 8, name = "Søren", jobTitle = "Salesman", addressID = 5, salary = 22000},
                new SalesPerson(){Id = 9, name = "Klaus", jobTitle = "Salesman", addressID = 3, salary = 24000},
                new SalesPerson(){Id = 10, name = "Frederik", jobTitle = "Sales intern", addressID = 8, salary = 10000},
                new SalesPerson(){Id = 11, name = "Susan", jobTitle = "Salesman", addressID = 7, salary = 53000}
            );
            context.SaveChanges();
            context.CarPurchase.AddRange(
                new CarPurchase(){ID = 1, carID = 1, customerID = 1, orderDate = DateTime.Today, pricePaid = 20000, salesPersonID = 1},
                new CarPurchase(){ID = 2, carID = 2, customerID = 2, orderDate = DateTime.Today, pricePaid = 20000, salesPersonID = 2},
                new CarPurchase(){ID = 3, carID = 3, customerID = 3, orderDate = DateTime.Today, pricePaid = 20000, salesPersonID = 3},
                new CarPurchase(){ID = 4, carID = 4, customerID = 4, orderDate = DateTime.Today, pricePaid = 20000, salesPersonID = 4},
                new CarPurchase(){ID = 5, carID = 5, customerID = 5, orderDate = DateTime.Today, pricePaid = 20000, salesPersonID = 5},
                new CarPurchase(){ID = 6, carID = 10, customerID = 10, orderDate = DateTime.Today, pricePaid = 20000, salesPersonID = 1},
                new CarPurchase(){ID = 7, carID = 9, customerID = 9, orderDate = DateTime.Today, pricePaid = 20000, salesPersonID = 2},
                new CarPurchase(){ID = 8, carID = 8, customerID = 8, orderDate = DateTime.Today, pricePaid = 20000, salesPersonID = 7},
                new CarPurchase(){ID = 9, carID = 7, customerID = 7, orderDate = DateTime.Today, pricePaid = 20000, salesPersonID = 7},
                new CarPurchase(){ID = 10, carID = 6, customerID = 6, orderDate = DateTime.Today, pricePaid = 20000, salesPersonID = 7}
            );
            context.SaveChanges();
            Console.Write("IT FINISHED");
            }
        }
    }
}
