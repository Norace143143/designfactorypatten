using System;
using System.Collections;
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
    /// <summary>
    /// This class is design class
    /// there are many globel variable 
    /// this class has called factory class 
    /// hasstable is used
    /// In constructor panel1 is hide 
    /// In panel2 shape has ne drawn
    /// when button is clicked panel2 will refresh 
    /// </summary>
    public partial class Form1 : Form
    {
        //globel array variable are created 
        public int[] parameter = new int[4];
        public int[] Tparameter = new int[6];
        //instance of shapefactory 
        shapefactory f = new shapefactory();
        //instance of hashtable 
        Hashtable hs = new Hashtable();
        //constructor 
        public Form1()
        {
            InitializeComponent();
            //panel2 is hide
            panel1.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //exit for program
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //panel1 is showen
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
            // panel1 is shown
            panel1.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //panel2 is refreshed
            panel2.Refresh();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //reading each line of rich box
            for (int i = 0; i <= richTextBox1.Lines.Length - 1; i++)
            {
                //splite char is declared 
                char[] syntaxchar = { ' ', '(', ',', ')', ';' };
                //each line is stored in array 
                string[] readrichbox = richTextBox1.Lines;
                //each line is splited 
                string[] collect = readrichbox[i].Split(syntaxchar);

                //validation for command syntax 
                if (collect[0].Equals("DrawTo", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("Repeat", StringComparison.OrdinalIgnoreCase) ||
                   collect[0].Equals("Rectangle", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("Triangle", StringComparison.OrdinalIgnoreCase) ||
                   collect[0].Equals("Circle", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("var", StringComparison.OrdinalIgnoreCase))
                {

                    //for drawto command
                    if (collect[0].Equals("DrawTo", StringComparison.OrdinalIgnoreCase))
                    {
                        //try and catch block
                        try
                        {
                            parameter[0] = Convert.ToInt32(hs[collect[1]]);
                            parameter[1] = Convert.ToInt32(hs[collect[2]]);

                        }
                        catch
                        {
                            parameter[0] = Convert.ToInt32(collect[1]);
                            parameter[1] = Convert.ToInt32(collect[2]);
                        }
                        //try and catch block
                        try
                        {
                            parameter[0] = Convert.ToInt32(collect[1]);
                            parameter[1] = Convert.ToInt32(collect[2]);

                        }
                        catch
                        {
                            parameter[0] = Convert.ToInt32(hs[collect[1]]);
                            parameter[1] = Convert.ToInt32(hs[collect[2]]);
                        }
                        //try and catch block
                        try
                        {
                            Tparameter[0] = Convert.ToInt32(hs[collect[1]]);
                            Tparameter[1] = Convert.ToInt32(hs[collect[2]]);
                        }
                        catch
                        {
                            Tparameter[0] = Convert.ToInt32(collect[1]);
                            Tparameter[1] = Convert.ToInt32(collect[2]);
                        }
                        //try and catch block
                        try
                        {
                            Tparameter[0] = Convert.ToInt32(collect[1]);
                            Tparameter[1] = Convert.ToInt32(collect[2]);
                        }
                        catch
                        {
                            Tparameter[0] = Convert.ToInt32(hs[collect[1]]);
                            Tparameter[1] = Convert.ToInt32(hs[collect[2]]);
                        }

                    }
                    else if (collect[0].Equals("var", StringComparison.OrdinalIgnoreCase)) //variable command set up
                    {
                        if (collect[2].Equals("=") && collect[4].Equals(":"))
                        {
                            //start point is resolved 
                            int From = readrichbox[i].IndexOf("var") + "var".Length;
                            //number of character 
                            int To = readrichbox[i].LastIndexOf("=");
                            //hash key word is declare using substring 
                            String res = readrichbox[i].Substring(From, To - From).Replace(" ", String.Empty);
                            //start point is resolved 
                            int From1 = readrichbox[i].IndexOf("=") + "=".Length;
                            //number of character 
                            int To1 = readrichbox[i].LastIndexOf(":");
                            //hash key is declare using substring 
                            int res1 = Int32.Parse(readrichbox[i].Substring(From1, To1 - From1).Replace(" ", String.Empty));
                            //try and catch block
                            try
                            {
                                hs.Add(res, res1);
                            }
                            catch (Exception x)
                            {
                                hs[res] = res1;
                            }
                        }
                    }




                    //for rectangle command
                    if (collect[0].Equals("Rectangle", StringComparison.OrdinalIgnoreCase))
                    {
                        //intance of abstract class
                        abstractshape abs = f.GetName("Rectangle");
                        //try and catch block
                        try
                        {
                            parameter[2] = Convert.ToInt32(hs[collect[1]]);
                            parameter[3] = Convert.ToInt32(hs[collect[2]]);
                        }
                        catch
                        {
                            parameter[2] = Convert.ToInt32(collect[1]);
                            parameter[3] = Convert.ToInt32(collect[2]);
                        }
                        //try and catch block
                        try
                        {
                            parameter[2] = Convert.ToInt32(collect[1]);
                            parameter[3] = Convert.ToInt32(collect[2]);
                        }
                        catch
                        {
                            parameter[2] = Convert.ToInt32(hs[collect[1]]);
                            parameter[3] = Convert.ToInt32(hs[collect[2]]);
                        }
                        //seting the parameter 
                        abs.set(parameter);
                        //drawing the shape
                        abs.draw(e.Graphics);
                    }
                    else if (collect[0].Equals("var", StringComparison.OrdinalIgnoreCase)) //variable command set up
                    {
                        if (collect[2].Equals("=") && collect[4].Equals(":"))
                        {
                            //start point is resolved 
                            int From = readrichbox[i].IndexOf("var") + "var".Length;
                            //number of character 
                            int To = readrichbox[i].LastIndexOf("=");
                            //hash key word is declare using substring 
                            String res = readrichbox[i].Substring(From, To - From).Replace(" ", String.Empty);
                            //start point is resolved 
                            int From1 = readrichbox[i].IndexOf("=") + "=".Length;
                            //number of character 
                            int To1 = readrichbox[i].LastIndexOf(":");
                            //hash key is declare using substring 
                            int res1 = Int32.Parse(readrichbox[i].Substring(From1, To1 - From1).Replace(" ", String.Empty));
                            //try and catch block
                            try
                            {
                                hs.Add(res, res1);
                            }
                            catch (Exception x)
                            {
                                hs[res] = res1;
                            }
                        }
                    }


                    //for triangle command
                    if (collect[0].Equals("Triangle", StringComparison.OrdinalIgnoreCase))
                    {
                        //intance of abstract class
                        abstractshape abs = f.GetName("Triangle");
                        //try and catch block
                        try
                        {
                            Tparameter[2] = Convert.ToInt32(hs[collect[1]]);
                            Tparameter[3] = Convert.ToInt32(hs[collect[2]]);
                            Tparameter[4] = Convert.ToInt32(hs[collect[3]]);
                            Tparameter[5] = Convert.ToInt32(hs[collect[4]]);
                        }
                        catch
                        {
                            Tparameter[2] = Convert.ToInt32(collect[1]);
                            Tparameter[3] = Convert.ToInt32(collect[2]);
                            Tparameter[4] = Convert.ToInt32(collect[3]);
                            Tparameter[5] = Convert.ToInt32(collect[4]);
                        }
                        //try and catch block
                        try
                        {
                            Tparameter[2] = Convert.ToInt32(collect[1]);
                            Tparameter[3] = Convert.ToInt32(collect[2]);
                            Tparameter[4] = Convert.ToInt32(collect[3]);
                            Tparameter[5] = Convert.ToInt32(collect[4]);
                        }
                        catch
                        {
                            Tparameter[2] = Convert.ToInt32(hs[collect[1]]);
                            Tparameter[3] = Convert.ToInt32(hs[collect[2]]);
                            Tparameter[4] = Convert.ToInt32(hs[collect[3]]);
                            Tparameter[5] = Convert.ToInt32(hs[collect[4]]);
                        }
                        //seting the parameter 
                        abs.set(Tparameter);
                        //drawing the shape
                        abs.draw(e.Graphics);
                    }
                    else if (collect[0].Equals("var", StringComparison.OrdinalIgnoreCase)) //variable command set up
                    {
                        if (collect[2].Equals("=") && collect[4].Equals(":"))
                        {
                            int From = readrichbox[i].IndexOf("var") + "var".Length;
                            int To = readrichbox[i].LastIndexOf("=");

                            String res = readrichbox[i].Substring(From, To - From).Replace(" ", String.Empty);

                            int From1 = readrichbox[i].IndexOf("=") + "=".Length;
                            int To1 = readrichbox[i].LastIndexOf(":");

                            int res1 = Int32.Parse(readrichbox[i].Substring(From1, To1 - From1).Replace(" ", String.Empty));
                            try
                            {
                                hs.Add(res, res1);
                            }
                            catch (Exception x)
                            {
                                hs[res] = res1;
                            }
                        }
                    }

                    //for circle command
                    if (collect[0].Equals("Circle", StringComparison.OrdinalIgnoreCase))
                    {
                        abstractshape abs = f.GetName("Circle");
                        try
                        {
                            parameter[2] = Convert.ToInt32(hs[collect[1]]);
                            parameter[3] = Convert.ToInt32(hs[collect[2]]);
                        }
                        catch
                        {
                            parameter[2] = Convert.ToInt32(collect[1]);
                            parameter[3] = Convert.ToInt32(collect[2]);
                        }

                        try
                        {
                            parameter[2] = Convert.ToInt32(collect[1]);
                            parameter[3] = Convert.ToInt32(collect[2]);
                        }
                        catch
                        {

                            parameter[2] = Convert.ToInt32(hs[collect[1]]);
                            parameter[3] = Convert.ToInt32(hs[collect[2]]);
                        }
                        abs.set(parameter);
                        abs.draw(e.Graphics);
                    }
                    else if (collect[0].Equals("var", StringComparison.OrdinalIgnoreCase)) //variable command set up
                    {
                        if (collect[2].Equals("=") && collect[4].Equals(":"))
                        {
                            int From = readrichbox[i].IndexOf("var") + "var".Length;
                            int To = readrichbox[i].LastIndexOf("=");

                            String res = readrichbox[i].Substring(From, To - From).Replace(" ", String.Empty);

                            int From1 = readrichbox[i].IndexOf("=") + "=".Length;
                            int To1 = readrichbox[i].LastIndexOf(":");

                            int res1 = Int32.Parse(readrichbox[i].Substring(From1, To1 - From1).Replace(" ", String.Empty));
                            try
                            {
                                hs.Add(res, res1);
                            }
                            catch (Exception x)
                            {
                                hs[res] = res1;
                            }
                        }
                    }

                    //for repeat command
                    if (collect[0].Equals("Repeat", StringComparison.OrdinalIgnoreCase))
                    {
                        //initializing new parameter for rectangle and circle
                        int[] newpar = new int[4];
                        //initializing new parameter triangle
                        int[] tnewpar = new int[6];

                        //for rectangle
                        if (collect[2].Equals("rectangle", StringComparison.OrdinalIgnoreCase))
                        {
                            for (int x = 0; x < Convert.ToInt32(collect[1]) - 1; x++)
                            {
                                if (collect[3].Equals("+"))
                                {
                                    int add = Convert.ToInt32(collect[4]);
                                    abstractshape abs = f.GetName("Rectangle");
                                    if (x == 0)
                                    {
                                        newpar[0] = parameter[0];
                                        newpar[1] = parameter[1];
                                        newpar[2] = parameter[2] + add;
                                        newpar[3] = parameter[3] + add;
                                    }
                                    else
                                    {
                                        newpar[0] = newpar[0];
                                        newpar[1] = newpar[1];
                                        newpar[2] = newpar[2] + add;
                                        newpar[3] = newpar[3] + add;
                                    }
                                    abs.set(newpar);
                                    abs.draw(e.Graphics);

                                }
                                else if (collect[3].Equals("-"))
                                {
                                    int subtract = Convert.ToInt32(collect[4]);
                                    abstractshape abs = f.GetName("Rectangle");
                                    if (x == 0)
                                    {
                                        newpar[0] = parameter[0];
                                        newpar[1] = parameter[1];
                                        newpar[2] = parameter[2] - subtract;
                                        newpar[3] = parameter[3] - subtract;
                                    }
                                    else
                                    {
                                        newpar[0] = newpar[0];
                                        newpar[1] = newpar[1];
                                        newpar[2] = newpar[2] - subtract;
                                        newpar[3] = newpar[3] - subtract;
                                    }
                                    abs.set(newpar);
                                    abs.draw(e.Graphics);
                                }
                                else
                                {
                                    MessageBox.Show("error in command");
                                }
                            }
                        }

                        //for circle
                        if (collect[2].Equals("circle", StringComparison.OrdinalIgnoreCase))
                        {
                            for (int x = 0; x < Convert.ToInt32(collect[1]) - 1; x++)
                            {
                                if (collect[3].Equals("+"))
                                {
                                    int add = Convert.ToInt32(collect[4]);
                                    abstractshape abs = f.GetName("circle");
                                    if (x == 0)
                                    {
                                        newpar[0] = parameter[0];
                                        newpar[1] = parameter[1];
                                        newpar[2] = parameter[2] + add;
                                        newpar[3] = parameter[3] + add;
                                    }
                                    else
                                    {
                                        newpar[0] = newpar[0];
                                        newpar[1] = newpar[1];
                                        newpar[2] = newpar[2] + add;
                                        newpar[3] = newpar[3] + add;
                                    }
                                    abs.set(newpar);
                                    abs.draw(e.Graphics);

                                }
                                else if (collect[3].Equals("-"))
                                {
                                    int subtract = Convert.ToInt32(collect[4]);
                                    abstractshape abs = f.GetName("circle");
                                    if (x == 0)
                                    {
                                        newpar[0] = parameter[0];
                                        newpar[1] = parameter[1];
                                        newpar[2] = parameter[2] - subtract;
                                        newpar[3] = parameter[3] - subtract;
                                    }
                                    else
                                    {
                                        newpar[0] = newpar[0];
                                        newpar[1] = newpar[1];
                                        newpar[2] = newpar[2] - subtract;
                                        newpar[3] = newpar[3] - subtract;
                                    }
                                    abs.set(newpar);
                                    abs.draw(e.Graphics);
                                }
                                else
                                {
                                    MessageBox.Show("error in command");
                                }
                            }
                        }
                        //for triangle
                        if (collect[2].Equals("Triangle", StringComparison.OrdinalIgnoreCase))
                        {
                            for (int x = 0; x < Convert.ToInt32(collect[1]) - 1; x++)
                            {
                                if (collect[3].Equals("+"))
                                {
                                    int add = Convert.ToInt32(collect[4]);
                                    abstractshape abs = f.GetName("triangle");
                                    if (x == 0)
                                    {
                                        tnewpar[0] = Tparameter[0] + add;
                                        tnewpar[1] = Tparameter[1];
                                        tnewpar[2] = Tparameter[2] + add;
                                        tnewpar[3] = Tparameter[3];
                                        tnewpar[4] = Tparameter[4] + add;
                                        tnewpar[5] = Tparameter[5];
                                    }
                                    else
                                    {
                                        tnewpar[0] = tnewpar[0] + add;
                                        tnewpar[1] = tnewpar[1];
                                        tnewpar[2] = tnewpar[2] + add;
                                        tnewpar[3] = tnewpar[3];
                                        tnewpar[4] = tnewpar[4] + add;
                                        tnewpar[5] = tnewpar[5];
                                    }
                                    abs.set(tnewpar);
                                    abs.draw(e.Graphics);

                                }
                                else if (collect[3].Equals("-"))
                                {
                                    int subtract = Convert.ToInt32(collect[4]);
                                    abstractshape abs = f.GetName("triangle");
                                    if (x == 0)
                                    {
                                        tnewpar[0] = Tparameter[0] - subtract;
                                        tnewpar[1] = Tparameter[1];
                                        tnewpar[2] = Tparameter[2] - subtract;
                                        tnewpar[3] = Tparameter[3];
                                        tnewpar[4] = Tparameter[4] - subtract;
                                        tnewpar[5] = Tparameter[5];
                                    }
                                    else
                                    {
                                        tnewpar[0] = tnewpar[0] - subtract;
                                        tnewpar[1] = tnewpar[1];
                                        tnewpar[2] = tnewpar[2] - subtract;
                                        tnewpar[3] = tnewpar[3];
                                        tnewpar[4] = tnewpar[4] - subtract;
                                        tnewpar[5] = tnewpar[5];
                                    }
                                    abs.set(tnewpar);
                                    abs.draw(e.Graphics);
                                }
                                else
                                {
                                    MessageBox.Show("error in command");
                                }
                            }
                        }
                    }
                                     
                }
         
                else
                {
                    //displaying the error
                    MessageBox.Show("error");
                }

                
            }

        }
    
    }
}
