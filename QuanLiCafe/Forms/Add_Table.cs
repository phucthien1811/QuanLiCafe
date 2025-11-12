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

namespace TableForm
{
    public partial class Add_Table : Form
    {
        private readonly CafeContext _context;
        private int? _tableId; // null = thêm mới, có giá trị = chỉnh sửa

        // Constructor cho thêm mới
        public Add_Table()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            _tableId = null;
            
            this.Load += Add_Table_Load;
            btn_luu.Click += Btn_luu_Click;
            btn_huy.Click += Btn_huy_Click;
            
            this.Text = "Thêm mới bàn";
        }

        // Constructor cho chỉnh sửa
        public Add_Table(int tableId) : this()
        {
            _tableId = tableId;
            this.Text = "Chỉnh sửa bàn";
        }

        private void Add_Table_Load(object sender, EventArgs e)
        {
            // Load danh sách vị trí
            cb_GioiTinh.Items.Clear();
            cb_GioiTinh.Items.Add("Tầng 1");
            cb_GioiTinh.Items.Add("Tầng 2");
            cb_GioiTinh.Items.Add("Sân thượng");
            cb_GioiTinh.Items.Add("Ngoài trời");
            cb_GioiTinh.SelectedIndex = 0;
            
            // Nếu là chỉnh sửa, load thông tin bàn
            if (_tableId.HasValue)
            {
                LoadTableInfo(_tableId.Value);
            }
            else
            {
                // Tự động sinh số bàn tiếp theo
                var maxId = _context.Tables.Any() ? _context.Tables.Max(t => t.Id) : 0;
                txb_SoBan.Text = (maxId + 1).ToString();
                txb_TenBan.Text = $"Bàn {maxId + 1}";
            }
        }

        private void LoadTableInfo(int tableId)
        {
            try
            {
                var table = _context.Tables.Find(tableId);
                if (table != null)
                {
                    txb_SoBan.Text = table.Id.ToString();
                    txb_SoBan.Enabled = false; // Không cho sửa số bàn
                    txb_TenBan.Text = table.Name;
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
            // Validate
            if (string.IsNullOrWhiteSpace(txb_TenBan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bàn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txb_TenBan.Focus();
                return;
            }

            try
            {
                if (_tableId.HasValue)
                {
                    // Cập nhật bàn hiện có
                    var table = _context.Tables.Find(_tableId.Value);
                    if (table != null)
                    {
                        table.Name = txb_TenBan.Text.Trim();
                        _context.SaveChanges();
                        
                        MessageBox.Show("Cập nhật bàn thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Thêm bàn mới
                    var newTable = new Table
                    {
                        Name = txb_TenBan.Text.Trim(),
                        Status = "Free"
                    };
                    
                    _context.Tables.Add(newTable);
                    _context.SaveChanges();
                    
                    MessageBox.Show("Thêm bàn mới thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu thông tin bàn:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txb_TenBan_TextChanged(object sender, EventArgs e)
        {
            // Event handler đã có sẵn
        }
    }
}
