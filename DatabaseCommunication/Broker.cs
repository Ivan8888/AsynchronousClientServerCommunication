using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Domen;
using System.Threading;


namespace DatabaseCommunication
{
    public class Broker
    {

       string connectionString = "Data Source=(local);Initial Catalog=Product;Integrated Security=SSPI;";


       public void insertProductOrder(ProductOrder pOrder)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                //I don't need isolation level here
                SqlTransaction transaction = connection.BeginTransaction();

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "INSERT INTO ProductOrder(Simbol, Quantity, Price) VALUES('" + pOrder.Simbol + "' , " + pOrder.Quantity + " , " + pOrder.Price + ")";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw (ex);
                }
            }
        }
   

       public void InsertOrUpdateProductInfo(ProductInfo pInfo)
       {
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               connection.Open();
               SqlCommand command = connection.CreateCommand();
               //isolation level to desable other threads to insert or update ProductInfo with this simbol while transaction is not finished
               SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable);

               command.Connection = connection;
               command.Transaction = transaction;
               SqlDataReader reader = null;
               
               try
               {
                   //if there is product with the same simbol, than update ProductInfo, else insert ProductInfo in database.
                   command.CommandText = "SELECT * FROM ProductInfo WHERE Simbol = '" + pInfo.Simbol + "'";
                   reader = command.ExecuteReader();
                   if (reader.Read())
                   {
                       //there is the ProductInfo with the same simbol, update the product
                       reader.Close();
                       command.CommandText = "UPDATE ProductInfo SET Name = '" + pInfo.FullName + "' , Currency = '" + pInfo.Currency + "' WHERE Simbol = '" + pInfo.Simbol + "'";
                       command.ExecuteNonQuery();
                       transaction.Commit();
                   }
                   else
                   {
                       //there is not product with the same simbol, just insert the product
                       reader.Close();
                       command.CommandText = "INSERT INTO ProductInfo VALUES('" + pInfo.FullName + "' , '" + pInfo.Simbol + "' , '" + pInfo.Currency + "')";
                       command.ExecuteNonQuery();
                       transaction.Commit();
                   }
               }
               catch (Exception ex)
               {
                   reader.Close();
                   transaction.Rollback();
                   throw (ex);
         
               }
           }
       }

        //get all ProductInfo from the database
       public List<ProductInfo> getAllProductInfo()
       {
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               List<ProductInfo> productInfoList = new List<ProductInfo>();
               connection.Open();
               SqlCommand command = connection.CreateCommand();
               //isolation level: another thread can insert new ProductInfo but can not update while transaction isn't finished.
               SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);

               command.Connection = connection;
               command.Transaction = transaction;
               SqlDataReader reader = null;

               try
               {
                   command.CommandText = "SELECT * FROM ProductInfo";
                   reader = command.ExecuteReader();
                   while (reader.Read())
                   {
                       ProductInfo pInfo = new ProductInfo();
                       pInfo.FullName = reader.GetString(0);
                       pInfo.Simbol = reader.GetString(1);
                       pInfo.Currency = reader.GetString(2);
                       productInfoList.Add(pInfo);
                   }
                   reader.Close();
                   transaction.Commit();
                   return productInfoList;
               }

               catch (Exception ex)
               {
                   reader.Close();
                   transaction.Rollback();
                   throw (ex);
               }

           }
       }

        //geting last 50 orders of the chosen Product
       public List<ProductOrder> getLastProductOrders(string simbol)
       {
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               List<ProductOrder> productOrderList = new List<ProductOrder>();
               connection.Open();
               SqlCommand command = connection.CreateCommand();
               SqlTransaction transaction = connection.BeginTransaction();

               command.Transaction = transaction;
               command.Connection = connection;
               SqlDataReader reader = null;

               try
               {
                   command.CommandText = " SELECT TOP(50) * FROM ProductOrder WHERE Simbol = '" + simbol + "' ORDER BY ID DESC";
                   reader = command.ExecuteReader();
                   while (reader.Read())
                   {
                       ProductOrder order = new ProductOrder();
                       order.Simbol = reader.GetString(1);
                       order.Quantity = reader.GetInt32(2);
                       order.Price = reader.GetDecimal(3);
                       productOrderList.Add(order);
                   }
                   reader.Close();
                   transaction.Commit();
                   return productOrderList;
               }
               catch (Exception ex)
               {
                   reader.Close();
                   transaction.Rollback();
                   throw (ex);
               }
           }
       }
      
    }

}