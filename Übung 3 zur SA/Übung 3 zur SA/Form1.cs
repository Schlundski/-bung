using System.Security.Cryptography.X509Certificates;

namespace Übung_3_zur_SA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Aufgabe 1 Struct und Array erstellen
        public struct Datensatz
        {
            public string name;
            public string Ort;
            public string PLZ;
            public string Telefonnummer;
        }

        public Datensatz[] Daten = new Datensatz[100];

        int indexnummer = 0;
        string path;
        private void button1_Click(object sender, EventArgs e)
        {   // Aufgabe 2 Einspeichern in Array
            indexnummer = Convert.ToInt16(textBox1.Text);
            Daten[indexnummer - 1].name = textBox2.Text;
            Daten[indexnummer - 1].Ort = textBox4.Text;
            Daten[indexnummer - 1].PLZ = textBox3.Text;
            Daten[indexnummer - 1].Telefonnummer = textBox5.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {   //Aufgabe 3 Vorblättern
            if (indexnummer != 100)
            {
                indexnummer++;
                textBox1.Text = indexnummer.ToString();
                textBox2.Text = Daten[indexnummer - 1].name;
                textBox3.Text = Daten[indexnummer - 1].PLZ;
                textBox4.Text = Daten[indexnummer - 1].Ort;
                textBox5.Text = Daten[indexnummer - 1].Telefonnummer;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {   // Aufgabe 3 Zurückblättern
            if (indexnummer != 1)
            {
                indexnummer--;
                textBox1.Text = indexnummer.ToString();
                textBox2.Text = Daten[indexnummer - 1].name;
                textBox3.Text = Daten[indexnummer - 1].PLZ;
                textBox4.Text = Daten[indexnummer - 1].Ort;
                textBox5.Text = Daten[indexnummer - 1].Telefonnummer;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Arrayinhalt in Listview anzeigen lassen

            listView1.Items.Clear();

            for (int i = 0; Daten[i].name != null; i++)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(Daten[i].name);
                item.SubItems.Add(Daten[i].PLZ);
                item.SubItems.Add(Daten[i].Ort);
                item.SubItems.Add(Daten[i].Telefonnummer);
                listView1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //Abspeichern

            if (path == null)
            {
                OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
                OpenFileDialog1.ShowDialog();
                path = OpenFileDialog1.FileName;
            }
            else
            {
                StreamWriter StreamWriter1 = new StreamWriter(path);

                for (int i = 0; Daten[i].name != null; i++)
                {
                    StreamWriter1.WriteLine(i);
                    StreamWriter1.WriteLine(Daten[i].name);
                    StreamWriter1.WriteLine(Daten[i].PLZ);
                    StreamWriter1.WriteLine(Daten[i].Ort);
                    StreamWriter1.WriteLine(Daten[i].Telefonnummer);
                }
                StreamWriter1.Close();
            }
            // Struktur ist immer indexnummer Name PLZ Ort Telefonnummer
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            // Laden

            if (path == null)
            {
                OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
                OpenFileDialog1.ShowDialog();
                path = OpenFileDialog1.FileName;
            }
            else
            {
                StreamReader StreamReader1 = new StreamReader(path);
                StreamReader1.ReadLine(); //dump, da erster Eintrag die indexnummer 1 ist
                int i = 0;
                do
                {
                    Daten[i].name = StreamReader1.ReadLine();
                    Daten[i].PLZ = StreamReader1.ReadLine();
                    Daten[i].Ort = StreamReader1.ReadLine();
                    Daten[i].Telefonnummer = StreamReader1.ReadLine();
                    i++;
                }
                while (StreamReader1.ReadLine() != null);
                StreamReader1.Close();
            }
        }
    }
}
