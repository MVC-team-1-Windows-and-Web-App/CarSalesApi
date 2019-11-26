﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarApiClasses;

namespace CarSalesApi.Models
{
    public class DBAccess
    {

        private CarSalesDBEntities db = new CarSalesDBEntities();

        //Brendan demo
        /*public List<ApiCar> GetCars()
        {
            // Get from EF
            var cars = db.Cars.ToList();
            // convert to api list see my git example
            //return cars;
            List < ApiCar > newCarList = cars.Select(x => new ApiCar() { CarId = x.CarId }).ToList();
            return newCarList;
        }*/

    //Get all
        public HttpResponseMessage GetAllCars()
        {
            HttpResponseMessage response;
            var cars = db.Cars.ToList();
            List<ApiCar> cars = cars.Select(c => new ApiCar()
            {
                Id = c.CarId,
                Color = c.CarColor,
                Type = c.CarType,
                Model = c.CarModel,
                Price = c.CarPrice,
                Commission = c.CarCommission
            }).ToList<ApiCar>();

            if (cars.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, cars);
            }

            return response;
        }


        public HttpResponseMessage GetAllLocations()
        {
            HttpResponseMessage response;
            var locations = db.Location.ToList();
            List<ApiLocation> locations = locations.Select(c => new ApiLocation()
            {
                LocId = c.LocationId,
                LocStateProv = c.LocationStateProv,
                LocAddress = c.LocationAddress
            }).ToList<ApiLocation>();

            if (locations.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, locations);
            }

            return response;
        }


        public HttpResponseMessage GetAllSalespersons()
        {
            HttpResponseMessage response;
            var salespersons = db.Salesperson.ToList();
            List<ApiSalesperson> salespersons = salespersons.Select(c => new ApiSalesperson()
            {
                Id = c.SalespersonId,
                FirstName = c.SalespersonFirstName,
                LastName = c.SalespersonLastName,
                Address = c.SalespersonAddress,
                PhoneNumber = c.SalespersonPhoneNumber,
                LocationId = c.LocationId,
            }).ToList<ApiSalesperson>();

            if (salepersons.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, salespersons);
            }

            return response;
        }

        public HttpResponseMessage GetAllSales()
        {
            HttpResponseMessage response;
            var sales = db.Sale.ToList();
            List<ApiSale> sales = sales.Select(c => new ApiSale()
            {
                Id = c.SaleId,
                CustomerId = c.CustomerId,
                CarId = c.CarId,
                SalespersonId = c.SalespersonId,
                Date = c.SaleDate,
                Total = c.SaleTotal,
                Quantity = c.SaleQuantity,
            }).ToList<ApiSale>();

            if (sales.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, sales);
            }

            return response;
        }


        public HttpResponseMessage GetAllCustomers()
        {
            HttpResponseMessage response;
            var customers = db.Customer.ToList();
            List<ApiCustomer> customers = customers.Select(c => new ApiCustomer()
            {
                Id = c.CustomerId,
                FirstName = c.CustomerFirstName,
                LastName = c.CustomerLastName,
                PhoneId = c.CustomerPhoneId,
                Address = c.CustomerAddress,
                Dob = c.CustomerDob
            }).ToList<ApiCustomer>();

            if (customers.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, customers);
            }

            return response;
        }


        public HttpResponseMessage GetAllCustomerPhones()
        {
            HttpResponseMessage response;
            var customerphones = db.CustomerPhone.ToList();
            List<ApiCustomerPhone> customerphones = customerphones.Select(c => new ApiCustomerPhone()
            {
                CustomerPhoneId = c.CustomerPhoneId,
                CustomerId = c.CustomerId,
                PhoneId = c.PhoneId,
                Type = c.CustomerPhoneType,
            }).ToList<ApiCustomerPhone>();

            if (customerphones.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, customerphones);
            }

            return response;
        }


        public HttpResponseMessage GetAllPhones()
        {
            HttpResponseMessage response;
            var phones = db.Phone.ToList();
            List<ApiPhone> phones = phones.Select(c => new ApiPhone()
            {
                PhoneId = c.PhoneId,
                PhoneNumber = c.PhoneNumber,
            }).ToList<ApiPhone>();

            if (phones.Count == 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No cars were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, phones);
            }

            return response;
        }





    }
}