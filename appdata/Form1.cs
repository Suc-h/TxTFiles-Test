using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appdata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int CZK(int plat)
        {
            //22,35
            //17 300 
            double czk =plat * 22.35;
            return (int)Math.Round(czk);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] pole;
            string nejvetsi="a";
            int vek=0;
            int czpenize=0;
            double prumer;
            int mzda = 0;
            short help = 0;
            short zeny=0;
            string radek;

            OpenFileDialog d = new OpenFileDialog();
            d.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            if(d.ShowDialog()==DialogResult.OK)
            {
                
                StreamReader ctenar = new StreamReader(d.FileName,Encoding.GetEncoding("windows-1250"));
                StreamWriter zapis = new StreamWriter("best.txt",false);
                for (;help < 100; help++)
                {
                    radek = ctenar.ReadLine();
                    pole = radek.Split(',');


                    if(Convert.ToInt32(pole[4])>mzda)
                    {
                        mzda = Convert.ToInt32(pole[4]);
                        nejvetsi = radek;
                        
                        
                        
                     }

                    vek = vek + Convert.ToInt32(pole[3]);


                    if (pole[2] == "Female")
                    {
                        zeny++;
                    }


                    if(Convert.ToInt32(pole[4])>0)
                    {
                        pole[4]=Convert.ToString(CZK(Convert.ToInt32(pole[4])));
                        if (Convert.ToInt32(pole[4]) < 17300)
                        {
                            listBox1.Items.Add(radek+" v korunách:" + pole[4]);
                        }
                        if(radek==nejvetsi)
                        {
                            czpenize = Convert.ToInt32(pole[4]);
                        }
                    }

                    
                }
                label1.Text = "Vygenerováno bylo: "+ zeny.ToString() + " žen"; //MessageBox.Show("Vygenerováno bylo: "+ zeny.ToString() + " žen")
                prumer = vek / help;
                
                zapis.WriteLine(nejvetsi+" v korunách:" +czpenize);
                zapis.WriteLine("Průměrný věk je:" + prumer); // zaokrouhleno
                zapis.Close();
                ctenar.Close();



            }
        }
    }
}
