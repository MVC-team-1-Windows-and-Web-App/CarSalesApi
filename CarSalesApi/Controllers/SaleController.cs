﻿using CarApiClasses;
using CarSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarSalesApi.Controllers
{
    public class SaleController : ApiController
    {

        CarSalesDBEntities2 db = new CarSalesDBEntities2();

        [HttpGet]
        [Route("SaleController/Sale")]
        //GET ALL THE SALES - Ariane
        public HttpResponseMessage GetSales()
        {
            HttpResponseMessage response;
            var sales = DBAccess.GetSales();
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

        [HttpGet]
        [Route("SaleController/Sale/id")]
        // GET SPECIFIC SALE WITH ID - Hicham
        public HttpResponseMessage GetSale(int id)
        {
            HttpResponseMessage response;
            var sale = DBAccess.GetSale(id);

            if (sale == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No sales were found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, sale);
            }

            return response;
        }
        public HttpResponseMessage Delete(int id)
        {
            Sale c = db.Sales.Find(id);

            if (c == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }

            db.Sales.Remove(c);

            try
            {
                // Persist our change.
                db.SaveChanges();
            }
            catch (Exception e)
            {
                // ERROR
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "An error occured, Cannot delete current record !");
            }

            // All OK
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/Sale")]
        public HttpResponseMessage PostLocation([FromBody]ApiSale sa)
        {
            try
            {
                DBAccess.PostSale(sa);
            }
            catch (Exception e)
            {
                // ERROR
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot create record.");
            }

            // All OK
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}