using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Windows.Forms;


namespace practice_crud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private RecordsDbContext context = new RecordsDbContext();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Records.ToList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                Record selectedRecord = (Record)selectedRow.DataBoundItem;

                Record productToDelete = context.Records.FirstOrDefault(p => p.Guid == selectedRecord.Guid);

                context.Records.Remove(productToDelete);
                context.SaveChanges();
                dataGridView1.DataSource = context.Records.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Record newProduct = new Record
            {
                Guid = Guid.NewGuid(),
                Name = textBox1.Text,
                Date = dateTimePicker1.Value,
                Amount = int.Parse(textBox3.Text)
            };

            context.Records.Add(newProduct);
            context.SaveChanges();
            dataGridView1.DataSource = context.Records.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                Record selectedProduct = (Record)selectedRow.DataBoundItem;

                int newQuantity = int.Parse(textBox3.Text);
                string newName = textBox1.Text;
                DateTime newDate = dateTimePicker1.Value;

                Record recordToUpdate = context.Records.FirstOrDefault(p => p.Guid == selectedProduct.Guid);


                recordToUpdate.Amount = newQuantity;
                recordToUpdate.Name = newName;
                recordToUpdate.Date = newDate;
                context.SaveChanges();
                dataGridView1.DataSource = context.Records.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nameForSearch = textBox4.Text;

            if (nameForSearch != "")
            {
                List<Record> records = context.Records.ToList();

                records = records.FindAll(p => p.Name == nameForSearch);

                dataGridView1.DataSource = records;
            } else
            {
                List<Record> records = context.Records.ToList();
                dataGridView1.DataSource = records;
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int priceForSearch = string.IsNullOrEmpty(textBox5.Text) ? 0 : int.Parse(textBox5.Text);

            if (priceForSearch != 0)
            {
                List<Record> records = context.Records.ToList();

                records = records.FindAll(p => p.Amount == priceForSearch);

                dataGridView1.DataSource = records;
            }
            else
            {
                List<Record> records = context.Records.ToList();
                dataGridView1.DataSource = records;
            }
        }
    }
}