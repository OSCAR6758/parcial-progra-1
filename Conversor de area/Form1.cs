using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Conversor_de_area
{
    public partial class Form1 : Form
    {
        // Equivalencias de cada unidad en metros cuadrados
        private Dictionary<string, double> factores = new Dictionary<string, double>()
        {
            { "Pie Cuadrado", 0.092903 },
            { "Vara Cuadrada", 0.698896 },
            { "Yarda Cuadrada", 0.836127 },
            { "Metro Cuadrado", 1.0 },
            { "Tarea", 437.5 },
            { "Manzana", 6987.4 },
            { "Hectárea", 10000.0 }
        };

        public Form1()
        {
            InitializeComponent();

            // Cargar las unidades
            CargarUnidades();
        }

        // Método para cargar las unidades en los ComboBox
        private void CargarUnidades()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            string[] unidades =
            {
                "Pie Cuadrado",
                "Vara Cuadrada",
                "Yarda Cuadrada",
                "Metro Cuadrado",
                "Tarea",
                "Manzana",
                "Hectárea"
            };

            // Agregar las unidades a los dos ComboBox
            comboBox1.Items.AddRange(unidades);
            comboBox2.Items.AddRange(unidades);

            // Selecciones iniciales
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 3;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        // BOTÓN CONVERTIR
        private void btnConvertir_Click(object sender, EventArgs e)
        {
            
            double valor;

            if (!double.TryParse(textBox1.Text, out valor))
            {
                MessageBox.Show(
                    "Por favor, ingrese un número válido.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                textBox1.Focus();
                return;
            }

            
            if (comboBox1.SelectedItem == null ||
                comboBox2.SelectedItem == null)
            {
                MessageBox.Show(
                    "Seleccione la unidad de origen y la unidad de destino.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            
            string unidadOrigen = comboBox1.SelectedItem.ToString();
            string unidadDestino = comboBox2.SelectedItem.ToString();

            
            double valorEnMetrosCuadrados =
                valor * factores[unidadOrigen];

            
            double resultado =
                valorEnMetrosCuadrados / factores[unidadDestino];

            
            textBox2.Text = resultado.ToString("0.####");

            
            label4.Text = valor + " " + unidadOrigen +
                          " = " + resultado.ToString("0.####") +
                          " " + unidadDestino;
        }

        // BOTÓN LIMPIAR
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            // Restablecer unidades
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 3;

            label4.Text = "";

            textBox1.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}