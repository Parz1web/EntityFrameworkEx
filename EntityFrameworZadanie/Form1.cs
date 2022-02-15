using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworZadanie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

            newLocalDbEntities _db = new newLocalDbEntities();

            Product prodEx = new Product();
            prodEx.Title = textBox1.Text;
            prodEx.Description = textBox2.Text;
            prodEx.Price = int.Parse(textBox3.Text);

            _db.Product.Add(prodEx);
            _db.SaveChanges();

            var c = (from a in _db.Product
                     select new { id = a.Id, Название = a.Title, Описание = a.Description, Цена = a.Price });

            dataGridView1.DataSource = c.ToList();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            newLocalDbEntities _db = new newLocalDbEntities();


            var c = (from a in _db.Product

                     select new { id = a.Id, Название = a.Title, Описание = a.Description, Цена = a.Price }); ;
            //Сделал через Linq запросы, чтобы назвать поля DataGridView по-своему
            dataGridView1.DataSource = c.ToList();
        }
    }
}
