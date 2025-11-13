using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiCafe.Data;
using QuanLiCafe.Models;
using Microsoft.EntityFrameworkCore;

namespace TableForm
{
    public partial class Delete_Table : Form
    {
        private readonly CafeContext _context;
        private readonly int _tableId;

        public Delete_Table(int tableId)
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            _tableId = tableId;

            this.Load += Delete_Table_Load;
            btn_luu.Click += Btn_luu_Click;
            btn_huy.Click += Btn_huy_Click;

            // Đổi text nút Lưu thành Xóa
            btn_luu.Text = "Xóa";
            btn_luu.BackColor = Color.Red;
        }

        private void Delete_Table_Load(object sender, EventArgs e)
        {
            // Load thông tin bàn
            LoadTableInfo();

            // Disable các textbox để không cho sửa
            txb_SoBan.Enabled = false;
            txb_TenBan.Enabled = false;
            cb_GioiTinh.Enabled = false;

            // Load danh sách vị trí
            cb_GioiTinh.Items.Clear();
            cb_GioiTinh.Items.Add("Tầng 1");
            cb_GioiTinh.SelectedIndex = 0;
        }

        private void LoadTableInfo()
        {
            try
            {
                var table = _context.Tables.Find(_tableId);
                if (table != null)
                {
                    txb_SoBan.Text = table.Id.ToString();
                    txb_TenBan.Text = table.Name;
                    cb_GioiTinh.Text = "Tầng 1";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bàn!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin bàn:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_luu_Click(object sender, EventArgs e)
        {
            // Xác nhận xóa
            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa bàn '{txb_TenBan.Text}'?\n\nLưu ý: Không thể xóa bàn đang có đơn hàng!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var table = _context.Tables
                        .Include(t => t.Orders)
                        .FirstOrDefault(t => t.Id == _tableId);

                    if (table == null)
                    {
                        MessageBox.Show("Không tìm thấy bàn!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra bàn có đơn hàng không
                    if (table.Orders.Any())
                    {
                        MessageBox.Show("Không thể xóa bàn có đơn hàng!\nVui lòng xóa các đơn hàng trước.",
                            "Không thể xóa",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xóa bàn
                    _context.Tables.Remove(table);
                    _context.SaveChanges();

                    MessageBox.Show("Xóa bàn thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa bàn:\n{ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Delete_Table_Load_1(object sender, EventArgs e)
        {

        }
    }
}
