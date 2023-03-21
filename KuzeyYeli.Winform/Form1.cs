using KUZEYYELİ.ORM.Facade;
using KUZEYYELİ.ORM.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuzeyYeli.Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urunler.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Urun entity = new Urun();
            entity.UrunAdi = textBox1.Text;
            entity.Fiyat = numericUpDown1.Value;
            entity.Stok = (short)numericUpDown2.Value;
            if (!Urunler.Ekle(entity))
                MessageBox.Show("Ürün eklenemedi");
            else
                MessageBox.Show("Ürün eklendi");
            dataGridView1.DataSource = Urunler.Listele();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            Urun silinecek = new Urun();
            silinecek.UrunId = (int)dataGridView1.CurrentRow.Cells["UrunID"].Value;
            if (!Urunler.Sil(silinecek))
                MessageBox.Show("Ürün silinemedi");
            else
                MessageBox.Show("Ürün silindi");
            dataGridView1.DataSource = Urunler.Listele(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["UrunAdi"].Value.ToString();
            textBox1.Tag = row.Cells["UrunId"].Value;
            numericUpDown1.Value = (decimal)row.Cells["Fiyat"].Value;
            numericUpDown2.Value = Convert.ToDecimal(row.Cells["Stok"].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Urun update = new Urun();
            update.UrunId = (int)textBox1.Tag;
            update.UrunAdi = textBox1.Text;
            update.Fiyat = numericUpDown1.Value;
            update.Stok = (short)numericUpDown2.Value;
            if (!Urunler.Guncelle(update))
                MessageBox.Show("Ürün güncelleme başarısız");
            else
                MessageBox.Show("Ürün güncelleme yapıldı");
            dataGridView1.DataSource = Urunler.Listele();

        }
    }
}
