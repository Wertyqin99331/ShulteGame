using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShulteGame
{
    public partial class SizeChoosingForm : Form
    {
        public SizeChoosingForm()
        {
            InitializeComponent();

            for (int i = 3; i <= 10; i++)
            {
                comboBoxSize.Items.Add($"{i}x{i}");
            }

            comboBoxSize.SelectedIndex = 0;
        }

        private void SizeChoosingForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int size = int.Parse(comboBoxSize.SelectedItem.ToString().Split('x')[0]);

            GameForm gameForm = new GameForm(size);
            this.Hide(); // Hide the selection form
            gameForm.ShowDialog();
            this.Show();//show the selection form again after closing game
        }

        private void SizeChoosingForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
