using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miniWord
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bool init = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            memoEdit1.Text = "";
        }

        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                memoEdit1.Text = "";
                using (var reader = new StreamReader(openFileDialog1.FileName))
                    memoEdit1.Text = reader.ReadToEnd();
            }
        }

       
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(saveFileDialog1.FileName))
                    writer.Write(memoEdit1.Text);
            }
        }

        private void cpFontColor_EditValueChanged(object sender, EventArgs e)
        {
            if (init) return;
            var cb = sender as BarEditItem;
            memoEdit1.ForeColor = (Color)cb.EditValue;
            memoEdit1.DeselectAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init = true;
            cpFontColor.EditValue = memoEdit1.ForeColor;
            cbFontSel.EditValue = memoEdit1.Font.Name;
            cbFontSize.EditValue = memoEdit1.Font.Size;
            init = false;
            memoEdit1.DeselectAll();
        }

        private void cbFontSel_EditValueChanged(object sender, EventArgs e)
        {
            if (init) return;
            var cb = sender as BarEditItem;
            memoEdit1.Font = new Font(cb.EditValue.ToString(), memoEdit1.Font.Size);
            memoEdit1.DeselectAll();
        }

        private void cbFontSize_EditValueChanged(object sender, EventArgs e)
        {
            if (init) return;
            var cb = sender as BarEditItem;
            memoEdit1.Font = new Font(memoEdit1.Font.Name, (float)Convert.ToDouble(cb.EditValue));
            memoEdit1.DeselectAll();
        }

        private void cbFontSize_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (init) return;
            var cb = sender as BarEditItem;
            memoEdit1.Font = new Font(memoEdit1.Font.Name, (float)Convert.ToDouble(cb.EditValue));
            memoEdit1.DeselectAll();
        }

        private void repositoryItemSpinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            cbFontSize_ItemClick(cbFontSize, null);
  
        }

        private void repositoryItemSpinEdit1_ValueChanged(object sender, EventArgs e)
        {
            cbFontSize_ItemClick(cbFontSize, null);

        }
    }
}
