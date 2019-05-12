using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using App.Entities;
using Dapper;

namespace App.Data
{
    public class InvoiceDA:BaseConnection
    {
        public int InserTXLocalInvoice(Invoice invoice)
        {
            var result = 0;
            using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
            {
                cn.Open();
                var trx = cn.BeginTransaction();

                try
                {
                    var invoiceId=cn.ExecuteScalar<int>("usp_InsertInvoice",
                        new
                        {
                            CustomerId = invoice.CustomerId,
                            InvoiceDate = invoice.InvoiceDate,
                            BillingAddress = invoice.BillingAddress,
                            BillingCity = invoice.BillingCity,
                            BillingState = invoice.BillingState,
                            BillingCountry = invoice.BillingCountry,
                            BillingPostalCode = invoice.BillingPostalCode,
                            Total = invoice.Total
                        },commandType:CommandType.StoredProcedure, transaction: trx);


                    foreach (var item in invoice.InvoiceLine)
                    {
                        cn.Execute("usp_InsertInvoiceLine",
                            new
                            {
                                InvoiceId = invoiceId,
                                TrackId = item.TrackId,
                                UnitPrice = item.UnitPrice,
                                Quantity=item.Quantity
                            }, commandType: CommandType.StoredProcedure, transaction: trx);

                        //Error a proposito
                        //throw new Exception("Error");
                    }

                    trx.Commit();

                    result = invoiceId;    
                }
                catch (Exception)
                {
                    result = 0;
                    trx.Rollback();
                }
            }


            return result;

        }


        public int InserTXDistInvoice(Invoice invoice)
        {
            var result = 0;

            using (var trx= new TransactionScope())
            {
                try
                {
                    using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
                    {

                        var invoiceId = cn.ExecuteScalar<int>("usp_InsertInvoice",
                            new
                            {
                                CustomerId = invoice.CustomerId,
                                InvoiceDate = invoice.InvoiceDate,
                                BillingAddress = invoice.BillingAddress,
                                BillingCity = invoice.BillingCity,
                                BillingState = invoice.BillingState,
                                BillingCountry = invoice.BillingCountry,
                                BillingPostalCode = invoice.BillingPostalCode,
                                Total = invoice.Total
                            }, commandType: CommandType.StoredProcedure);


                        foreach (var item in invoice.InvoiceLine)
                        {
                            cn.Execute("usp_InsertInvoiceLine",
                                new
                                {
                                    InvoiceId = invoiceId,
                                    TrackId = item.TrackId,
                                    UnitPrice = item.UnitPrice,
                                    Quantity = item.Quantity
                                }, commandType: CommandType.StoredProcedure);

                        }
                        result = invoiceId;

                    }
                    trx.Complete();
                }
                catch (Exception ex)
                {
                    result = 0;
                }
            }
            return result;
        }
    }
}
