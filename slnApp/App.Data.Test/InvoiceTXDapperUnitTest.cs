using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Data;
using App.Entities;
using System.Collections.Generic;

namespace App.Data.Test
{
    [TestClass]
    public class InvoiceTXDapperUnitTest
    {
        [TestMethod]
        public void InsertTXLocalInvoice()
        {
            var invoiceDA = new InvoiceDA();
            var invoice = new Invoice();

            invoice.CustomerId = 61;
            invoice.BillingCountry = "Brasil";
            invoice.BillingAddress = "Av Brasil 123";
            invoice.BillingCity = "Brasilia";
            invoice.BillingPostalCode = "BR 32";
            invoice.BillingState = "Brasilia";
            invoice.InvoiceDate = DateTime.Now;
            invoice.Total = 300;

            //Agrregando el detalle

            invoice.InvoiceLine = new List<InvoiceLine>();
            invoice.InvoiceLine.Add(
                new InvoiceLine() {
                    TrackId = 1,
                    Quantity = 4,
                    UnitPrice = 50,
                });

            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 2,
                    Quantity = 5,
                    UnitPrice = 50,
                });

            var id=invoiceDA.InserTXLocalInvoice(invoice);
            Assert.IsTrue(id>0);
        }




        [TestMethod]
        public void InsertTXDistInvoice()
        {
            var invoiceDA = new InvoiceDA();
            var invoice = new Invoice();

            invoice.CustomerId = 61;
            invoice.BillingCountry = "Uruguay";
            invoice.BillingAddress = "Av Uruguay 123";
            invoice.BillingCity = "Uruguay";
            invoice.BillingPostalCode = "BR 32";
            invoice.BillingState = "Uruguay";
            invoice.InvoiceDate = DateTime.Now;
            invoice.Total = 300;

            //Agrregando el detalle

            invoice.InvoiceLine = new List<InvoiceLine>();
            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 1,
                    Quantity = 20,
                    UnitPrice = 150,
                });

            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 2,
                    Quantity = 25,
                    UnitPrice = 250,
                });

            var id = invoiceDA.InserTXDistInvoice(invoice);
            Assert.IsTrue(id > 0);
        }
    }
}
