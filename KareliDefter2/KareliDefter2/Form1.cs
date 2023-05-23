using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KareliDefter2
{
    public partial class Form1 : Form
    {
        Button[,] board = new Button[3, 3];
        bool[,] availableMoves = new bool[3, 3];
        int selectedRow = -1;
        int selectedCol = -1;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = new Button();
                    board[i, j].Size = new Size(50, 50);
                    board[i, j].Location = new Point(j * 50 + 10, i * 50 + 10);
                    board[i, j].Font = new Font("Arial", 20, FontStyle.Bold);
                    board[i, j].Click += new EventHandler(Board_Click);
                    this.Controls.Add(board[i, j]);
                    availableMoves[i, j] = false;
                }
            }
            ResetGame();
        }

        private void Board_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int row = (clickedButton.Location.Y - 10) / 50;
            int col = (clickedButton.Location.X - 10) / 50;

            if (availableMoves[row, col])
            {
                clickedButton.Text = "X";
                selectedRow = row;
                selectedCol = col;
                availableMoves[row, col] = false;
                clickedButton.Enabled = false; // tıklanan butonu devre dışı bırakır
                CheckAvailableMoves();
            }
        }

        private void CheckAvailableMoves()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Math.Abs(i - selectedRow) == 2 && Math.Abs(j - selectedCol) == 1 ||
                        Math.Abs(i - selectedRow) == 1 && Math.Abs(j - selectedCol) == 2)
                    {
                        availableMoves[i, j] = true;
                        board[i, j].Enabled = true;
                    }
                    else
                    {
                        availableMoves[i, j] = false;
                        board[i, j].Enabled = false;
                    }
                }
            }
        }

        private void ResetGame()
        {
            selectedRow = -1;
            selectedCol = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j].Text = "";
                    availableMoves[i, j] = false;
                    board[i, j].Enabled = true;
                }
            }
            
            board[0, 0].Enabled = false; // ilk butonu devre dışı bırakır
            CheckAvailableMoves();
        }
    }


}


