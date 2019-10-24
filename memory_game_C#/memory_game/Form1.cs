using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memory_game
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        List<string> icons = new List<string>()
        {
            "," , "," , "!" , "!" , "N" , "N" , "k" , "k",
            "b" , "b" , "v" , "v" , "w" , "w" , "z" , "z" 
        };

        Label firstclick, secondclick;

        public Form1()
        {
            InitializeComponent();
            assignIconToSquares();

        }

        private void label_click(object sender, EventArgs e)
        {

            if (firstclick != null && secondclick != null)
                return;

            Label clickedlabel = sender as Label;
            if (clickedlabel == null)
                return;

            if (clickedlabel.ForeColor == Color.Black)
                return;

            if (firstclick == null)
            {
                firstclick = clickedlabel;
                firstclick.ForeColor = Color.Black;
                return;
            }

            secondclick = clickedlabel;
            secondclick.ForeColor = Color.Black;

            checkIfIWinit();
            if (firstclick.Text ==secondclick.Text)
            {
                firstclick = null;
                secondclick = null;
            }
            else
                timer1.Start();
        }

        private void checkIfIWinit()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label!=null && label.ForeColor == label.BackColor)
                {
                    return;
                }
            }
            MessageBox.Show("you matched all the icons congrats. created by abdallah abusedo");

            Close();

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstclick.ForeColor = firstclick.BackColor;
            secondclick.ForeColor = secondclick.BackColor;
            firstclick = null;
            secondclick = null;
        }

        private void assignIconToSquares()
        {
            Label label;
            int randomnumber;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[i];
                }
                else
                    continue;

                randomnumber = rand.Next(0, icons.Count);
                label.Text = icons[randomnumber];

                icons.RemoveAt(randomnumber);


            }
        }
    }

}
