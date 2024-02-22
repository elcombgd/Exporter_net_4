using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Add MySql Library
using MySql.Data;
using MySql.Data.MySqlClient;

/*
 * Treba srediti:
 * -datetime format ne odgovara formatu koji je potreba za mysql (SREDJENO 24.10.2023. , prilikom importa se proverava da li je datetime i ako jeste formatira se u mysql datetime)
 * -dodavanje i u intersection_live da ne bi morali da resetujemo api prilikom dodavanja raskrsnice (ispravljeno, naci bolje resenje)
 * -18.01.2024. ispravljen bag sa kreiranje export fajla za da_variable_config tabelu i dodata provera da moze uspesno da se importuje da_detector_description
 * 
 * 
 * 
 * 
 * 
*/



namespace Exporter_Net4
{
    public partial class Form1 : Form
    {
        string connStr;

        public Form1()
        {
            InitializeComponent();
            loadDefaultValues();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            connStr = generateConnString();

            //string connStr = "server=192.168.1.14;user=saus_api;database=saus2_clean;port=8050;password=saus_api;";
            string fileName = "";
            string red = "";
            string sql;
            MySqlCommand cmd;
            MySqlDataReader rdr;

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                //INTERSECTION TABELA
                sql = "SELECT * FROM intersection WHERE id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fileName = rdr[1] + "-" + rdr[2] + "-" + rdr[3] + "-" + rdr[4] + ".elc";
                    red += "intersection*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                //conn.Open();


                //INTERSECTION TABELA
                sql = "SELECT * FROM intersection_live WHERE id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fileName = rdr[1] + "-" + rdr[2] + "-" + rdr[3] + "-" + rdr[4] + ".elc";
                    red += "intersection_live*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try { 
            //CONFIG_INIT
            sql = "SELECT * FROM config_init WHERE intersection_id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    red += "config_init*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                //CONFIG_LIGHTS
                sql = "SELECT * FROM config_lights WHERE intersection_id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    red += "config_lights*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                //CONFIG_CONFLICT
                sql = "SELECT * FROM config_conflict WHERE intersection_id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    red += "config_conflict*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                //CONFIG_PROGRAM
                sql = "SELECT * FROM config_program WHERE intersection_id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    red += "config_program*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                //CONFIG_TIMEOFDAY
                sql = "SELECT * FROM config_timeofday WHERE intersection_id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    red += "config_timeofday*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                //DA_ALGORITAMS_CONFIG
                sql = "SELECT * FROM da_algoritams_config WHERE intersection_id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    red += "da_algoritams_config*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                //da_detector_desc
                sql = "SELECT * FROM da_detector_desc WHERE intersection_id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    red += "da_detector_desc*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                //da_phase_config
                sql = "SELECT * FROM da_phase_config WHERE intersection_id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    red += "da_phase_config*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                //da_pif_config
                sql = "SELECT * FROM da_pif_config WHERE intersection_id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    red += "da_pif_config*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                //da_transition_config
                sql = "SELECT * FROM da_transition_config WHERE intersection_id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    red += "da_transition_config*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }
                rdr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                //da_variable_config
                sql = "SELECT * FROM da_variable_config WHERE intersection_id='" + textBox1.Text.ToString() + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    red += "da_variable_config*";
                    for (int i = 1; i < rdr.VisibleFieldCount; i++)
                    {
                        red += rdr[i].ToString().Replace("\n", "").Replace("\r", "") + "*";
                        //MessageBox.Show(rdr[i].ToString());
                    }
                    red += "\n";
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {

                StreamWriter file = new StreamWriter(fileName);
                file.WriteLine(red);
                file.Flush();
                file.Close();
                MessageBox.Show("USPESNO!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
        private void button2_Click(object sender, EventArgs e)
        {

            connStr = generateConnString();

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Elcom Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "elc",
                Filter = "elc files (*.elc)|*.elc",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //using File file = new(openFileDialog1.FileName);
                string line;
                TextReader reader = new StreamReader(openFileDialog1.FileName); 
                try
                {
                    MySqlConnection conn = new MySqlConnection(connStr);
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    long id = 0;
                    



                    while ((line = reader.ReadLine()) != null)
                    {
                        //if(line == "")
                        //{
                        string[] splitedLine = line.Split('*');
                        string insertQuery = "";

                        // Ako je polje u bazi intersection radi ovo ispod
                        if (splitedLine[0] == "intersection" || splitedLine[0] == "intersection_live")
                        {
                            if (splitedLine[0] == "intersection")
                            {
                                string sql = "SELECT * FROM intersection WHERE id1='" + splitedLine[1] + "' AND id2='" + splitedLine[2] + "' AND id3='" + splitedLine[3] + "' AND deleted='0';";
                                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                                MySqlDataReader rdr = cmd1.ExecuteReader();
                                while (rdr.Read())
                                {
                                    if (rdr.VisibleFieldCount != 0)
                                    {
                                        MessageBox.Show("Raskrsnica sa: \nID1='" + splitedLine[1] + "'\nID2='" + splitedLine[2] + "'\nID3='" + splitedLine[3] + " \nvec postoji!");

                                        return;
                                    }
                                }
                                rdr.Close();
                            }
                            insertQuery += "INSERT INTO " + splitedLine[0] + " VALUES(null, ";
                            for (int i = 1; i < splitedLine.Length - 1; i++)
                            {
                                if (splitedLine[i] == "True")
                                {
                                    splitedLine[i] = "1";
                                }
                                else if (splitedLine[i] == "False")
                                {
                                    splitedLine[i] = "0";
                                }
                                if (i == 1)
                                {
                                    insertQuery += "'" + splitedLine[i] + "'";
                                }
                                else
                                {
                                    insertQuery += ", '" + splitedLine[i] + "'";
                                }
                            }
                        }
                        else
                        {
                            if (splitedLine[0] == "da_detector_desc")
                            {
                                insertQuery += "INSERT INTO " + splitedLine[0] + " VALUES(" + id.ToString();
                                for (int i = 1; i < splitedLine.Length - 1; i++)
                                {
                                    if (splitedLine[i] == "True")
                                    {
                                        splitedLine[i] = "1";
                                    }
                                    else if (splitedLine[i] == "False")
                                    {
                                        splitedLine[i] = "0";
                                    }
                                    insertQuery += ", '" + splitedLine[i] + "'";
                                    
                                }
                            }
                            else
                            {
                                insertQuery += "INSERT INTO " + splitedLine[0] + " VALUES(null, " + id.ToString();
                                for (int i = 2; i < splitedLine.Length - 1; i++)
                                {
                                    if (splitedLine[i] == "True")
                                    {
                                        splitedLine[i] = "1";
                                    }
                                    else if (splitedLine[i] == "False")
                                    {
                                        splitedLine[i] = "0";
                                    }
                                    if (i == 1)
                                    {
                                        insertQuery += "'" + splitedLine[i] + "'";
                                    }
                                    else
                                    {
                                        //provera da li je nesto datum i ako je datum da se pakuje u mysql format
                                        DateTime dt_parse;
                                        if (DateTime.TryParse(splitedLine[i], out dt_parse))
                                        {
                                            insertQuery += ", '" + dt_parse.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                                        }
                                        else
                                        {
                                            insertQuery += ", '" + splitedLine[i] + "'";
                                        }


                                    }
                                }
                            }
                        }
                        insertQuery += splitedLine[splitedLine.Length - 1] + ");";
                        System.Diagnostics.Debug.WriteLine(insertQuery);

                        //MessageBox.Show(insertQuery);
                        MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                        //if (splitedLine[0] == "da_pif_config")
                        //{
                        //cmd.ExecuteNonQuery();
                        //}
                        if (id == 0)
                        {
                            id = cmd.LastInsertedId;
                        }


                        //}
                    }
                    MessageBox.Show("USPESNO!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                reader.Close();
            }
        }

        public string generateConnString()
        {

            string server = txtServer.Text;
            string port = txtPort.Text;
            string database = txtDatabase.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            return "server=" + server + ";user=" + username + ";database=" + database + ";port=" + port + ";password=" + password + ";";
        }

        public void loadDefaultValues()
        {
            try
            {
                // Read each line of the file into a string array. Each element
                // of the array is one line of the file.
                string[] lines = System.IO.File.ReadAllLines("defaults.txt");
                string[] param;
                foreach (string line in lines)
                {
                    if (line.Contains('#'))
                    {
                        string[] comment = line.Split('#');
                        param = comment[0].Split('=');
                    }
                    else
                    {
                        param = line.Split('=');
                    }
                    switch (param[0].Trim())
                    {
                        case "server":
                            txtServer.Text = param[1].Trim();
                            break;
                        case "port":
                            txtPort.Text = param[1].Trim();
                            break;
                        case "database":
                            txtDatabase.Text = param[1].Trim();
                            break;
                        case "username":
                            txtUsername.Text = param[1].Trim();
                            break;
                        case "password":
                            txtPassword.Text = param[1].Trim();
                            break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ne postoji defaults.txt fajl.");
            }
        }

    }
}
