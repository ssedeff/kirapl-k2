using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kitap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Kitap kitap;

        List<Kitap> kitapListesi = new List<Kitap>();

        private void Form1_Load(object sender, EventArgs e)
        {
            kitapListesi.Add(new Kitap(1, "Karantina", "Beyza ALKOÇ", 448, "Roman",true,new DateTime(2016,1, 1 )));
            kitapListesi.Add(new Kitap(2, "Yalancılar ve Yabancılar", "Emre GÜL", 463,"Roman", false, new DateTime(2021,6,29)));
            kitapListesi.Add(new Kitap(3, "En Çılgın Takıntı", "Danıelle LORI", 432, "Aşk", true, new DateTime(2019, 12, 6)));
            kitapListesi.Add(new Kitap(4, "Tutunamayanlar", "Oğuz ATAY", 724, "Türk Edebiyatı",true, new DateTime(1972, 12, 27)));
            dgvList.DataSource = kitapListesi.ToList();
        }

        private void dgvList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvList.CurrentRow.Cells["id"].Value.ToString();
            txtAdi.Text = dgvList.CurrentRow.Cells["KitapAdi"].Value.ToString();
            txtYazar.Text = dgvList.CurrentRow.Cells["Yazar"].Value.ToString();
            txtSayfa.Text = dgvList.CurrentRow.Cells["Sayfa"].Value.ToString();
            cmbTur.Text = dgvList.CurrentRow.Cells["Tur"].Value.ToString();
            dtpBasim.Value = (DateTime)dgvList.CurrentRow.Cells["Tarih"].Value;
            chkCilt.Checked = (bool)dgvList.CurrentRow.Cells["Cilt"].Value;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string ad = txtAdi.Text;
            string yazar = txtYazar.Text;
            int sayfa =Convert.ToInt32(txtSayfa.Text);
            string tur = cmbTur.Text;
            DateTime tarih = dtpBasim.Value;
            bool cilt = chkCilt.Checked;
            Kitap yeniKİtap = new Kitap(id, ad, yazar, sayfa, tur, cilt,tarih);
            kitapListesi.Add(yeniKİtap);
            dgvList.DataSource = kitapListesi.ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilenSatir = dgvList.SelectedRows[0];

            Kitap secilenKitap = secilenSatir.DataBoundItem as Kitap;   

            DialogResult result = MessageBox.Show("Seçilen kitap silinsin mi?", "Kitap Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                kitapListesi.Remove(secilenKitap);
            }

            dgvList.DataSource = kitapListesi.ToList();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilenSatir = dgvList.SelectedRows[0];

            Kitap secilenKitap = secilenSatir.DataBoundItem as Kitap;

            int id = Convert.ToInt32(txtId.Text);
            string adi= txtAdi.Text;
            string yazar = txtYazar.Text;
            int sayfa= Convert.ToInt32(txtSayfa.Text);
            string tur =cmbTur.Text;
            DateTime tarih = dtpBasim.Value;
            bool cilt = chkCilt.Checked;

            secilenKitap.Id = id;
            secilenKitap.Kitapadi = adi;
            secilenKitap.Yazar = yazar;
            secilenKitap.Tur= tur;
            secilenKitap.Sayfa = sayfa;
            secilenKitap.Tarih = tarih;
            secilenKitap.Cilt = cilt;

            dgvList.DataSource = null;
            dgvList.DataSource = kitapListesi.ToList();
        }
    }
}
