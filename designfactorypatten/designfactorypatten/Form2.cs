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
    public partial class Form2 : Form
    {
        public  int counter;
        string[] onebyone = new string[100];
        public string[] collect = new string[100];


        public Form2(string[] collectline, int number)
        {
            InitializeComponent();
            counter = number;
            for(int i = 0; i < number; i++)
            {
                onebyone[i] = collectline[i];
              
            }
            MessageBox.Show(Convert.ToString(counter));
            Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            /* for (int i = 0; i <= richTextBox1.Lines.Length - 1; i++)
             {
                 char[] syntaxchar = { ' ', ';' };
                 string[] readrichbox = richTextBox1.Lines;
                 string[] collect = readrichbox[i].Split(syntaxchar);


                 if (collect[0].Equals("Draw", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("Repeat", StringComparison.OrdinalIgnoreCase))
                 {
                     if (collect[0].Equals("Draw", StringComparison.OrdinalIgnoreCase))
                     {

                         MessageBox.Show(collect[0]);
                         // Form f2 = new Form2(collect[1]);
                         //f2.Visible = true;
                         //f2.Show();
                         //Form2 f2 = new Form2();
                         shapefactory f = new shapefactory();
                         f.GetName(collect[1]);

                     }


                     if (collect[0].Equals("Repeat", StringComparison.OrdinalIgnoreCase))
                     {

                         MessageBox.Show(collect[0]);
                         MessageBox.Show(collect[1]);
                     }

                 }
                 else
                 {
                     MessageBox.Show("error");
                 }
             }
             */

            
            for(int i= 0; i < counter; i++)
            {
                char[] c = { ' ', ';' };
                string[] collect = onebyone[i].Split(c);
                if (collect[0].Equals("Draw", StringComparison.OrdinalIgnoreCase) || collect[0].Equals("Repeat", StringComparison.OrdinalIgnoreCase))
                {
                    if (collect[0].Equals("Draw", StringComparison.OrdinalIgnoreCase))
                    {

                        MessageBox.Show(collect[0]);
                        MessageBox.Show(collect[1]);
                        //shapefactory f = new shapefactory();
                        //f.GetName(collect[1]);
                        MessageBox.Show("End");
                        
                    }


                    if (collect[0].Equals("Repeat", StringComparison.OrdinalIgnoreCase))
                    {

                        
                    }

                }
                else
                {
                    MessageBox.Show("error");
                }
            }
            
           
        
        }
    }
}
