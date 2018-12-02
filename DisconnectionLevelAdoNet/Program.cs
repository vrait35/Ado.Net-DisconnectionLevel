using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DisconnectionLevelAdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet("ShopDB");
            ds.ExtendedProperties["TimeStamp"] = DateTime.Now;
            ds.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            DataColumn idProduct = new DataColumn("idProduct", typeof(int));
            idProduct.ReadOnly = true;
            idProduct.AllowDBNull = false;
            idProduct.Unique = true;
            idProduct.AutoIncrement = true;
            idProduct.AutoIncrementSeed = 1;
            idProduct.AutoIncrementStep = 1;
            DataColumn nameProduct = new DataColumn("nameProduct", typeof(string));
            DataColumn price = new DataColumn("price", typeof(double));
            DataTable Products = new DataTable("Products");
            Products.Columns.AddRange(new DataColumn[] { idProduct, nameProduct, price });

            DataRow productRow = Products.NewRow();
            productRow["nameProduct"] = "огурцы";
            productRow["price"] = "300";
            Products.Rows.Add(productRow);
            productRow = Products.NewRow();
             productRow["nameProduct"] = "помидоры";
            productRow["price"] = "350";
            Products.Rows.Add(productRow);

            DataColumn idCustomer = new DataColumn("idCustomer", typeof(int));
            idCustomer.ReadOnly = true;
            idCustomer.AllowDBNull = false;
            idCustomer.Unique = true;
            idCustomer.AutoIncrement = true;
            idCustomer.AutoIncrementSeed = 1;
            idCustomer.AutoIncrementStep = 1;
            DataColumn fullNameCustomer = new DataColumn("fullName", typeof(string));
            DataTable Customers = new DataTable("Customers");
            Customers.Columns.AddRange(new DataColumn[] { idCustomer, fullNameCustomer });
            DataRow customerRow = Customers.NewRow();
            customerRow["fullName"] = "Сергей Сергеевич";
            Customers.Rows.Add(customerRow);

            DataColumn idEmployee = new DataColumn("idEmployee", typeof(int));
            idEmployee.ReadOnly = true;
            idEmployee.AllowDBNull = false;
            idEmployee.Unique = true;
            idEmployee.AutoIncrement = true;
            idEmployee.AutoIncrementSeed = 1;
            idEmployee.AutoIncrementStep = 1;
            DataColumn fullNameEmployee = new DataColumn("fullName", typeof(string));
            DataTable Employees = new DataTable("Employees");
            Employees.Columns.AddRange(new DataColumn[] { idEmployee, fullNameEmployee });
            DataRow employeeRow = Employees.NewRow();
            employeeRow["fullName"] = "Ксюша Андреевна";
            Employees.Rows.Add(employeeRow);

            DataColumn idOrder = new DataColumn("idOrder", typeof(int));
            idOrder.ReadOnly = true;
            idOrder.AllowDBNull = false;
            idOrder.Unique = true;
            idOrder.AutoIncrement = true;
            idOrder.AutoIncrementSeed = 1;
            idOrder.AutoIncrementStep = 1;
            DataColumn idEmployeeOrder = new DataColumn("idEmployeeOrder", typeof(int));            
            idEmployeeOrder.AllowDBNull = false;
            DataColumn idCustomerOrder = new DataColumn("idCustomerOrder", typeof(int));
            idCustomerOrder.AllowDBNull = false;
            DataTable Orders = new DataTable("Orders");
            Orders.Columns.AddRange(new DataColumn[] { idOrder, idEmployeeOrder, idCustomerOrder });
            DataRow orderRow = Orders.NewRow();
            orderRow["idCustomerOrder"] = 1;
            orderRow["idEmployeeOrder"] = 1;
            Orders.Rows.Add(orderRow);
            
            ds.Tables.AddRange(new DataTable[] { Products, Customers, Employees, Orders });

            Console.WriteLine("asd");
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("=> Таблица: {0}", dt.TableName);

                // Вывод имени столбцов
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    Console.Write(dt.Columns[curCol].ColumnName + "\t");
                Console.WriteLine("\n--------------------------");

                // Выводим содержимое таблицы
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                        Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
                Console.WriteLine();
            }


        }
    }
}
