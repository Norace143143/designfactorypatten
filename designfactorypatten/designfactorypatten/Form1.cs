using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public int[] cab = new int[10];
        public int[] recpar = new int[2];
        public int[] cirpar = new int[2];
        public int[] tripar = new int[4];
        public int counter = 0, width = 0, height = 0, radius1 = 0, p = 0, h = 0, ifcounter = 0;
        int n = -1;
        int m = -1;
        bool moving = false;
        Pen pn;
        public string rec = null;
        //drawing object
        Graphics g;
        //instance of shapefactory 
        shapefactory f = new shapefactory();
        //instance of hashtable 
        Hashtable hs = new Hashtable();
        //constructor 
        public Form1()
        {
            InitializeComponent();
            //creating the canvas panel2
            g = panel2.CreateGraphics();
            //making line smooth
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pn = new Pen(Color.Black, 3);
            //panel2 is hide
            panel1.Hide();
            //making pen round at start and end
            pn.StartCap = pn.EndCap = System.Drawing.Drawing2D.LineCap.Round;
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

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            panel2.Invalidate();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Stream myStream = null;//instantiating null value for stra
            OpenFileDialog openFileDialog1 = new OpenFileDialog();//creating a instance of a dialog box
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; //creting text form
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)//if choose data is fine then enter todialog box
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null) //if the choosen file is not empty then the file is read
                    {
                        using (myStream) //dispose is done automatically
                        {
                            richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);//loading text file in textbox
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            panel1.Show();

        }
        //additional feature
        //this method is calling picture box
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pn.Color = p.BackColor;
        }
        //event when mouse is clicked 
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            n = e.X;
            m = e.Y;
            panel2.Cursor = Cursors.Cross;
        }
        //event when mouse is moving
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && n!=-1 && m != -1)
            {
                g.DrawLine(pn, new Point(n, m), e.Location);
                n = e.X;
                m = e.Y;
                
            }
        }
        //event when mouse is not clicked 
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            n = -1;
            m = -1;
            panel2.Cursor = Cursors.Default;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();//creating a instance of a dialog box
            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; //creting text form
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)//if choose data is fine then enter todialog box
            {
                try
                {

                    using (StreamWriter write = new StreamWriter(sfd.FileName)) //dispose is done automatically
                    {
                        await write.WriteLineAsync(richTextBox1.Text);//loading text file in textbox
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

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
                   collect[0].Equals("Circle", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("var", StringComparison.OrdinalIgnoreCase) ||
                   collect[0].Equals("loop", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("Rec", StringComparison.OrdinalIgnoreCase) ||
                   collect[0].Equals("width", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("height", StringComparison.OrdinalIgnoreCase) ||
                   collect[0].Equals("endloop", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("cir", StringComparison.OrdinalIgnoreCase) ||
                   collect[0].Equals("radius", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("tri", StringComparison.OrdinalIgnoreCase) ||
                   collect[0].Equals("p", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("h", StringComparison.OrdinalIgnoreCase) ||
                   collect[0].Equals("if") || collect[0].Equals("endIf", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("IF")||
                   collect[0].Equals("POLYGON", StringComparison.OrdinalIgnoreCase))
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
                        //try and catch block
                        try
                        {
                            cab[0] = Convert.ToInt32(hs[collect[1]]);
                            cab[1] = Convert.ToInt32(hs[collect[2]]);
                            
                        }
                        catch
                        {
                            cab[0] = Convert.ToInt32(collect[1]);
                            cab[1] = Convert.ToInt32(collect[2]);
                        }
                        //try and catch block
                        try
                        {
                            cab[0] = Convert.ToInt32(collect[1]);
                            cab[1] = Convert.ToInt32(collect[2]);
                        }
                        catch
                        {
                            cab[0] = Convert.ToInt32(hs[collect[1]]);
                            cab[1] = Convert.ToInt32(hs[collect[2]]);
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

                    //for polygon command
                    if (collect[0].Equals("POLYGON", StringComparison.OrdinalIgnoreCase))
                    {
                        abstractshape abs = f.GetName("POLYGON");

                        try
                        {
                            cab[2] = Convert.ToInt32(hs[collect[1]]);
                            cab[3] = Convert.ToInt32(hs[collect[2]]);
                            cab[4] = Convert.ToInt32(hs[collect[3]]);
                            cab[5] = Convert.ToInt32(hs[collect[4]]);
                            cab[6] = Convert.ToInt32(hs[collect[5]]);
                            cab[7] = Convert.ToInt32(hs[collect[6]]);
                            cab[8] = Convert.ToInt32(hs[collect[7]]);
                            cab[9] = Convert.ToInt32(hs[collect[8]]);
                        }

                        catch
                        {
                            cab[2] = Convert.ToInt32(collect[1]);
                            cab[3] = Convert.ToInt32(collect[2]);
                            cab[4] = Convert.ToInt32(collect[3]);
                            cab[5] = Convert.ToInt32(collect[4]);
                            cab[6] = Convert.ToInt32(collect[5]);
                            cab[7] = Convert.ToInt32(collect[6]);
                            cab[8] = Convert.ToInt32(collect[7]);
                            cab[9] = Convert.ToInt32(collect[8]);
                        }

                        try
                        {
                            cab[2] = Convert.ToInt32(collect[1]);
                            cab[3] = Convert.ToInt32(collect[2]);
                            cab[4] = Convert.ToInt32(collect[3]);
                            cab[5] = Convert.ToInt32(collect[4]);
                            cab[6] = Convert.ToInt32(collect[5]);
                            cab[7] = Convert.ToInt32(collect[6]);
                            cab[8] = Convert.ToInt32(collect[7]);
                            cab[9] = Convert.ToInt32(collect[8]);
                        }
                        catch
                        {
                            cab[2] = Convert.ToInt32(hs[collect[1]]);
                            cab[3] = Convert.ToInt32(hs[collect[2]]);
                            cab[4] = Convert.ToInt32(hs[collect[3]]);
                            cab[5] = Convert.ToInt32(hs[collect[4]]);
                            cab[6] = Convert.ToInt32(hs[collect[5]]);
                            cab[7] = Convert.ToInt32(hs[collect[6]]);
                            cab[8] = Convert.ToInt32(hs[collect[7]]);
                            cab[9] = Convert.ToInt32(hs[collect[8]]);
                        }


                        abs.set(cab);
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
                    if (collect[0].Equals("Repeat", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("loop", StringComparison.OrdinalIgnoreCase))
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

                    //loop command
                    if (collect[0].Equals("loop", StringComparison.OrdinalIgnoreCase))
                    {
                        counter = Convert.ToInt32(collect[1]);
                    }
                    //loop command for rectangle 
                    if (collect[0].Equals("Rec", StringComparison.OrdinalIgnoreCase))
                    {
                        rec = "Rectangle";
                        recpar[0] = Convert.ToInt32(collect[1]);
                        recpar[1] = Convert.ToInt32(collect[2]);

                    }
                    //loop command for circle
                    if (collect[0].Equals("cir", StringComparison.OrdinalIgnoreCase))
                    {
                        rec = "Circle";
                        cirpar[0] = Convert.ToInt32(collect[1]);
                        cirpar[1] = Convert.ToInt32(collect[2]);

                    }
                    //loop command for triangle
                    if (collect[0].Equals("tri", StringComparison.OrdinalIgnoreCase))
                    {
                        rec = "Triangle";
                        tripar[0] = Convert.ToInt32(collect[1]);
                        tripar[1] = Convert.ToInt32(collect[2]);
                        tripar[2] = Convert.ToInt32(collect[3]);
                        tripar[3] = Convert.ToInt32(collect[4]);

                    }
                    //collecting width
                    if (collect[0].Equals("width", StringComparison.OrdinalIgnoreCase))
                    {
                        width = Convert.ToInt32(collect[2]);

                    }
                    //collecting height
                    if (collect[0].Equals("height", StringComparison.OrdinalIgnoreCase))
                    {
                        height = Convert.ToInt32(collect[2]);

                    }
                    //collecting radius
                    if (collect[0].Equals("radius", StringComparison.OrdinalIgnoreCase))
                    {
                        radius1 = Convert.ToInt32(collect[2]);

                    }
                    //collecting base 
                    if (collect[0].Equals("p", StringComparison.OrdinalIgnoreCase))
                    {
                        p = Convert.ToInt32(collect[2]);

                    }
                    //collecting hypotenuse 
                    if (collect[0].Equals("h", StringComparison.OrdinalIgnoreCase))
                    {
                        h = Convert.ToInt32(collect[2]);

                    }

                    if (collect[0].Equals("endloop", StringComparison.OrdinalIgnoreCase))
                    {
                        //checking rec
                        if (rec.Equals("Rectangle", StringComparison.OrdinalIgnoreCase))

                        {
                            for (int y = 0; y < counter; y++)
                            {
                                //intance of abstract class
                                abstractshape abs = f.GetName("Rectangle");
                                if (y == 0)
                                {
                                    parameter[2] = recpar[0] + width;
                                    parameter[3] = recpar[1] + height;

                                }
                                else
                                {
                                    parameter[2] = parameter[2] + width;
                                    parameter[3] = parameter[3] + height;

                                }
                                abs.set(parameter);
                                abs.draw(e.Graphics);
                            }
                        }

                        //checking cir
                        if (rec.Equals("Circle", StringComparison.OrdinalIgnoreCase))

                        {

                            for (int y = 0; y < counter; y++)
                            {
                                MessageBox.Show("inside loop");
                                //intance of abstract class
                                abstractshape abs = f.GetName("Circle");
                                if (y == 0)
                                {
                                    parameter[2] = cirpar[0] + radius1;
                                    parameter[3] = cirpar[1] + radius1;
                                }
                                else
                                {
                                    parameter[2] = parameter[2] + radius1;
                                    parameter[3] = parameter[3] + radius1;
                                }
                                abs.set(parameter);
                                abs.draw(e.Graphics);
                            }
                        }
                        //checking for tri
                        if (rec.Equals("Triangle", StringComparison.OrdinalIgnoreCase))

                        {

                            for (int y = 0; y < counter; y++)
                            {
                                MessageBox.Show("inside loop");
                                //intance of abstract class
                                abstractshape abs = f.GetName("Triangle");
                                if (y == 0)
                                {
                                    Tparameter[2] = tripar[0] + p;
                                    Tparameter[3] = tripar[1] + p;
                                    Tparameter[4] = tripar[2] + h;
                                    Tparameter[5] = tripar[3] + h;
                                }
                                else
                                {
                                    Tparameter[2] = Tparameter[2] + p;
                                    Tparameter[3] = Tparameter[3] + p;
                                    Tparameter[4] = Tparameter[4] + h;
                                    Tparameter[5] = Tparameter[5] + h;
                                }
                                abs.set(Tparameter);
                                abs.draw(e.Graphics);
                            }
                        }

                    }

                    //for simple if command
                    if (collect[0].Equals("if"))
                    {

                        if (counter == Convert.ToInt32(collect[3]))
                        {
                            if (collect[5].Equals("radius", StringComparison.OrdinalIgnoreCase))
                            {
                                radius1 = Convert.ToInt32(collect[7]);

                            }

                            if (collect[5].Equals("width", StringComparison.OrdinalIgnoreCase))
                            {
                                width = Convert.ToInt32(collect[7]);

                            }

                            if (collect[5].Equals("height", StringComparison.OrdinalIgnoreCase))
                            {
                                height = Convert.ToInt32(collect[7]);

                            }

                        }
                    }




                    //if full  command
                    if (collect[0].Equals("IF"))
                    {
                        ifcounter = Convert.ToInt32(collect[3]);
                    }

                    if (collect[0].Equals("endIf", StringComparison.OrdinalIgnoreCase))
                    {
                        if (counter == ifcounter)
                        {
                            //checking rec
                            if (rec.Equals("Rectangle", StringComparison.OrdinalIgnoreCase))

                            {

                                for (int y = 0; y < counter; y++)
                                {
                                    MessageBox.Show("inside loop");
                                    //intance of abstract class
                                    abstractshape abs = f.GetName("Rectangle");
                                    if (y == 0)
                                    {
                                        parameter[2] = recpar[0] + width;
                                        parameter[3] = recpar[1] + height;

                                    }
                                    else
                                    {
                                        parameter[2] = parameter[2] + width;
                                        parameter[3] = parameter[3] + height;

                                    }
                                    abs.set(parameter);
                                    abs.draw(e.Graphics);
                                }
                            }

                            //checking cir
                            if (rec.Equals("Circle", StringComparison.OrdinalIgnoreCase))

                            {

                                for (int y = 0; y < counter; y++)
                                {
                                    MessageBox.Show("inside loop");
                                    //intance of abstract class
                                    abstractshape abs = f.GetName("Circle");
                                    if (y == 0)
                                    {
                                        parameter[2] = cirpar[0] + radius1;
                                        parameter[3] = cirpar[1] + radius1;
                                    }
                                    else
                                    {
                                        parameter[2] = parameter[2] + radius1;
                                        parameter[3] = parameter[3] + radius1;
                                    }
                                    abs.set(parameter);
                                    abs.draw(e.Graphics);
                                }
                            }

                        }
                    }


                }


                else
                {
                    throw new errorhandle();
                }



            }
        }
    
    }
}
