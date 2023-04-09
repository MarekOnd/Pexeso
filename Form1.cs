using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pexeso
{
    public partial class Form1 : Form
    {
        class Hrac//údaje o hráči
        {
            public int skore=0;
            public Label Jmeno = new Label();
            public Label Skore = new Label();
            public Hrac(string jmeno,int poradi)
            {
                Jmeno.Text = jmeno;
                Jmeno.Size = new Size(100, 50);
                Jmeno.Location = new Point(100,100*poradi+100);
                Jmeno.Font = new Font("Segoe UI",20);
                Skore.Text = "0";
                Skore.Size = new Size(100, 50);
                Skore.Location = new Point(100, 100 * poradi+150);
                Skore.Font = new Font("Segoe UI", 20);

            }

            public void ziskaniBodu()
            {
                skore++;
                Skore.Text = (skore).ToString();
            }
        }
        class Karta:Button//údaje o kartě
        {
            public int CisloObrazku;
            public bool Otocena;
        }
        public Form1()
        {
            InitializeComponent();
        }
        private Karta[,] pexeso = new Karta[8,8];//hrací karty v poli
        private List<Hrac> hraci = new List<Hrac>();//list hráčů
        private int index = 0;//určuje hrajícího hráče
        private int otocenaKarta;
        private bool muzeOtocit=true;//určuje jestli je možné otočit karty
        private int pocetDvojic = 32;//ukládá, kolik zbývá najít dvojic
        private void start_Click(object sender, EventArgs e)
        {
            if(pocetHracu.SelectedIndex>=0)//zapne hru pouze pokud byl zvolen počet hráčů
            {
                (sender as Button).Hide();
                label1.Hide();
                pocetHracu.Hide();
                vyberPoctuHracu.Hide();
                Michani();
                for (int i = 0; i <= pocetHracu.SelectedIndex; i++)//vytvoří daný počet hráčů
                {
                    Hrac hrac = new Hrac($"Hráč {i + 1}", i);
                    hraci.Add(hrac);
                    Controls.Add(hraci[i].Jmeno);
                    Controls.Add(hraci[i].Skore);
                }
                hraci[index % (hraci.Count)].Jmeno.BackColor = Color.Red;//zvýrazní prvního hráče na řadě
            }
            else
            {
                MessageBox.Show("Není vybrán počet hráčů");
            }
            
        }
        private async void Michani()//vytvoří hrací karty
        {
            muzeOtocit = false;
            for (int i = 0; i < 8; i++)//vytvoří karty, přidělí jim pozice a na pozadí nastaví obrázek rubu karet
            {
                for (int j = 0; j < 8; j++)
                {
                    await Task.Delay(40);//způsobí, že se karty objevují postupně
                    pexeso[i, j] = new Karta();
                    pexeso[i, j].Location = new Point(120 * j + 300, 120 * i + 100);
                    pexeso[i, j].Size = new Size(110, 110);
                    pexeso[i, j].BackgroundImage = Image.FromFile("Obrazky/PexesoRub.png");
                    var pozadi = new Bitmap(pexeso[i, j].BackgroundImage, new Size(pexeso[i, j].Width, pexeso[i, j].Height));
                    pexeso[i, j].BackgroundImage = pozadi;
                    pexeso[i, j].CisloObrazku = 0;
                    pexeso[i, j].Click += new System.EventHandler(pexeso_Click);
                    
                    Controls.Add(pexeso[i, j]);
                }
            }

            Random rnd = new Random();
            int x, y, r, g, b;
            for (int i=1;i<=32;i++)//dvojicím karet přidelí stejná čísla (odkazují na obrázky) a stejná náhodně barevná pozadí 
            {
                r = rnd.Next(0, 256);
                g = rnd.Next(0, 256);
                b = rnd.Next(0, 256);
                for (int j=0;j<2;j++)
                {
                    do
                    {
                        x = rnd.Next(0, 8);
                        y = rnd.Next(0, 8);
                    } while (pexeso[x, y].CisloObrazku != 0);
                    pexeso[x, y].CisloObrazku = i;
                    pexeso[x,y].BackColor = Color.FromArgb(r, g, b);
                }
            }
            muzeOtocit = true;
        }
        
        private async void pexeso_Click(object sender, EventArgs e)//otáčení karet
        {
            if(!(sender as Karta).Otocena && muzeOtocit)//otočit lze pouce neotočenou kartu v době, kdy je možné otáčet karty
            {
                (sender as Karta).BackgroundImage = Image.FromFile($"Obrazky/obr{(sender as Karta).CisloObrazku}.png");//nastaví obrázek jako pozadí karty
                var pozadi = new Bitmap((sender as Karta).BackgroundImage, new Size((sender as Karta).Width, (sender as Karta).Height));
                (sender as Karta).BackgroundImage = pozadi;
                (sender as Karta).Otocena = true;
                if(otocenaKarta==0)//pokud je karta otočena první, tak si ji program zapamatuje
                {
                    otocenaKarta=(sender as Karta).CisloObrazku;
                }
                else
                {
                    if (otocenaKarta == (sender as Karta).CisloObrazku)//pokud se dvě otočené karty shodují, tak se zvýší skóre hráče a karty zmizí
                    {
                        hraci[index % (hraci.Count)].ziskaniBodu();
                        muzeOtocit = false;
                        await Task.Delay(1000);//čas na prohlédnutí karet
                        muzeOtocit = true;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (pexeso[i, j].CisloObrazku == (sender as Karta).CisloObrazku)
                                {
                                    pexeso[i, j].Hide();
                                }
                            }
                        }
                        pocetDvojic--;
                        if(pocetDvojic==0)
                        {
                            KonecHry();
                        }
                        
                    }
                    else//pokud se neshodují, tak se po jedné sekundě otočí zpátky, hraje další hráč
                    {
                        muzeOtocit = false;
                        await Task.Delay(1000);//čas na prohlédnutí karet
                        muzeOtocit = true;
                        for (int i = 0; i < 8; i++)//otočí všechny otočené karty
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (pexeso[i, j].Otocena)
                                {
                                    pexeso[i, j].BackgroundImage = Image.FromFile("Obrazky/PexesoRub.png");
                                    pozadi = new Bitmap(pexeso[i, j].BackgroundImage, new Size(pexeso[i, j].Width, pexeso[i, j].Height));
                                    pexeso[i, j].BackgroundImage = pozadi;
                                    pexeso[i, j].Otocena = false;
                                }
                            }
                        }
                        DalsiHrac();
                    }
                    otocenaKarta = 0;
                }
            }
        }
        private void DalsiHrac()//zvýší index o jedna a zvýrázní hráče na tahu
        {
            hraci[index % (hraci.Count)].Jmeno.BackColor = Color.Empty;
            index++;
            hraci[index % (hraci.Count)].Jmeno.BackColor = Color.Red;
        }
        
        private void KonecHry()//zobrazí pořadí hráčů a jejich skóre
        {
            hraci[index % (hraci.Count)].Jmeno.BackColor = Color.Empty;//zruší zvýraznění posledního hráče
            hraci=hraci.OrderByDescending(hrac => hrac.skore).ToList();
            for (int i = 0; i < hraci.Count; i++)
            {
                hraci[i].Jmeno.Location = new Point(900, 50 * i + 500);
                hraci[i].Skore.Location = new Point(1020, 50 * i + 500);
            }
            konec.Show();
        }
    }
}
