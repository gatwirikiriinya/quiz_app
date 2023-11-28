using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQuizApp
{
    public partial class AvailableQuizes : Form
    {
        public AvailableQuizes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            QuizForm form2 = new QuizForm();

            form2.ShowDialog();

            form2 = null;

            this.Show();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex == 0)
            {
                
                this.Hide();

             
                QuizForm quizForm = new QuizForm();

                quizForm.ShowDialog();

                quizForm = null;

                this.Show();
            }
        }
    }
}
