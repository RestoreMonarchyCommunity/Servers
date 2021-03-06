﻿using Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Server.Utilities.Database
{
    public static class DatabaseSalesExtension
    {
        public static bool HasBeenProcessed(this DatabaseManager database, string transactionId)
        {
            string sql = "SELECT COUNT(0) FROM dbo.Sales WHERE TransactionId = @transactionId;";

            using (var conn = database.connection)
            {
                return conn.ExecuteScalar<bool>(sql, new { transactionId });
            }
        }

        public static int CreateSale(this DatabaseManager database, Sale sale)
        {
            string sql = "INSERT INTO dbo.Sales (PlayerId, ProductId, Price, Currency) OUTPUT INSERTED.SaleId VALUES (@PlayerId, @ProductId, @Price, @Currency);";
            
            using (var conn = database.connection)
            {
                return conn.ExecuteScalar<int>(sql, sale);
            }
        }

        public static Sale GetSale(this DatabaseManager database, int saleId)
        {
            string sql = "SELECT s.*, p.*, r.*, p2.* FROM dbo.Sales s JOIN dbo.Products p ON s.ProductId = p.ProductId LEFT JOIN dbo.Ranks r ON p.RankId = r.RankId JOIN dbo.Players p2 ON s.PlayerId = p2.PlayerId WHERE s.saleId = @saleId;";

            using (var conn = database.connection)
            {
                return conn.Query<Sale, Product, Rank, Player, Sale>(sql, (s, p, r, p2) => 
                {
                    s.Product = p;
                    s.Product.Rank = r;
                    s.Player = p2;

                    return s;
                }, new { saleId }, splitOn: "ProductId,RankId,PlayerId").FirstOrDefault();
            }
        }

        public static void UpdateSale(this DatabaseManager database, Sale sale)
        {
            string sql = "UPDATE dbo.Sales SET PaymentType = @PaymentType, PaymentStatus = @PaymentStatus, PayerEmail = @PayerEmail, TransactionId = @TransactionId, " +
                "TransactionType = @TransactionType WHERE SaleId = @SaleId;";

            using (var conn = database.connection)
            {
                conn.Execute(sql, sale);
            }
        }
    }
}
