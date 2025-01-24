using EscPosCommand;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace EscPosCommandDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var printers = PrinterSettings.InstalledPrinters.Cast<string>();
            comboBox1.Items.AddRange(printers.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var printerName = comboBox1.Text;
            var printer = new Printer(printerName);

            printer.AutoTest();

            printer.PrintDocument();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var image = Image.FromFile("logo.jpg");
            var bitmap = new Bitmap(image);

            image.Dispose();

            var printerName = comboBox1.Text;
            var printer = new Printer(printerName);

            printer.Image(bitmap, false);

            printer.PrintDocument();
        }
    }
}
