using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T06_TreeView_DataGridView_LenhSQL
{
    public partial class frmXemDiem : Form
    {
        clsDuLieu dl = new clsDuLieu();
        DataTable tblLop, tblSV, tblDiem;

        private void twLop_SV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode NutHH = twLop_SV.SelectedNode;
            if (NutHH != null)
            {
                string strMa = "";
                if (NutHH.Parent != null)
                {
                    strMa = NutHH.Tag.ToString();

                }
                tblDiem = dl.LayBangDiem(strMa);
                dgrDiemThi.DataSource = tblDiem;
                if (tblDiem.Rows.Count == 0)
                {
                    if (strMa == "")
                    {
                        lblThongTin.Text = "Lớp: " + NutHH.Text + " (Sỉ số: " + NutHH.Nodes.Count + ")";
                    }
                    else
                    {
                        lblThongTin.Text = "Sinh viên " + NutHH.Text + " chưa thi môn nào ";
                    }
                }
            }
            else
            {
                lblThongTin.Text = "Điểm thi của " + NutHH.Text;
            }
        }

        public frmXemDiem()
        {
            InitializeComponent();
        }

        private void frmXemDiem_Load(object sender, EventArgs e)
        {
            if (!dl.KetNoi())
            {
                Close();
                return;
            }
            tblLop = dl.LayDLcoDK("Lop", "", "TenLop");
            tblSV = dl.LayDLcoDK("SinhVien", "", "MaSV");
            dl.HienThiCay2Tang(twLop_SV, tblLop, tblSV, "TenLop", "MaLop", "HoTenSV", "MaSV");
        }
    }
}
