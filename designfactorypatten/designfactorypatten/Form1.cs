using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace designfactorypatten
{
    public partial class Form1 : Form
    {
        public int[] parameter = new int[4];
        public int[] Tparameter = new int[6];
        shapefactory f = new shapefactory();
        public Form1()
        {
            InitializeComponent();
            panel1.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel2.Refresh();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
                for (int i = 0; i <= richTextBox1.Lines.Length - 1; i++)
                {

                    char[] syntaxchar = { ' ', '(', ',', ')', ';' };
                    string[] readrichbox = richTextBox1.Lines;
                    string[] collect = readrichbox[i].Split(syntaxchar);

                    foreach (string x in collect)
                    {
                        Console.WriteLine(x);
                    }
                    Console.WriteLine(i);
                    Console.Read();



                  /*  if (collect[0].Equals("DrawTo", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("Repeat", StringComparison.OrdinalIgnoreCase))
                    {*/
                        if (collect[0].Equals("DrawTo", StringComparison.OrdinalIgnoreCase))
                        {

                            parameter[0] = Convert.ToInt32(collect[1]);
                            parameter[1] = Convert.ToInt32(collect[2]);

                            Tparameter[0] = Convert.ToInt32(collect[1]);
                            Tparameter[1] = Convert.ToInt32(collect[2]);

                }

                        if (collect[0].Equals("Rectangle", StringComparison.OrdinalIgnoreCase))
                        {
                            abstractshape abs = f.GetName("Rectangle");
                            parameter[2] = Convert.ToInt32(collect[1]);
                            parameter[3] = Convert.ToInt32(collect[2]);
                            abs.set(parameter);
                            abs.draw(e.Graphics);
                        }


                        if (collect[0].Equals("Triangle", StringComparison.OrdinalIgnoreCase))
                        {
                            abstractshape abs = f.GetName("Triangle");
                            Tparameter[2] = Convert.ToInt32(collect[1]);
                            Tparameter[3] = Convert.ToInt32(collect[2]);
                            Tparameter[4] = Convert.ToInt32(collect[3]);
                            Tparameter[5] = Convert.ToInt32(collect[4]);
                            abs.set(Tparameter);
                            abs.draw(e.Graphics);
                        }


                        if (collect[0].Equals("Circle", StringComparison.OrdinalIgnoreCase))
                        {
                            abstractshape abs = f.GetName("Circle");
                            parameter[2] = Convert.ToInt32(collect[1]);
                            parameter[3] = Convert.ToInt32(collect[2]);
                            abs.set(parameter);
                            abs.draw(e.Graphics);
                        }

                        if (collect[0].Equals("Repeat", StringComparison.OrdinalIgnoreCase))
                        {

                            MessageBox.Show(collect[0]);
                            MessageBox.Show(collect[1]);
                        }

                   /* }               
                        else
                            {
                    
                                MessageBox.Show("error");
                            }
                            */
                }

        }
    
    }
}
