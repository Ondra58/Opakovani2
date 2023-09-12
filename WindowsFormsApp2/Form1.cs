using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void PoslPrvocislo(int[] pole, out int posledni, out int poradi)
        {
            posledni = 0;
            poradi = 0;
            int pocitani = 0;
            bool prvocislo = false;
            foreach(int cislo in pole)
            {
                pocitani++;
                prvocislo = false;
                if (cislo == 2)
                {
                    prvocislo = true;
                }
                else if (cislo != 1)
                {
                    for (int delitel = 2; delitel <= (int)Math.Sqrt(cislo); ++delitel)
                    {
                        if (cislo % delitel == 0)
                        {
                            prvocislo = false;
                            break;
                        }
                        else
                        {
                            prvocislo = true;
                        }
                    }
                }
                if (prvocislo)
                {
                    posledni = cislo;
                    poradi = pocitani;
                }
            }
        }
        string Maximalni(string text)
        {
            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }
            string[] pole = text.Split(' ');
            string pomocna = "";
            for (int i = 0; i < pole.Count(); i++)
            {
                if (pomocna.Length < pole[i].Length)
                {
                    pomocna = pole[i];
                }
            }
            return pomocna;
        }
        public void Vypis(int [] pole, ListBox listbox)
        {
            foreach (int cislo in pole)
            {
                listbox.Items.Add(cislo);
            }
        }
        public void Vymen(int [] pole)
        {
            int prvni = pole[0];
            int posledni = pole[pole.Count() - 1];
            pole[0] = posledni;
            pole[pole.Count() - 1] = prvni;
        }
        Random rng = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown1.Value;
            int[] pole = new int[n];
            int posledni = 0;
            int poradi = 0;
            for(int i = 0; i < n; i++)
            {
                pole[i] = rng.Next(1, 26);
            }
            Vypis(pole, listBox1);
            PoslPrvocislo(pole, out posledni, out poradi);
            if (posledni != 0)
            {
                MessageBox.Show((poradi).ToString() + ". " + posledni.ToString() );
            }
            Vymen(pole);
            Vypis(pole, listBox2);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            label1.Text = "Nejdelší slovo z textboxu: " + Maximalni(text);
        }
    }
}
