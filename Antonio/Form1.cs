using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Antonio
{
    public partial class Form1 : Form
    {
        public static string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=finalsDBA_Antonio;Integrated Security=True";
        private void SetDarkModeForDataGridView(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = Color.FromArgb(39, 46, 54); ;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.ForeColor = Color.White;

            // Set the header background color
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(39, 46, 54); // Change to black

            // Set the header foreground color (text color)
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(39, 46, 54);

            // Set the selection background color
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(39, 46, 54);

            // Set the selection foreground color
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;

            // Set the cell border style
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(39, 46, 54);
            // Optionally, set specific column styles
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.DefaultCellStyle.BackColor = Color.FromArgb(39, 46, 54); ;
                column.DefaultCellStyle.ForeColor = Color.White;
                column.HeaderCell.Style.BackColor = Color.FromArgb(39, 46, 54); ;
                column.HeaderCell.Style.ForeColor = Color.White;
                column.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular); // Adjust font size as needed

            }
            dataGridView.RowTemplate.Height = 50;

        }
        public Form1()
        {
            InitializeComponent();
            ReducePanelBorderRadius(panel3, 20);
            ReducePanelBorderRadius(panel4, 20);
            ReducePanelBorderRadius(panel5, 20);
            ReducePanelBorderRadius(panel6, 20);
            ReducePanelBorderRadius(panel7, 20);
            ReducePanelBorderRadius(panel8, 20);
            ReducePanelBorderRadius(panel9, 20);
            ReducePanelBorderRadius(panel10, 20);
            ReducePanelBorderRadius(panel13, 20);
            ReducePanelBorderRadius(panel12, 20);
            SetDarkModeForDataGridView(dataGridView1);
            SetDarkModeForDataGridView(dataGridView2);
            SetDarkModeForDataGridView(dataGridView3);
            SetDarkModeForDataGridView(dataGridView4);
            SetDarkModeForDataGridView(dataGridViewfood);
            SetDarkModeForDataGridView(dataGridViewdrinks);
            SetDarkModeForDataGridView(dataGridViewexpenses);
            SetDarkModeForDataGridView(dataGriddrinks);
            progress();
            d1();
            d2();
            d3();
            d4();
            d5();
            d6();
            d7();
            d8();
            l1();
            l2();
            l3();
            l4();
            l5();
            l6();
            order.Hide();


        }
        private void d8() {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select * from Drinks";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataGriddrinks.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGriddrinks.Columns)
                {
                    column.Width = 140;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        private void d7()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select * from Foods";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataGridView4.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridView4.Columns)
                {
                    column.Width = 140;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        private void d6() {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select * from ingredients";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataGridViewexpenses.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridViewexpenses.Columns)
                {
                    column.Width = 280;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        private void d5()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select * from Drinks";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataGridViewdrinks.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridViewdrinks.Columns)
                {
                    column.Width = 115;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        private void d4()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select * from Foods";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataGridViewfood.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridViewfood.Columns)
                {
                    column.Width = 115;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        private void d3()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT \r\n    c.Name AS CustomerName, \r\n    f.FoodName, \r\n    d.DrinkName,\r\n    f.FoodID,\r\n    d.DrinkID,\r\n    o.OrderID\r\nFROM \r\n    Customers c\r\nLEFT JOIN \r\n    Orders o ON c.CustomerID = o.CustomerID\r\nLEFT JOIN \r\n    Foods f ON o.FoodID = f.FoodID\r\nLEFT JOIN \r\n    Drinks d ON o.DrinkID = d.DrinkID;\r\n";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataGridView3.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridView3.Columns)
                {
                    column.Width = 97;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        private void d2()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Write your SQL SELECT statement
                string query = "Select * From ingredients";

                // Create a new SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Create a new DataTable
                DataTable dataTable = new DataTable();

                // Fill the DataTable with data from the SQL query
                adapter.Fill(dataTable);

                // Set the DataSource of the DataGridView to the DataTable
                dataGridView2.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    column.Width = 115;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        private void l6()
        {
            decimal num1;
            decimal num2;
            decimal num3;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select SUM(expense) from ingredients";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    num1 = Convert.ToInt32(result);
                }
                else
                {
                    num1 = 0;
                }
                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(TotalPrice) AS TotalPriceSum\r\nFROM (\r\n    SELECT ISNULL(SUM(f.Price), 0) + ISNULL(SUM(d.Price), 0) AS TotalPrice\r\n    FROM Customers c\r\n    LEFT JOIN Orders o ON c.CustomerID = o.CustomerID\r\n    LEFT JOIN Foods f ON o.FoodID = f.FoodID\r\n    LEFT JOIN Drinks d ON o.DrinkID = d.DrinkID\r\n    GROUP BY c.Name\r\n) AS TotalPrices;";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                object result1 = command.ExecuteScalar();

                if (result1 != DBNull.Value)
                {
                    num2 = Convert.ToInt32(result1);
                }
                else
                {
                    num2 = 0;
                }
                connection.Close();
            }
            num3 = (num2 / num1) * 100;
            decimal num4 = decimal.Round(num3, 2);
            label6.Text = num4.ToString() + "%";
        }
        private void l5()
        {

            decimal num1;
            decimal num2;
            decimal num3;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select SUM(expense) from ingredients";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    num1 = Convert.ToInt32(result);
                }
                else
                {
                    num1 = 0;
                }
                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(TotalPrice) AS TotalPriceSum\r\nFROM (\r\n    SELECT ISNULL(SUM(f.Price), 0) + ISNULL(SUM(d.Price), 0) AS TotalPrice\r\n    FROM Customers c\r\n    LEFT JOIN Orders o ON c.CustomerID = o.CustomerID\r\n    LEFT JOIN Foods f ON o.FoodID = f.FoodID\r\n    LEFT JOIN Drinks d ON o.DrinkID = d.DrinkID\r\n    GROUP BY c.Name\r\n) AS TotalPrices;";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                object result1 = command.ExecuteScalar();

                if (result1 != DBNull.Value)
                {
                    num2 = Convert.ToInt32(result1);
                }
                else
                {
                    num2 = 0;
                }
                connection.Close();
            }
            num3 = num2 + num1;
            decimal num4 = decimal.Round(num3, 2);
            label8.Text = "₱ " + num4.ToString();
        }
        private void l4()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select SUM(expense) from ingredients";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    label14.Text = "₱ " + result.ToString();
                }
                else
                {
                    label14.Text = "No sales";
                }
                connection.Close();
            }
        }
        private void l3()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select SUM(stocks) from Drinks";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    label12.Text = result.ToString() + "";
                }
                else
                {
                    label12.Text = "No sales";
                }
                connection.Close();
            }
        }
        private void l2()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select Count(*) from Orders";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    label10.Text = result.ToString();
                }
                else
                {
                    label10.Text = "No sales";
                }
                connection.Close();
            }

        }
        private void l1()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(TotalPrice) AS TotalPriceSum\r\nFROM (\r\n    SELECT ISNULL(SUM(f.Price), 0) + ISNULL(SUM(d.Price), 0) AS TotalPrice\r\n    FROM Customers c\r\n    LEFT JOIN Orders o ON c.CustomerID = o.CustomerID\r\n    LEFT JOIN Foods f ON o.FoodID = f.FoodID\r\n    LEFT JOIN Drinks d ON o.DrinkID = d.DrinkID\r\n    GROUP BY c.Name\r\n) AS TotalPrices;";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    label3.Text = "₱ " + result.ToString();
                }
                else
                {
                    label3.Text = "No sales";
                }
                connection.Close();
            }

        }
        private void d1()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Write your SQL SELECT statement
                string query = "SELECT c.Name AS CustomerName, d.DrinkName, f.FoodName, ISNULL(SUM(f.Price), 0) AS FoodPrice, ISNULL(SUM(d.Price), 0) AS DrinkPrice, ISNULL(SUM(f.Price), 0) + ISNULL(SUM(d.Price), 0) AS TotalPrice " +
                               "FROM Customers c " +
                               "LEFT JOIN Orders o ON c.CustomerID = o.CustomerID " +
                               "LEFT JOIN Foods f ON o.FoodID = f.FoodID " +
                               "LEFT JOIN Drinks d ON o.DrinkID = d.DrinkID " +
                               "GROUP BY c.Name, d.DrinkName, f.FoodName";

                // Create a new SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Create a new DataTable
                DataTable dataTable = new DataTable();

                // Fill the DataTable with data from the SQL query
                adapter.Fill(dataTable);

                // Set the DataSource of the DataGridView to the DataTable
                dataGridView1.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.Width = 115;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        private void ReducePanelBorderRadius(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }
        private void progress()
        {
            int maximum = 0;
            int values = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select SUM(expense) from ingredients";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    maximum = Convert.ToInt32(result);
                }
                else
                {
                    maximum = 0;
                }
                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(TotalPrice) AS TotalPriceSum\r\nFROM (\r\n    SELECT ISNULL(SUM(f.Price), 0) + ISNULL(SUM(d.Price), 0) AS TotalPrice\r\n    FROM Customers c\r\n    LEFT JOIN Orders o ON c.CustomerID = o.CustomerID\r\n    LEFT JOIN Foods f ON o.FoodID = f.FoodID\r\n    LEFT JOIN Drinks d ON o.DrinkID = d.DrinkID\r\n    GROUP BY c.Name\r\n) AS TotalPrices;";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                object result1 = command.ExecuteScalar();

                if (result1 != DBNull.Value)
                {
                    values = Convert.ToInt32(result1);
                }
                else
                {
                    values = 0;
                }
                connection.Close();
            }
            // Start a loop to update the progress bar

            progressBar1.Maximum = maximum;

            // Reset the progress bar
            progressBar1.Value = values;

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            order.Show();
            Expenses.Hide();
            Drinks.Hide();
            Foods.Hide();
             
            
        }
        int orderId;
        private void button6_Click(object sender, EventArgs e)
        {
            int foodId = int.Parse(tfood.Text);
            int drinksId = int.Parse(tdrinks.Text);
            DateTime dateTime = DateTime.Now;
            string custname = tcustname.Text;
            int customerId = 0;
            int orderId = 0;

            // Insert into Customers table
            string insertCustomerQuery = "INSERT INTO Customers (Name) VALUES (@Name); SELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertCustomerQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", custname);
                    customerId = Convert.ToInt32(command.ExecuteScalar());
                    if (customerId > 0)
                    {
                        Console.WriteLine("Customer inserted successfully. CustomerID: " + customerId);
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                        MessageBox.Show("Inserted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No customer inserted.");
                    }
                }
            }

            // Insert into Orders table
            string insertOrderQuery = "INSERT INTO Orders (CustomerID, OrderDate, FoodID, DrinkID) VALUES (@CustomerID, @OrderDate, @FoodID, @DrinkID); SELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertOrderQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    command.Parameters.AddWithValue("@OrderDate", dateTime);
                    command.Parameters.AddWithValue("@FoodID", foodId);
                    command.Parameters.AddWithValue("@DrinkID", drinksId);
                    orderId = Convert.ToInt32(command.ExecuteScalar());
                    if (orderId > 0)
                    {
                        Console.WriteLine("Order inserted successfully. OrderID: " + orderId);
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                    }
                    else
                    {
                        Console.WriteLine("No order inserted.");
                    }
                }
            }

            // Update the Drinks table to reduce stock
            string updateDrinksQuery = "UPDATE Drinks SET stocks = stocks - 1 WHERE DrinkID = @DrinkID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(updateDrinksQuery, connection))
                {
                    command.Parameters.AddWithValue("@DrinkID", drinksId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Drink stock updated successfully.");
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                    }
                    else
                    {
                        Console.WriteLine("No drink stock updated.");
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            order.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void order_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            tfood.Clear();
            tdrinks.Clear();
            tcustname.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {   
            order.Show();
            Expenses.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string deleteOrderQuery = "DELETE FROM Orders WHERE OrderID = @OrderID;";
            string deleteCustomerQuery = "DELETE FROM Customers Where CustomerID =@OrderID; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(deleteOrderQuery, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", id);

                    int orderRowsAffected = command.ExecuteNonQuery();
                    if (orderRowsAffected > 0)
                    {
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                        MessageBox.Show("Delete Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No order deleted.");
                    }
                }

                // Now, delete the associated customer (if any)
                using (SqlCommand command = new SqlCommand(deleteCustomerQuery, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", id);

                    int customerRowsAffected = command.ExecuteNonQuery();
                    if (customerRowsAffected > 0)
                    {
                        Console.WriteLine("Customer deleted successfully.");
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                    }
                    else
                    {
                        Console.WriteLine("No customer deleted.");
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int foodId = int.Parse(tfood.Text);
            int drinksId = int.Parse(tdrinks.Text);
            DateTime dateTime = DateTime.Now;
            string custname = tcustname.Text;
            int customerId = int.Parse(textBox1.Text);
            string updateOrderQuery = "UPDATE Orders " +
                             "SET CustomerID = @CustomerID, " +
                             "    OrderDate = @OrderDate, " +
                             "    FoodID = @FoodID, " +
                             "    DrinkID = @DrinkID " +
                             "WHERE OrderID = @OrderID;";

            string updateCustomerQuery = "UPDATE Customers " +
                                         "SET Name = @Name " +
                                         "WHERE CustomerID = @CustomerID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(updateOrderQuery, connection))
                {
                    // Set parameters for the order update
                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    command.Parameters.AddWithValue("@OrderDate", dateTime);
                    command.Parameters.AddWithValue("@FoodID", foodId);
                    command.Parameters.AddWithValue("@DrinkID", drinksId);
                    command.Parameters.AddWithValue("@OrderID", customerId);

                    int orderRowsAffected = command.ExecuteNonQuery();
                    if (orderRowsAffected > 0)
                    {
                        Console.WriteLine("Order updated successfully.");
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                        MessageBox.Show("Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No order updated.");
                    }
                }

                // Now, update the associated customer (if any)
                using (SqlCommand command = new SqlCommand(updateCustomerQuery, connection))
                {
                    // Set parameters for the customer update
                    command.Parameters.AddWithValue("@Name", custname);
                    command.Parameters.AddWithValue("@CustomerID", customerId);

                    int customerRowsAffected = command.ExecuteNonQuery();
                    if (customerRowsAffected > 0)
                    {
                        Console.WriteLine("Customer updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No customer updated.");
                    }
                }
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            decimal expense = decimal.Parse(textBox3.Text);
            string insertIngredientQuery = "INSERT INTO ingredients (name, expense) VALUES (@IngredientName, @Quantity);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertIngredientQuery, connection))
                {
                    command.Parameters.AddWithValue("@IngredientName", name);
                    command.Parameters.AddWithValue("@Quantity", expense);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Ingredient inserted successfully.");
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        d6();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                    }
                    else
                    {
                        Console.WriteLine("No ingredient inserted.");
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            decimal expense = decimal.Parse(textBox3.Text);
            string updateIngredientQuery = "UPDATE ingredients SET expense = @NewExpense WHERE name = @IngredientName;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(updateIngredientQuery, connection))
                {
                    command.Parameters.AddWithValue("@NewExpense", expense);
                    command.Parameters.AddWithValue("@IngredientName", name);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Ingredient expense updated successfully.");
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        d6();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                    }
                    else
                    {
                        Console.WriteLine("No ingredient expense updated.");
                    }
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string deleteIngredientQuery = "DELETE FROM ingredients WHERE name = @IngredientName;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(deleteIngredientQuery, connection))
                {
                    command.Parameters.AddWithValue("@IngredientName", name);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Ingredient deleted successfully.");
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        d6();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                    }
                    else
                    {
                        Console.WriteLine("No ingredient deleted.");
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
        }

        private void dataGridViewexpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row index is clicked
            {
                // Get the DataGridViewRow corresponding to the clicked cell
                DataGridViewRow row = dataGridViewexpenses.Rows[e.RowIndex];
                textBox2.Text = row.Cells["name"].Value.ToString();
                textBox3.Text = row.Cells["expense"].Value.ToString();
            }
        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row index is clicked
            {
                // Get the DataGridViewRow corresponding to the clicked cell
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];
                f1.Text = row.Cells["FoodID"].Value.ToString();
                f2.Text = row.Cells["FoodName"].Value.ToString();
                f3.Text = row.Cells["Description"].Value.ToString();
                f4.Text = row.Cells["Price"].Value.ToString();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int foodid = int.Parse(f1.Text);
            string foodname = f2.Text;
            string description = f3.Text;
            decimal price = decimal.Parse(f4.Text);
            string insertFoodQuery = "INSERT INTO Foods (FoodID,FoodName, Description, Price) VALUES (@FoodID,@FoodName, @Description, @Price);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertFoodQuery, connection))
                {
                    command.Parameters.AddWithValue("@FoodID", foodid);
                    command.Parameters.AddWithValue("@FoodName", foodname);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Price", price);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Food inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        d6();
                        d7();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert food.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            f1.Clear();
            f2.Clear();
            f3.Clear();
            f4.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int foodid = int.Parse(f1.Text);
            string foodname = f2.Text;
            string description = f3.Text;
            decimal price = decimal.Parse(f4.Text);
            string updateFoodQuery = "UPDATE Foods SET FoodName = @FoodName, Description = @Description, Price = @Price WHERE FoodID = @FoodID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(updateFoodQuery, connection))
                {
                    command.Parameters.AddWithValue("@FoodID", foodid);
                    command.Parameters.AddWithValue("@FoodName", foodname);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Price", price);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Food updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        d6();
                        d7();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update food.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int foodid = int.Parse(f1.Text);
            string deleteFoodQuery = "DELETE FROM Foods WHERE FoodID = @FoodID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(deleteFoodQuery, connection))
                {
                    command.Parameters.AddWithValue("@FoodID", foodid);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Food deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        d6();
                        d7();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete food.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int drinkid = int.Parse(dr1.Text);
            int stocks = int.Parse(textBox4.Text);
            string drinkname  =dr2.Text;
            string description = dr3.Text;
            decimal price = decimal.Parse(dr4.Text);
            string insertDrinkQuery = "INSERT INTO Drinks (DrinkID,DrinkName, Description, Price, stocks) VALUES (@DrinkID,@DrinkName, @Description, @Price,@stocks);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertDrinkQuery, connection))
                {
                    command.Parameters.AddWithValue("@DrinkID", drinkid);
                    command.Parameters.AddWithValue("@DrinkName", drinkname);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@stocks", stocks);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Drink inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        d6();
                        d7();
                        d8();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert drink.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int drinkid = int.Parse(dr1.Text);
            string drinkname = dr2.Text;
            string description = dr3.Text;
            decimal price = decimal.Parse(dr4.Text);
            string updateDrinkQuery = "UPDATE Drinks SET stocks = @stocks, DrinkName = @DrinkName, Description = @Description, Price = @Price WHERE DrinkID = @DrinkID;";
            int stocks = int.Parse(textBox4.Text);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(updateDrinkQuery, connection))
                {
                    command.Parameters.AddWithValue("@DrinkID", drinkid);
                    command.Parameters.AddWithValue("@DrinkName", drinkname);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@stocks", stocks);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Drink updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        d6();
                        d7();
                        d8();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update drink.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int drinkid = int.Parse(dr1.Text);
            string deleteDrinkQuery = "DELETE FROM Drinks WHERE DrinkID = @DrinkID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(deleteDrinkQuery, connection))
                {
                    command.Parameters.AddWithValue("@DrinkID", drinkid);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Drink deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progress();
                        d1();
                        d2();
                        d3();
                        d4();
                        d5();
                        d6();
                        d7();
                        d8();
                        l1();
                        l2();
                        l3();
                        l4();
                        l5();
                        l6();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete drink.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            dr1.Clear();
            dr2.Clear();
            dr3.Clear();
            dr4.Clear();
            textBox4.Clear();
        }

        private void dataGriddrinks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row index is clicked
            {
                // Get the DataGridViewRow corresponding to the clicked cell
                DataGridViewRow row = dataGriddrinks.Rows[e.RowIndex];
                dr1.Text = row.Cells["DrinkID"].Value.ToString();
                dr2.Text = row.Cells["DrinkName"].Value.ToString();
                dr3.Text = row.Cells["Description"].Value.ToString();
                dr4.Text = row.Cells["Price"].Value.ToString();
                textBox4.Text = row.Cells["stocks"].Value.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            order.Show();
            Expenses.Show();
            Foods.Show();
            Drinks.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            order.Show();
            Expenses.Show();
            Foods.Show();
            Drinks.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.ShowDialog();
        }
    }
}

