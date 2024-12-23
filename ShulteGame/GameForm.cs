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
    public partial class GameForm : Form
    {
        private int gridSize;
        private int[] numbers;
        private Button[,] buttons;
        private int currentNumber = 1;
        private DateTime startTime;
        public GameForm(int size)
        {
            InitializeComponent();
            gridSize = size;
            numbers = Enumerable.Range(1, gridSize * gridSize).ToArray();
            ShuffleNumbers();
            CreateGrid();
        }
        private void ShuffleNumbers()
        {
            Random rng = new Random();
            numbers = numbers.OrderBy(x => rng.Next()).ToArray();
        }

        private void CreateGrid()
        {
            buttons = new Button[gridSize, gridSize];
            int buttonSize = 60; // Fixed button size
            int startX = (this.ClientSize.Width - gridSize * buttonSize) / 2;
            int startY = (this.ClientSize.Height - gridSize * buttonSize) / 2;


            int numberIndex = 0;
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    buttons[row, col] = new Button();
                    buttons[row, col].Text = numbers[numberIndex].ToString();
                    buttons[row, col].Font = new Font("Arial", 12, FontStyle.Bold);
                    buttons[row, col].Size = new Size(buttonSize, buttonSize);
                    buttons[row, col].Location = new Point(startX + col * buttonSize, startY + row * buttonSize);
                    buttons[row, col].Click += ButtonClick;
                    buttons[row, col].BackColor = Color.White;
                    this.Controls.Add(buttons[row, col]);
                    numberIndex++;
                }
            }
            startTime = DateTime.Now;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (int.Parse(clickedButton.Text) == currentNumber)
            {
                // Clear all red buttons
                foreach (var btn in buttons)
                {
                    if (btn.BackColor == Color.Red)
                        btn.BackColor = Color.White;
                }

                clickedButton.BackColor = Color.Green;
                currentNumber++;
                clickedButton.Enabled = false;

                if (currentNumber > gridSize * gridSize)
                {
                    GameOver();
                }
            }
            else
            {
                clickedButton.BackColor = Color.Red;
            }
        }

        private void GameOver()
        {
            TimeSpan duration = DateTime.Now - startTime;
            MessageBox.Show($"You won! Time taken: {duration.TotalSeconds:F2} seconds", "Game Over");
            this.Close();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void GameForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
