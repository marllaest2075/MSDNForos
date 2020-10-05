using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadenaDeConeccion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();

        }

        private void cargar()
        {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var cad = config.ConnectionStrings.ConnectionStrings["Sql"].ConnectionString.Split(';');
            Dictionary<string, string> campos = new Dictionary<string, string>();
            foreach (string item in cad)
            {
                if (item == "")
                    continue;
                var items = item.Split('=');
                campos.Add(items[0], items[1]);
            }
            Mostrar(campos);
        }

        private void Mostrar(Dictionary <string, string> campos)
        {
            textBox1.Text = campos["Data Source"];
            textBox2.Text = campos["Initial Catalog"];
            textBox3.Text = campos["User ID"];
            textBox4.Text = campos["Password"];
        }

        private void Guardar()
         {
            var value = $"Data Source = {textBox1.Text};Initial Catalog = {textBox2.Text}; User ID = {textBox3.Text}; Password = {textBox4.Text}";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["Sql"].ConnectionString = value;
            config.Save(ConfigurationSaveMode.Modified);
            cargar();
        }
    }
}
