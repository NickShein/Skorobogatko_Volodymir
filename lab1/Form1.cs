using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace lab1
{
    public partial class Form1 : Form
    {
        int count = 0;
        string listbox_output = "";
        static List<string> personlist = new List<string>();
        static List<string> adresslist = new List<string>();
        static List<string> namelist = new List<string>();
        delegate void AdressHandler(string something);
        //interface IAdress
        //{
        //    void showinfo();
        //}
        class Person
        {
            string _name;
            public string _Name
            {
                get => _name;
                set => _name = value;
            }
            public Person()
            {
                _Name = "І'мя не вказано.";
            }
        }
        class Adress : Person
        {
            AdressHandler _del;
            string _adress;
            public string _Adress
            {
                get => _adress;
                set => _adress = value;
            }
            public Adress()
            {
                _Adress = "Адресу не вказано.";
            }
            public void RegisterHandler(AdressHandler del)
            {
                _del += del;
            }
            public void UnregisterHandler(AdressHandler del)
            {
                _del -= del;
            }
            public void changeAdress(string new_adress)
            {
                _Adress = new_adress;
            }
            public void adressInfo()
            {
                if (_del != null)
                    _del($"Користувач з іменем {_Name} проживає за адресою: {_Adress}");
            }
        }
        static void Show(string msg)
        {
            personlist.Add(msg);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adresslist.Add(textBox2.Text);
            namelist.Add(textBox1.Text);
            Adress p1 = new Adress();
            p1.RegisterHandler(Show);
            p1._Name = textBox1.Text;
            p1._Adress = textBox2.Text;
            p1.adressInfo();
            listBox1.Items.Add(personlist[count]);
            count++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (adresslist.Contains(textBox3.Text))
            {
                listBox1.Items.Remove($"Користувач з іменем {namelist[adresslist.IndexOf(textBox3.Text)]} проживає за адресою: {textBox3.Text}");
                listBox1.Items.Add($"Користувач з іменем {namelist[adresslist.IndexOf(textBox3.Text)]} проживає за адресою: {textBox4.Text}");
            }
        }
    }
}
