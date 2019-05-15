//using SqlConnection.DatabaseShit.Entiteiten;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BankOfBrabant.Models;

namespace SqlConnection.DatabaseShit
{
    class SQLManager
    {

        /// <summary>
        /// The single instance of the SQLManager
        /// </summary>
        public static SQLManager Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Method to initialize the sql manager
        /// </summary>
        /// <returns> the only instance of SQLManager</returns>
        public static SQLManager Initialize(string serverIp, string port, string databaseName, string userName, string password)
        {
            //check if the instance isn't initialized
            if (Instance == null)
                //no it's not initialized so initialize it now
                Instance = new SQLManager(serverIp, port, databaseName, userName, password);
            //return the instance of SQLManager
            return Instance;
        }

        //Connection string to connect to the database without parameters
        private const string connectionStringFormat = "Server={0};Port={1};Database={2};Uid={3};Pwd={4};";
        //The mysql object to connect to the database
        private MySqlConnection mySqlConnection;


        //QUERIES

        //Klanten 
        private const string QRY_CreateKlant = "insert into Klanten(Voornaam, Tussenvoegsel, Achternaam, Email, Adres, Geslacht, KVKNummer, BKRPositief, Blacklisted, PaspoortCheck) values(@Voornaam, @Tussenvoegsel, @Achternaam, @Email, @Adres, @Geslacht, @KVKNummer, @BKRPositief, @Blacklisted, @PaspoortCheck); SELECT LAST_INSERT_ID();";
        private const string QRY_UpdateKlantByID = "update Klanten set Voornaam = @Voornaam, Tussenvoegsel = @Tussenvoegsel, Achternaam = @Achternaam, Email = @Email, Adres = @Adres, Geslacht = @Geslacht, KVKNummer = @KVKNummer, BKRPositief = @BKRPositief, Blacklisted = @Blacklisted, PaspoortCheck = @PaspoortCheck where ID = @ID;";
        private const string QRY_ReadAllFromKlanten = "select * from Klanten;";
        private const string QRY_ReadKlantByID = "select * from Klanten where ID = @ID;";
        private const string QRY_DeleteKlantByID = "delete from klanten where ID = @ID;";
        //@TODO search on name
        //@TODO search on lastname
        //@TODO search on adress
        //@TODO search on email
        //@TODO search on accountnumber
        //@TODO search on kvk nummer

        //Medewerkers
        private const string QRY_CreateMedewerker = "insert into Medewerkers(Voornaam, Tussenvoegsel, Achternaam, Email, Adres, Geslacht) values(@Voornaam, @Tussenvoegsel, @Achternaam, @Email, @Adres, @Geslacht); SELECT LAST_INSERT_ID();";
        private const string QRY_UpdateMedewerker = "update Medewerkers set Voornaam = @Voornaam, Tussenvoegsel = @Tussenvoegsel, Achternaam = @Achternaam, Email = @Email, Adres = @Adres, Geslacht = @Geslacht where ID = @ID;";
        private const string QRY_ReadAllFromMedewerkers = "select * from Medewerkers";
        private const string QRY_ReadMedewerkerByID = "select * from Medewerkers where ID = @ID;";
        private const string QRY_DeleteMedewerkerByID = "delete from Medewerkers where ID = @ID;";
        //@TODO search on name
        //@TODO search on lastname
        //@TODO search on adress
        //@TODO search on email

        //Rekeningen
        private const string QRY_CreateRekening = "insert into Rekeningen(RekeningNummer, RekeningType, Saldo, RentePercentage, RekeningNaam, PassNummer, PinCode) values(@RekeningNummer, @RekeningType, @Saldo, @RentePercentage, @RekeningNaam, @PassNumber, @PinCode); SELECT LAST_INSERT_ID();";
        private const string QRY_UpdateRekening = "update Rekeningen set RekeningType = @RekeningType, Saldo = @Saldo, RentePercentage = @RentePercentage where ID = @ID;";
        private const string QRY_ReadAllFromRekeningen = "select * from Rekeningen;";
        private const string QRY_ReadRekeningByID = "select * from Rekeningen where ID = @ID;";
        private const string QRY_DeleteRekeningByID = "delete from Rekeningen where ID = @ID;";
        private const string QRY_ReadRekeningByPassNumber = "select * from Rekeningen where PassNummer = @PassNumber;";

        //RekeningBevoegde
        private const string QRY_CreateRekeningBevoegde = "insert into RekeningBevoegdes(KlantID, RekeningID, Relatie) values (@KlantID, @RekeningID, @Relatie);";
        private const string QRY_UpdateRekeningBevoegde = "update RekeningBevoegdes set Relatie = @Relatie where KlantID = @KlantID and RekeningID = @RekeningID;";
        private const string QRY_ReadAllFromRekeningBevoegde = "select * from RekeningBevoegdes;";
        private const string QRY_ReadRekeningBevoegdeByKlantIDAndRekeningID = "select * from RekeningBevoegdes where KlantID = @KlantID and RekeningID = @RekeningID;";
        private const string QRY_ReadRekeningBevoegdeByKlantID = "select * from RekeningBevoegdes where KlantID = @KlantID;";
        private const string QRY_ReadRekeningBevoegdeByRekeningID = "select * from RekeningBevoegdes where RekeningID = @RekeningID;";
        private const string QRY_DeleteRekeningBevoegde = "delete RekeningBevoegdes where RekeningID = @RekeningID and KlantID = @KlantID;";
        //@TODO maby an update qry needed to save changes, or is it a new relation?

         //Transacties
        private const string QRY_CreateTransactie = "insert into Transacties(Verstuurder, Ontvanger, Euros, Datum) values (@Verstuurder, @Ontvanger, @Euros, @Relatie);";
        private const string QRY_ReadAllFromTransacties = "select * from transacties";
        //@TODO maby an update qry needed to save changes, or is it a new relation?
        
        //Private constructor so the class is not initialized outside of this class
        private SQLManager(string serverIp, string port, string databaseName, string userName, string password)
        {
            //create the connection string with the given parameters
            string connectionString = string.Format(connectionStringFormat, serverIp, port, databaseName, userName, password);
            //initialize the connection object
            mySqlConnection = new MySqlConnection(connectionString);
        }

        public ulong CreateKlant(Klant klant)
        {
            return CreateKlant(klant.Voornaam, klant.Tussenvoegsel, klant.Achternaam, klant.Email, klant.Adres, klant.Geslacht, klant.KvkNummer, klant.BKRPositief, klant.Blacklisted, klant.PaspoortCheck);
        }

        public ulong CreateKlant(string voornaam, string tussenvoegsel, string achternaam, string email, string adres, Geslachten geslacht, string kvknummer, bool bkrPositief, bool blacklisted, bool paspoortCheck)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_CreateKlant;
            command.Parameters.AddWithValue("@Voornaam", voornaam);
            command.Parameters.AddWithValue("@Tussenvoegsel", tussenvoegsel);
            command.Parameters.AddWithValue("@Achternaam", achternaam);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Adres", adres);
            command.Parameters.AddWithValue("@Geslacht", (sbyte)(byte)geslacht);
            command.Parameters.AddWithValue("@KVKNummer", kvknummer);
            command.Parameters.AddWithValue("@BKRPositief", bkrPositief);
            command.Parameters.AddWithValue("@Blacklisted", blacklisted);
            command.Parameters.AddWithValue("@PaspoortCheck", paspoortCheck);

            MySqlDataReader reader = command.ExecuteReader();

            ulong id = ulong.MaxValue;

            if (reader.Read())
                id = reader.GetUInt64(0);

            command.Dispose();
            mySqlConnection.Close();

            return id;
        }

        public void UpdateKlant(Klant klant)
        {
            UpdateKlant(klant.ID, klant.Voornaam, klant.Tussenvoegsel, klant.Achternaam, klant.Email, klant.Adres, klant.Geslacht, klant.KvkNummer, klant.BKRPositief, klant.Blacklisted, klant.PaspoortCheck);
        }

        public void UpdateKlant(ulong id, string voornaam, string tussenvoegsel, string achternaam, string email, string adres, Geslachten geslacht, string kvknummer, bool bkrPositief, bool blacklisted, bool paspoortCheck)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_UpdateKlantByID;
            command.Parameters.AddWithValue("@Voornaam", voornaam);
            command.Parameters.AddWithValue("@Tussenvoegsel", tussenvoegsel);
            command.Parameters.AddWithValue("@Achternaam", achternaam);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Adres", adres);
            command.Parameters.AddWithValue("@Geslacht", (sbyte)(byte)geslacht);
            command.Parameters.AddWithValue("@KVKNummer", kvknummer);
            command.Parameters.AddWithValue("@BKRPositief", bkrPositief);
            command.Parameters.AddWithValue("@Blacklisted", blacklisted);
            command.Parameters.AddWithValue("@PaspoortCheck", paspoortCheck);
            command.Parameters.AddWithValue("@ID", id);

            command.ExecuteNonQuery();
            command.Dispose();
            mySqlConnection.Close();
        }

        public Klant[] ReadAllFromKlanten()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(QRY_ReadAllFromKlanten, mySqlConnection);
            adapter.Fill(table);

            Klant[] klanten = new Klant[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++)
                klanten[i] = new Klant(table.Rows[i]);

            return klanten;
        }

        public Klant ReadKlantById(ulong id)
        {
            DataTable table = new DataTable();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_ReadKlantByID;
            command.Parameters.AddWithValue("@ID", id);


            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);

            if (table.Rows.Count < 1)
                return null;

            Klant klant = new Klant(table.Rows[0]);

            command.Dispose();

            return klant;
        }

        public void DeleteKlantByID(ulong id)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_DeleteKlantByID;
            command.Parameters.AddWithValue("@ID", id);

            command.ExecuteNonQuery();
            command.Dispose();
            mySqlConnection.Close();
        }

        public ulong CreateMedewerker(Medewerker medewerker)
        {
            return CreateMedewerker(medewerker.Voornaam, medewerker.Tussenvoegsel, medewerker.Achternaam, medewerker.Email, medewerker.Adres, medewerker.Geslacht);
        }

        public ulong CreateMedewerker(string voornaam, string tussenvoegsel, string achternaam, string email, string adres, Geslachten geslacht)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_CreateMedewerker;
            command.Parameters.AddWithValue("@Voornaam", voornaam);
            command.Parameters.AddWithValue("@Tussenvoegsel", tussenvoegsel);
            command.Parameters.AddWithValue("@Achternaam", achternaam);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Adres", adres);
            command.Parameters.AddWithValue("@Geslacht", (sbyte)(byte)geslacht);

            MySqlDataReader reader = command.ExecuteReader();

            ulong id = ulong.MaxValue;

            if (reader.Read())
                id = reader.GetUInt64(0);

            command.Dispose();
            mySqlConnection.Close();

            return id;
        }

        public void UpdateMedewerker(Medewerker medewerker)
        {
            UpdateMedewerker(medewerker.ID, medewerker.Voornaam, medewerker.Tussenvoegsel, medewerker.Achternaam, medewerker.Email, medewerker.Adres, medewerker.Geslacht);
        }

        public void UpdateMedewerker(ulong id, string voornaam, string tussenvoegsel, string achternaam, string email, string adres, Geslachten geslacht)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_UpdateMedewerker;
            command.Parameters.AddWithValue("@Voornaam", voornaam);
            command.Parameters.AddWithValue("@Tussenvoegsel", tussenvoegsel);
            command.Parameters.AddWithValue("@Achternaam", achternaam);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Adres", adres);
            command.Parameters.AddWithValue("@Geslacht", (sbyte)(byte)geslacht);
            command.Parameters.AddWithValue("@ID", id);

            command.ExecuteNonQuery();
            command.Dispose();
            mySqlConnection.Close();
        }

        public Medewerker[] ReadAllFromMedewerkers()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(QRY_ReadAllFromMedewerkers, mySqlConnection);
            adapter.Fill(table);

            Medewerker[] medewerkers = new Medewerker[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++)
                medewerkers[i] = new Medewerker(table.Rows[i]);

            return medewerkers;
        }

        public Medewerker ReadMedewerkerByID(ulong id)

        {
            DataTable table = new DataTable();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_ReadMedewerkerByID;
            command.Parameters.AddWithValue("@ID", id);


            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);

            if (table.Rows.Count < 1)
                return null;

            Medewerker medewerker = new Medewerker(table.Rows[0]);

            command.Dispose();

            return medewerker;
        }

        public void DeleteMedewerkerByID(ulong id)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_DeleteMedewerkerByID;
            command.Parameters.AddWithValue("@ID", id);

            command.ExecuteNonQuery();
            command.Dispose();
            mySqlConnection.Close();
        }

        public ulong CreateRekening(Rekening rekening)
        {
            return CreateRekening(rekening.Nummer, rekening.Type.ToString() , rekening.Saldo, rekening.RentePercentage, rekening.RekeningNaam, rekening.PassNumber, rekening.PinCode);
        }

        public ulong CreateRekening(string nummer, string rekeningType, decimal saldo, float rentePercentage, string accountName, int passNumber, int pinCode)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_CreateRekening;
            command.Parameters.AddWithValue("@RekeningNummer", nummer);
            command.Parameters.AddWithValue("@RekeningType", rekeningType);
            command.Parameters.AddWithValue("@Saldo", saldo);
            command.Parameters.AddWithValue("@RentePercentage", rentePercentage);
            command.Parameters.AddWithValue("@RekeningNaam", accountName);
            command.Parameters.AddWithValue("@PassNumber", passNumber);
            command.Parameters.AddWithValue("@PinCode", pinCode);

            MySqlDataReader reader = command.ExecuteReader();

            ulong id = ulong.MaxValue;

            if (reader.Read())
                id = reader.GetUInt64(0);

            command.Dispose();
            mySqlConnection.Close();

            return id;
        }

        public void UpdateRekening(Rekening rekening)
          {
               UpdateRekening(rekening.Nummer, rekening.Type.ToString(), rekening.Saldo, rekening.RentePercentage, rekening.RekeningNaam, rekening.PassNumber, rekening.PinCode);
          }

        public void UpdateRekening(string nummer, string rekeningType, decimal saldo, float rentePercentage, string accountName, int passNumber, int pinCode)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_UpdateRekening;
            command.Parameters.AddWithValue("@RekeningNummer", nummer);
            command.Parameters.AddWithValue("@RekeningType", rekeningType);
            command.Parameters.AddWithValue("@Saldo", saldo);
            command.Parameters.AddWithValue("@RentePercentage", rentePercentage);
            command.Parameters.AddWithValue("@RekeningNaam", accountName);
            command.Parameters.AddWithValue("@PassNumber", passNumber);
            command.Parameters.AddWithValue("@PinCode", pinCode);

            command.ExecuteNonQuery();
            command.Dispose();
            mySqlConnection.Close();
        }
        
        public Rekening[] ReadAllFromRekeningen()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(QRY_ReadAllFromRekeningen, mySqlConnection);
            adapter.Fill(table);

            Rekening[] rekeningen = new Rekening[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++)
                rekeningen[i] = new Rekening(table.Rows[i]);

            return rekeningen;
        }

        public Rekening[] ReadRekeningByPassNumber(int passNumber)
        {
            DataTable table = new DataTable();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_ReadRekeningByPassNumber;
            command.Parameters.AddWithValue("@PassNumber", passNumber);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);

            if (table.Rows.Count < 1)
                return null;

            Rekening[] rekeningen = new Rekening[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++)
                rekeningen[i] = new Rekening(table.Rows[i]);

            command.Dispose();

            return rekeningen;
        }

        public Rekening ReadRekeningByID(ulong id)

        {
            DataTable table = new DataTable();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_ReadRekeningByID;
            command.Parameters.AddWithValue("@ID", id);


            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);

            if (table.Rows.Count < 1)
                return null;

            Rekening rekening = new Rekening(table.Rows[0]);

            command.Dispose();

            return rekening;
        }

        public void DeleteRekeningByID(ulong id)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_DeleteRekeningByID;
            command.Parameters.AddWithValue("@ID", id);

            command.ExecuteNonQuery();
            command.Dispose();
            mySqlConnection.Close();
        }


        public ulong CreateRekeningBevoegde(RekeningBevoegde rekeningBevoegde)
        {
            return CreateRekeningBevoegde(rekeningBevoegde.KlantID, rekeningBevoegde.RekeningID, rekeningBevoegde.Relatie);
        }

        public ulong CreateRekeningBevoegde(ulong klantID, ulong rekeningID, RekeningRelaties relatie)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_CreateRekeningBevoegde;
            command.Parameters.AddWithValue("@KlantID", klantID);
            command.Parameters.AddWithValue("@RekeningID", rekeningID);
            command.Parameters.AddWithValue("@Relatie", (sbyte)(byte)relatie);

            MySqlDataReader reader = command.ExecuteReader();

            ulong id = ulong.MaxValue;

            if (reader.Read())
                id = reader.GetUInt64(0);

            command.Dispose();
            mySqlConnection.Close();

            return id;
        }

        public void UpdateRekeningBevoegde(RekeningBevoegde rekeningBevoegde)
        {
            UpdateRekeningBevoegde(rekeningBevoegde.KlantID, rekeningBevoegde.RekeningID, rekeningBevoegde.Relatie);
        }

        public void UpdateRekeningBevoegde(ulong klantID, ulong rekeningID, RekeningRelaties relatie)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_UpdateRekeningBevoegde;
            command.Parameters.AddWithValue("@Relatie", (sbyte)(byte)relatie);
            command.Parameters.AddWithValue("@KlantID", klantID);
            command.Parameters.AddWithValue("@RekeningID", rekeningID);

            command.ExecuteNonQuery();
            command.Dispose();
            mySqlConnection.Close();
        }

        public RekeningBevoegde[] ReadAllFromRekeningBevoegdes()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(QRY_ReadAllFromRekeningBevoegde, mySqlConnection);
            adapter.Fill(table);

            RekeningBevoegde[] rekeningBevoegdes = new RekeningBevoegde[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++)
                rekeningBevoegdes[i] = new RekeningBevoegde(table.Rows[i]);

            return rekeningBevoegdes;
        }

        public RekeningBevoegde[] ReadRekeningBevoegdesByKlantID(ulong klantID)
        {
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand(QRY_ReadRekeningBevoegdeByKlantID, mySqlConnection);
            command.Parameters.AddWithValue("@KlantID", klantID);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);

            RekeningBevoegde[] rekeningBevoegdes = new RekeningBevoegde[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++)
                rekeningBevoegdes[i] = new RekeningBevoegde(table.Rows[i]);

            return rekeningBevoegdes;
        }

        public RekeningBevoegde[] ReadRekeningBevoegdesByRekeningID(ulong rekeningID)
        {
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand(QRY_ReadRekeningBevoegdeByRekeningID, mySqlConnection);
            command.Parameters.AddWithValue("@RekeningID", rekeningID);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);

            RekeningBevoegde[] rekeningBevoegdes = new RekeningBevoegde[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++)
                rekeningBevoegdes[i] = new RekeningBevoegde(table.Rows[i]);

            return rekeningBevoegdes;
        }

        public RekeningBevoegde ReadRekeningBevoegdesByKlantIDAndRekeningID(ulong klantID, ulong rekeningID)
        {
            DataTable table = new DataTable();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_ReadRekeningBevoegdeByKlantIDAndRekeningID;
            command.Parameters.AddWithValue("@KlantID", klantID);
            command.Parameters.AddWithValue("@RekeningID", rekeningID);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);

            if (table.Rows.Count < 1)
                return null;

            RekeningBevoegde rekeningBevoegde = new RekeningBevoegde(table.Rows[0]);

            command.Dispose();

            return rekeningBevoegde;
        }

        public void DeleteRekeningBevoegde(ulong klantID, ulong rekeningID)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_DeleteRekeningBevoegde;
            command.Parameters.AddWithValue("@KlantID", klantID);
            command.Parameters.AddWithValue("@RekeningID", rekeningID);

            command.ExecuteNonQuery();
            command.Dispose();
            mySqlConnection.Close();
        }
        
        public ulong CreateTransactie(string verstuurder, string ontvanger, double euros, DateTime datum)
        {
            mySqlConnection.Open();
            MySqlCommand command = mySqlConnection.CreateCommand();

            command.CommandText = QRY_CreateTransactie;
            command.Parameters.AddWithValue("@Verstuurder", verstuurder);
            command.Parameters.AddWithValue("@Ontvanger", ontvanger);
            command.Parameters.AddWithValue("@Euros", euros);
            command.Parameters.AddWithValue("@Datum", datum);

            MySqlDataReader reader = command.ExecuteReader();

            ulong id = ulong.MaxValue;

            if (reader.Read())
                id = reader.GetUInt64(0);

            command.Dispose();
            mySqlConnection.Close();

            return id;
        }

        public Transactie[] ReadAllFromTransacties()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(QRY_ReadAllFromTransacties, mySqlConnection);
            adapter.Fill(table);

            Transactie[] transacties = new Transactie[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
                transacties[i] = new Transactie(table.Rows[i]);

            return transacties;
        }
    }
}
