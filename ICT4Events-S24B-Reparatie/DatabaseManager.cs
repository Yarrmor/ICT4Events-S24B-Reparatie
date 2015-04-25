using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;

namespace ICT4Events_S24B_Reparatie
{
    class DatabaseManager
    {
        public string PCN;
        public string Wachtwoord;
        public OracleConnection Verbinding;

        public DatabaseManager()
        {
            this.PCN = "dbi255847";
            this.Wachtwoord = "u1eoeVfvUI";

            Verbinding = new OracleConnection();

            Verbinding.ConnectionString = "User Id=" + this.PCN + ";Password=" + this.Wachtwoord + ";Data Source=" + "//192.168.15.50:1521/fhictora;";
        }

        /// <summary>
        /// Retourneert een instantie van OracleCommand met
        /// this.Verbinding & .CommandType.Text
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public OracleCommand MaakOracleCommand(string sql)
        {
            OracleCommand command = new OracleCommand(sql, this.Verbinding);
            command.CommandType = System.Data.CommandType.Text;

            return command;
        }

        /// <summary>
        /// Voert de query uit van meegegeven OracleCommand.
        /// Deze OracleCommand moet gemaakt zijn door MaakOracleCommand() en parameters moeten al ingesteld zijn.
        /// De teruggegeven lijst bevat voor elke rij een OracleDataReader.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public OracleDataReader VoerMultiQueryUit(OracleCommand command)
        {
            try
            {
                Verbinding.Open();

                OracleDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Voert de query uit van meegegeven OracleCommand.
        /// Deze OracleCommand moet gemaakt zijn door MaakOracleCommand() en parameters moeten al ingesteld zijn.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public OracleDataReader VoerQueryUit(OracleCommand command)
        {
            try
            {
                if (Verbinding.State == ConnectionState.Closed)
                {
                    Verbinding.Open();
                }

                OracleDataReader reader = command.ExecuteReader();

                reader.Read();

                return reader;
            }
            catch
            {
                return null;
            }
        }

        public bool VoerNonQueryUit(OracleCommand command)
        {
            try
            {
                Verbinding.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /////////////
        // Queries //
        /////////////


        #region Algemeen
        /// <summary>
        /// Vergelijkt de ingevulde gegevens met de gegevens van het bijbehorende account in de database.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="wachtwoord"></param>
        /// <returns></returns>
        public bool VerifieerLogin(string email, string wachtwoord)
        {
            try
            {
                string sql = "SELECT AccountID FROM ACCOUNT WHERE Email = :Email AND Wachtwoord = :Wachtwoord";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":Email", email);
                command.Parameters.Add(":Wachtwoord", wachtwoord);

                OracleDataReader reader = VoerQueryUit(command);

                if (reader.HasRows)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public int NieuwID(string tabel)
        {
            try
            {
                string sql = "SELECT MAX(:TabelID) AS MaxID FROM :Tabel";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":Tabel", tabel);
                command.Parameters.Add(":TabelID", (tabel + "ID"));

                string text = command.CommandText;

                OracleDataReader reader = VoerQueryUit(command);

                return Convert.ToInt32(reader["MaxID"].ToString()) + 1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        #endregion

        #region Event

        public Event VerkrijgEvent(int eventID)
        {
            try
            {
                string sql = "SELECT EventID, LocatieID, Naam, DatumStart, DatumEind FROM EVENT WHERE EventID = :EventID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":EventID", eventID);

                OracleDataReader reader = VoerQueryUit(command);

                Event e = new Event(Convert.ToInt32(reader["EventID"]),
                                    VerkrijgLocatie(Convert.ToInt32(reader["LocatieID"])),
                                    reader["Naam"].ToString(),
                                    Convert.ToDateTime(reader["DatumStart"]),
                                    Convert.ToDateTime(reader["DatumEind"]));

                return e;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region ReserveringPlaatsen

        public Account VerkrijgAccountDetailsToegang(string rfid)
        {
            //Wat roept dit precies op? Details ZONDER reserveringsstatus?
            //string rfid, int accountID, string email, string roepnaam, AccountType type, Geslacht geslacht, string voornaam, string achternaam, DateTime geboorteDatum, bool verbannen
            try
            {
                throw new NotImplementedException();

                string sql = "SELECT Voornaam, Achternaam, Roepnaam FROM ACCOUNT WHERE RFID = :RFID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":RFID", rfid);

                OracleDataReader reader = VoerQueryUit(command);

                Account account = new Account(rfid);

                return account;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public Plek HaalPlekOp(int plekID, Locatie locatie)
        {
            try
            {
                string sql = "SELECT Prijs, Beschrijving FROM Plek WHERE PlekID = :PlekID AND LocatieID = :LocatieID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":PlekID", plekID);
                command.Parameters.Add(":LocatieID", locatie.LocatieID);

                OracleDataReader reader = VoerQueryUit(command);

                Plek plek = new Plek(plekID, locatie, Convert.ToInt32(reader["Prijs"]), reader["Beschrijving"].ToString());
                return plek;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }

        }

        public ReserveringPlaats VerkrijgReserveringPlaats(string rfid)
        {
            try
            {
                string sql = "SELECT ReserveringID, ACCOUNT.AccountID, PlekID, EventID, DatumStart, DatumEind, Betaald FROM RESERVERING, ACCOUNT WHERE RFID = :RFID AND ACCOUNT.AccountID = RESERVERING.AccountID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":RFID", rfid);

                OracleDataReader reader = VoerQueryUit(command);

                bool betaald = false;
                if (Convert.ToInt32(reader["Betaald"]) == 0)
                    betaald = false;
                else if (Convert.ToInt32(reader["Betaald"]) == 1)
                    betaald = true;

                ReserveringPlaats rp = new ReserveringPlaats(GroepshoofdReservering(Convert.ToInt32(reader["ReserveringID"])),
                                                             VerkrijgPlek(Convert.ToInt32(reader["PlekID"])),
                                                             VerkrijgEvent(Convert.ToInt32(reader["EventID"])),
                                                             Convert.ToDateTime(reader["DatumStart"]),
                                                             Convert.ToDateTime(reader["DatumEind"]),
                                                             betaald);

                return rp;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public Locatie VerkrijgLocatie(int locatieID)
        {
            try
            {
                string sql = "SELECT LocatieID, Telefoonnummer, Plaats, Straat, Huisnummer FROM LOCATIE WHERE LocatieID = :LocatieID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":LocatieID", locatieID);

                OracleDataReader reader = VoerQueryUit(command);

                Locatie l = new Locatie(Convert.ToInt32(reader["LocatieID"]),
                                        reader["Telefoonnummer"].ToString(),
                                        reader["Plaats"].ToString(),
                                        reader["Straat"].ToString(),
                                        reader["Huisnummer"].ToString());

                return l;
            }
            catch
            {
                return null;
            }
        }

        public Plek VerkrijgPlek(int plekID)
        {
            try
            {
                string sql = "SELECT PlekID, LocatieID, Beschrijving, Prijs FROM PLEK WHERE PlekID = :PlekID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":PlekID", plekID);

                OracleDataReader reader = VoerQueryUit(command);

                Plek p = new Plek(Convert.ToInt32(reader["PlekID"]),
                                  VerkrijgLocatie(Convert.ToInt32(reader["LocatieID"])),
                                  Convert.ToInt32(reader["Prijs"]),
                                  reader["Beschrijving"].ToString());

                return p;
            }
            catch
            {
                return null;
            }
        }

        public bool ZetBetaald(string rfid, int eventID)
        {
            try
            {
                string sql = "UPDATE RESERVERING SET Betaald = 1 WHERE ACCOUNT.RFID = :RFID AND ACCOUNT.AccountID = RESERVERING.AccountID AND RESERVERING.EventID = :EventID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":RFID", rfid);
                command.Parameters.Add(":EventID", eventID);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public bool AnnuleringReservering(string rfid, int eventID)
        {
            try
            {
                string sql = "DELETE FROM RESERVERING WHERE ACCOUNT.RFID = :RFID AND RESERVERING.EventID = :EventID AND ACCOUNT.AccountID = RESERVERING.AccountID AND GROEPSHOOFD.AccountID = ACCOUNT.AccountID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":RFID", rfid);
                command.Parameters.Add(":EventID", eventID);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        #endregion ReserveringPlaatsen

        #region Materiaal
        /// <summary>
        /// Voegt het meegegeven materiaal toe aan de database.
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public bool VoegMateriaalToe(Materiaal mat)
        {
            try
            {
                this.NieuwID("MATERIAAL");
                string sql = "INSERT INTO MATERIAAL(MateriaalID, Naam, Beschrijving, Prijs) VALUES (:MateriaalID, :Naam, :Beschrijving, :Prijs)";

                OracleCommand command = MaakOracleCommand(sql);
                command.Parameters.Add(":MateriaalID", this.NieuwID("MATERIAAL"));
                command.Parameters.Add(":Naam", mat.Naam);
                command.Parameters.Add(":Beschrijving", mat.Beschrijving);
                command.Parameters.Add(":Prijs", mat.Prijs);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public bool VoegPlekToe(Plek plek)
        {
            try
            {
                string sql = "INSERT INTO PLEK(PlekID, LocatieID, Prijs, Beschrijving) VALUES (:PlekID, :LocatieID, :Prijs, :Beschrijving)";

                OracleCommand command = MaakOracleCommand(sql);
                command.Parameters.Add(":PlekID", plek.PlekID);
                command.Parameters.Add(":LocatieID", plek.Locatie);
                command.Parameters.Add(":Prijs", plek.Prijs);
                command.Parameters.Add(":Beschrijving", plek.Beschrijving);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public bool VoegMateriaalReserveringToe(ReserveringMateriaal reservering)
        {
            try
            {
                string sql = "INSERT INTO UITLENING(AccountID, ExemplaarID, DatumStart, DatumEind) VALUES (:AccountID, :ExemplaarID, :DatumStart, :DatumEind)";

                OracleCommand command = MaakOracleCommand(sql);
                command.Parameters.Add(":AccountID", reservering.Account.AccountID);
                command.Parameters.Add(":ExemplaarID", reservering.Exemplaar.ExemplaarID);
                command.Parameters.Add(":DatumStart", reservering.DatumStart);
                command.Parameters.Add(":DatumEind", reservering.DatumEind);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public bool VoegPlekReserveringToe(ReserveringPlaats reservering)
        {
            try
            {
                string sql = "INSERT INTO RESERVERING(AccountID, PlekID, EventID, DatumStart, DatumEind, Betaald) VALUES (:AccountID, :PlekID, :EventID, :DatumStart, :DatumEind, :Betaald)";

                DateTime datumStart = reservering.DatumStart;
                string startDag = datumStart.Day.ToString();
                string startMaand = datumStart.Month.ToString();
                string startJaar = datumStart.Year.ToString();

                DateTime datumEind = reservering.DatumEind;
                string eindDag = datumEind.Day.ToString();
                string eindMaand = datumEind.Month.ToString();
                string eindJaar = datumEind.Year.ToString();

                string[] strings = new string[] { startDag, startMaand, eindDag, eindMaand };
                for (int i = 0; i < strings.Count(); i++)
                {
                    if (strings[i].Length == 1)
                        strings[i] = "0" + strings[i];
                }

                string datumStartReplace = "TO_DATE('" + strings[0] + "/" + strings[1] + "/" + startJaar + "', 'dd/mm/yyyy')";
                string datumEindReplace = "TO_DATE('" + strings[2] + "/" + strings[3] + "/" + eindJaar + "', 'dd/mm/yyyy')";
                int betaald = 0;
                if (reservering.Betaald)
                    betaald = 1;

                OracleCommand command = MaakOracleCommand(sql);
                command.Parameters.Add(":AccountID", reservering.Groepshoofd.AccountID);
                command.Parameters.Add(":PlekID", reservering.Plek.PlekID);
                command.Parameters.Add(":EventID", reservering.Event.ID);
                command.Parameters.Add(":DatumStart", datumStartReplace);
                command.Parameters.Add(":DatumEind", datumEindReplace);
                command.Parameters.Add(":Betaald", betaald);

                return VoerNonQueryUit(command);

            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public List<Exemplaar> ExemplarenVanMateriaal(int MateriaalID)
        {
            throw new NotImplementedException();
            return null;
        }

        #endregion

        #region MediaSharing

        #region Accounts

        public int VerkrijgNieuwAccountID()
        {
            try
            {
                string sql = "SELECT MAX(AccountID) AS MaxID FROM Account";

                OracleCommand command = MaakOracleCommand(sql);

                string text = command.CommandText;

                OracleDataReader reader = VoerQueryUit(command);

                return Convert.ToInt32(reader["MaxID"].ToString()) + 1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        /// <summary>
        /// Haalt alle weer te geven/gebruikbare account details op van het bijbehorende email.
        /// eventID is noodzakelijk om het juiste accountType op te halen.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public Account AccountGegevens(string email, int eventID)
        {
            try
            {
                #region query1: basis details
                string sql = "SELECT AccountID, RFID, Email, Roepnaam, Geslacht, Voornaam, Achternaam, Geboortedatum, Verbannen FROM ACCOUNT WHERE Email = :Email";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":Email", email);

                OracleDataReader reader = VoerQueryUit(command);

                int accountID = Convert.ToInt32(reader["AccountID"]);
                string rfid = reader["RFID"].ToString();
                string mail = reader["Email"].ToString();
                string roepnaam = reader["Roepnaam"].ToString();
                string geslacht = reader["Geslacht"].ToString();
                if (geslacht == "M")
                    geslacht = "Man";
                else if (geslacht == "V")
                    geslacht = "Vrouw";
                string voornaam = reader["Voornaam"].ToString();
                string achternaam = reader["Achternaam"].ToString();

                DateTime geboorteDatum = new DateTime();
                if (reader["GeboorteDatum"] != DBNull.Value)
                {
                    geboorteDatum = Convert.ToDateTime(reader["GeboorteDatum"]);//reader.GetDateTime(7);
                }

                bool verbannen = Convert.ToBoolean(reader["Verbannen"]);
                #endregion

                #region query2: account type & rfid

                sql = "SELECT Rol FROM ROL WHERE AccountID = ( SELECT AccountID FROM ACCOUNT WHERE Email = :Email ) AND EventID = :EventID";

                OracleCommand command2 = MaakOracleCommand(sql);
                command2.Parameters.Add(":Email", email);
                command2.Parameters.Add(":EventID", eventID);

                reader = VoerQueryUit(command2);

                string type = reader["Rol"].ToString();
                AccountType accountType = AccountTypeStringNaarEnum(type);
                #endregion

                Account account = new Account(rfid, accountID, mail, roepnaam, accountType, GeslachtStringNaarEnum(geslacht), voornaam, achternaam, geboorteDatum, verbannen);
                return account;
                //return account;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        /// <summary>
        /// Voegt een nieuw account toe met de meegegeven waarden in tabel ACCOUNT en ROL
        /// </summary>
        /// <param name="rfid"></param>
        /// <param name="email"></param>
        /// <param name="roepnaam"></param>
        /// <param name="type"></param>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public bool VoegAccountToe(string rfid, string email, string roepnaam, AccountType type, int eventID)
        {
            try
            {
                string sql = "INSERT INTO ACCOUNT (Email, Gebruikersnaam) VALUES (:Email, :Gebruikersnaam)";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":Email", email);
                command.Parameters.Add(":Gebruikersnaam", roepnaam);

                int updates = command.ExecuteNonQuery();
                command.Dispose();

                if (updates != 0)
                {
                    int accountID = VerkrijgAccountID(email);

                    sql = "INSERT INTO ROL (AccountID, EventID, Rol, RFID) VALUES (:AccountID, :EventID, :Rol, :RFID)";

                    command = MaakOracleCommand(sql);

                    command.Parameters.Add(":AccountID", accountID);
                    command.Parameters.Add(":EventID", eventID);
                    command.Parameters.Add(":Rol", type.ToString());
                    command.Parameters.Add(":RFID", rfid);

                    command.ExecuteNonQuery();

                    command.Dispose();

                    return true;
                }

                else
                    return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        /// <summary>
        /// Retourneert het accountID van het account met dit email adres.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int VerkrijgAccountID(string email)
        {
            try
            {
                string sql = "SELECT AccountID FROM ACCOUNT WHERE Email = :Email";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":Email", email);

                OracleDataReader reader = VoerQueryUit(command);

                return Convert.ToInt32(reader["AccountID"]);
            }
            catch
            {
                return -1;
            }
        }

        public Account VerkrijgAccount(int accountID, int eventID)
        {
            try
            {
                #region Query1
                string sql = "SELECT RFID, Email, Roepnaam, Geslacht, Voornaam, Achternaam, GeboorteDatum, Verbannen FROM ACCOUNT WHERE AccountID = :AccountID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":AccountID", accountID);

                OracleDataReader reader = VoerQueryUit(command);

                Geslacht geslachtType;

                string rfid = reader["RFID"].ToString();
                string email = reader["Email"].ToString();
                string roepnaam = reader["Roepnaam"].ToString();
                string geslacht = reader["Geslacht"].ToString();
                if (geslacht == "M")
                    geslacht = "Man";
                else if (geslacht == "V")
                    geslacht = "Vrouw";
                geslachtType = GeslachtStringNaarEnum(geslacht);
                string voornaam = reader["Voornaam"].ToString();
                string achternaam = reader["Achternaam"].ToString();

                DateTime geboorteDatum = new DateTime();
                if (reader["GeboorteDatum"] != DBNull.Value)
                {
                    geboorteDatum = Convert.ToDateTime(reader["GeboorteDatum"]);//reader.GetDateTime(7);
                }

                bool verbannen = Convert.ToBoolean(reader["Verbannen"]);

                #endregion

                #region query2: account type & rfid
                sql = "SELECT Rol FROM ROL WHERE AccountID = ( SELECT AccountID FROM ACCOUNT WHERE Email = :Email ) AND EventID = :EventID";
                command = MaakOracleCommand(sql);
                command.Parameters.Add(":Email", email);
                command.Parameters.Add(":EventID", eventID);

                reader = VoerQueryUit(command);

                string type = reader["Rol"].ToString();
                AccountType accountType = AccountTypeStringNaarEnum(type);
                #endregion

                Account acc = new Account(rfid, accountID, email, roepnaam, accountType, geslachtType, voornaam, achternaam, geboorteDatum, verbannen);

                return acc;
            }
            catch
            {
                return null;
            }
        }

        public List<Account> VerkrijgAlleAccounts(int eventID)
        {
            try
            {
                List<Account> accounts = new List<Account>();

                string sql = "SELECT a.AccountID, a.RFID, a.Email, a.Roepnaam, a.Geslacht, a.Voornaam, a.Achternaam, a.GeboorteDatum, a.Verbannen, r.ROL FROM ACCOUNT a INNER JOIN ROL r ON a.ACCOUNTID = r.ACCOUNTID WHERE r.EVENTID = :EventID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":EventID", eventID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                while (reader.Read())
                {
                    try
                    {
                        Geslacht geslachtType;

                        int accountID = Convert.ToInt32(reader["AccountID"]);
                        string rfid = reader["RFID"].ToString();
                        string email = reader["Email"].ToString();
                        string roepnaam = reader["Roepnaam"].ToString();
                        string geslacht = reader["Geslacht"].ToString();
                        if (geslacht == "M")
                            geslacht = "Man";
                        else if (geslacht == "V")
                            geslacht = "Vrouw";
                        geslachtType = GeslachtStringNaarEnum(geslacht);
                        string voornaam = reader["Voornaam"].ToString();
                        string achternaam = reader["Achternaam"].ToString();

                        DateTime geboorteDatum = new DateTime();
                        if (reader["GeboorteDatum"] != DBNull.Value)
                        {
                            geboorteDatum = Convert.ToDateTime(reader["GeboorteDatum"]);//reader.GetDateTime(7);
                        }

                        bool verbannen = Convert.ToBoolean(reader["Verbannen"]);
                        string type = reader["Rol"].ToString();
                        AccountType accountType = AccountTypeStringNaarEnum(type);
                        #endregion

                        accounts.Add(new Account(rfid, accountID, email, roepnaam, accountType, geslachtType, voornaam, achternaam, geboorteDatum, verbannen));
                    }
                    catch
                    {
                        return null;
                    }
                }

                return accounts;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public string VerkrijgRol(int accountID, int eventID)
        {
            try
            {
                string sql = "SELECT Rol FROM ROL WHERE AccountID = :AccountID AND EventID = :EventID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":AccountID", accountID);
                command.Parameters.Add(":EventID", eventID);

                OracleDataReader reader = VoerQueryUit(command);

                return reader["Rol"].ToString();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Verandert het wachtwoord van dit account naar de meegegeven waarde.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="wachtwoord"></param>
        /// <returns></returns>
        public bool WijzigWachtwoord(string email, string wachtwoord)
        {
            try
            {
                string sql = "UPDATE ACCOUNT SET Wachtwoord = :Wachtwoord WHERE Email = :Email";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":Email", email);
                command.Parameters.Add(":Wachtwoord", wachtwoord);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        //TODO: Fix
        //public List<Account> VerkrijgAfwezig()
        //{
        //    List<Account> accountList = new List<Account>();

        //    string sql = "SELECT "
        //}

        /// <summary>
        /// Controleert of huidigWachtwoord van dit account overeen komt met database. Als dit zo is, update wachtwoord naar nieuwWachtwoord en return true, anders return false.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="huidigWachtwoord"></param>
        /// <param name="nieuwWachtwoord"></param>
        /// <returns></returns>
        public bool WijzigWachtwoord(string email, string huidigWachtwoord, string nieuwWachtwoord)
        {
            try
            {
                string sql1 = "SELECT AccountID FROM ACCOUNT WHERE Email = :Email AND Wachtwoord = :HuidigWachtwoord";

                OracleCommand command1 = MaakOracleCommand(sql1);

                command1.Parameters.Add(":Email", email);
                command1.Parameters.Add(":HuidigWachtwoord", huidigWachtwoord);

                OracleDataReader reader = VoerQueryUit(command1);

                if (reader != null)
                {
                    string sql2 = "UPDATE ACCOUNT SET Wachtwoord = :NieuwWachtwoord WHERE Email = :Email";

                    OracleCommand command2 = MaakOracleCommand(sql2);

                    command2.Parameters.Add(":Email", email);
                    command2.Parameters.Add(":NieuwWachtwoord", nieuwWachtwoord);

                    return VoerNonQueryUit(command2);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        /// <summary>
        /// Retourneert het RFID van het account met bijbehorend email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string VerkrijgRFID(string email)
        {
            try
            {
                string sql = "SELECT RFID FROM Account WHERE Email = :Email";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":Email", email);

                OracleDataReader reader = VoerQueryUit(command);

                if (reader.HasRows)
                {
                    return reader["RFID"].ToString();
                }
                else
                    return "";

            }
            catch
            {
                return "";
            }
            finally
            {
                Verbinding.Close();
            }
        }

        /// <summary>
        /// Verwijdert het account behorend bij dit RFID. Return is of het gelukt is.
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public bool VerwijderAccount(string rfid)
        {
            try
            {
                string sql = "DELETE FROM ACCOUNT WHERE RFID = :RFID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":RFID", rfid);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        //TOD: Fix
        public bool VoegAccountToe(Account acc)
        {
            try
            {
                //string sql = "INSERT INTO ACCOUNT(RFID, Email, Roepnaam, Geslacht, "

                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public AccountType? VerkrijgAccountType(string RFID, int eventID)
        {
            try
            {
                #region query2: account type & rfid
                string sql = "SELECT Rol FROM ROL WHERE AccountID = ( SELECT AccountID FROM ACCOUNT WHERE RFID = :RFID ) AND EventID = :EventID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":RFID", RFID);
                command.Parameters.Add(":EventID", eventID.ToString());

                OracleDataReader reader = VoerQueryUit(command);

                command = MaakOracleCommand(sql);

                reader = VoerQueryUit(command);

                string type = reader["Rol"].ToString();

                AccountType accountType = AccountTypeStringNaarEnum(type);

                return accountType;
                #endregion
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public bool WijzigProfielDetails(string rfid)
        {
            throw new NotImplementedException();
            return false;
        }

        public bool Verban(string email, bool ban)
        {
            try
            {
                string sql = "UPDATE ACCOUNT SET Verbannen = :Verbannen WHERE Email = :Email";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":Email", email);
                command.Parameters.Add(":Verbannen", ban);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        #endregion

        #region Categorie

        public int NieuwCategorieID()
        {
            try
            {
                string sql = "SELECT MAX(CategorieID) AS MaxID FROM Categorie";

                OracleCommand command = MaakOracleCommand(sql);

                string text = command.CommandText;

                OracleDataReader reader = VoerQueryUit(command);

                return Convert.ToInt32(reader["MaxID"].ToString()) + 1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        /// <summary>
        /// Verkrijgt alle categoriën van een bepaald evenement || Is nog niet helemaal juist geïmplementeerd met accounts gebeurd nog niks.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<Categorie> VerkrijgCategorieënEvent(int ID)
        {
            try
            {
                List<Categorie> categories = new List<Categorie>();

                string sql = "SELECT CategorieID, AccountID, Naam, Beschrijving, SubCatVan FROM CATEGORIE WHERE EventID = :EventID ORDER BY CATEGORIEID ASC";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":EventID", ID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                while (reader.Read())
                {
                    try
                    {
                        int categorieID = Convert.ToInt32(reader["CategorieID"]);
                        int accountID = Convert.ToInt32(reader["AccountID"]);
                        string naam = reader["Naam"].ToString();
                        string beschrijving = reader["Beschrijving"].ToString();

                        int subCatVan = -1;
                        if (reader["SubCatVan"] != DBNull.Value) 
                        {
                            subCatVan = Convert.ToInt32(reader["SubCatVan"]);
                        }

                        Account acc = VerkrijgAccount(accountID, ID);


                        //Enig probleem van de code hieronder is wanneer we een andere categorie opeens een subcatvan maken van een categorie die daarna is gemaakt. (gelukkig hoeven we daar nu niks mee te doen)
                        if (subCatVan > 0)
                        {
                            foreach (Categorie c in categories.ToList())
                            {
                                if (c.ID == subCatVan)
                                {
                                    categories.Add(new Categorie(Convert.ToInt32(categorieID), c, naam, beschrijving, acc));
                                }
                            }
                        }
                        else
                        {
                            categories.Add(new Categorie(Convert.ToInt32(categorieID), naam, beschrijving, acc));
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }
                return categories;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }


        public bool VoegCategorieToe(Categorie categorie, int eventID)
        {
            try
            {
                string sql = "INSERT INTO CATEGORIE (CategorieID, AccountID, EventID, Naam, Beschrijving) VALUES (:CategorieID, :AccountID, :EventID, :Naam, :Beschrijving)";

                if (categorie.Parent != null)
                {
                    sql = "INSERT INTO CATEGORIE (CategorieID, AccountID, EventID, Naam, Beschrijving, SubCatVan) VALUES (:CategorieID, :AccountID, :EventID, :Naam, :Beschrijving, :SubCatVan)";
                }

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":CategorieID", categorie.ID);
                command.Parameters.Add(":AccountID", categorie.Acc.AccountID);
                command.Parameters.Add(":EventID", eventID);
                command.Parameters.Add(":Naam", categorie.Naam);
                command.Parameters.Add(":Beschrijving", categorie.Beschrijving);

                if (categorie.Parent != null)
                {
                    command.Parameters.Add(":SubCatVan", categorie.Parent.ID);
                }

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public bool VerwijderCategorie(int ID)
        {
            try
            {
                string sql = "DELETE FROM Categorie WHERE CategorieID = :CategorieID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":CategorieID", ID);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        #endregion

        #region Melding

        public bool VoegMeldingToe(Melding melding)
        {
            try
            {
                string sql = "INSERT INTO MELDING (AccountID, MediaID, Toelichting, Datum) VALUES (:CategorieID, :AccountID, :EventID, :Naam)";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":AccountID", melding.Account.AccountID);
                command.Parameters.Add(":MediaID", melding.MediaID);
                command.Parameters.Add(":Toelichting", melding.Toelichting);
                command.Parameters.Add(":Datum", melding.Datum);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public bool VerwijderMelding(Melding melding)
        {
            try
            {
                string sql = "DELETE FROM Melding WHERE AccountID = :AccountID AND MediaID = :MediaID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":AccountID", melding.Account.AccountID);
                command.Parameters.Add(":MediaID", melding.MediaID);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public List<Melding> VerkrijgMeldingenEvent(int ID)
        {
            try
            {
                List<Melding> MeldingenEvent = new List<Melding>();

                string sql = "SELECT AccountID, MediaID, Toelichting, Datum FROM MELDING WHERE MediaID IN (SELECT MediaID FROM Media WHERE EventID = :EventID)";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":EventID", ID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                while (reader.Read())
                {
                    try
                    {
                        int accountID = Convert.ToInt32(reader["AccountID"]);
                        int mediaID = Convert.ToInt32(reader["MediaID"]);
                        string toelichting = reader["Toelichting"].ToString();
                        DateTime datum = Convert.ToDateTime(reader["Datum"]);

                        Account acc = VerkrijgAccount(accountID, ID);

                        MeldingenEvent.Add(new Melding(acc, mediaID, toelichting, datum));
                    }
                    catch
                    {
                        return null;
                    }
                }
                return MeldingenEvent;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        #endregion Melding

        #region Media

        public int NieuwMediaID()
        {
            try
            {
                string sql = "SELECT MAX(MediaID) AS MaxID FROM Media";

                OracleCommand command = MaakOracleCommand(sql);

                string text = command.CommandText;

                OracleDataReader reader = VoerQueryUit(command);

                return Convert.ToInt32(reader["MaxID"].ToString()) + 1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public List<Media> VerkrijgMediaEvent(int eventID)
        {
            try
            {
                List<Media> MediaEvent = new List<Media>();

                string sql = "SELECT MediaID, AccountID, CategorieID, Naam, Beschrijving, Pad, Datum, Verborgen FROM MEDIA WHERE EventID = :EventID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":EventID", eventID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                while (reader.Read())
                {
                    try
                    {
                        int mediaID = Convert.ToInt32(reader["MediaID"]);
                        int categorieID = Convert.ToInt32(reader["CategorieID"]);
                        int accountID = Convert.ToInt32(reader["AccountID"]);
                        string naam = reader["Naam"].ToString();
                        string beschrijving = reader["Beschrijving"].ToString();
                        string pad = reader["Pad"].ToString();
                        DateTime uploadDate = Convert.ToDateTime(reader["Datum"]);
                        bool verborgen = Convert.ToBoolean(reader["Verborgen"]);

                        Account acc = VerkrijgAccount(accountID, eventID);

                        string type = "";
                        if (pad.LastIndexOf(".") > 0)
                        {
                            type = pad.Substring(pad.LastIndexOf("."));
                        }
                        else
                        {
                            type = "";
                        }

                        if (pad != null)
                        { //new Bestand(um.dest.Substring(um.dest.LastIndexOf(".")), um.dest)
                            MediaEvent.Add(new Media(mediaID, naam, new Bestand(type, pad), categorieID, beschrijving, acc, uploadDate, eventID, verborgen));
                        }
                        else
                        {
                            MediaEvent.Add(new Media(mediaID, naam, categorieID, beschrijving, acc, uploadDate, eventID, verborgen));
                        }

                    }
                    catch
                    {
                        return null;
                    }
                }
                return MediaEvent;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public bool VoegMediaToe(Media media)
        {
            try
            {
                string sql = "INSERT INTO MEDIA (MediaID, AccountID, EventID, CategorieID, Naam, Beschrijving, Pad, Datum, Verborgen) VALUES (:MediaID, :AccountID, :EventID, :CategorieID, :Naam, :Beschrijving, :Pad, :Datum, :Verborgen)";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":MediaID", media.MediaID);
                command.Parameters.Add(":AccountID", media.Uploader.AccountID);
                command.Parameters.Add(":EventID", media.EventID);
                command.Parameters.Add(":CategorieID", media.CategorieID);
                command.Parameters.Add(":Naam", media.Naam);
                command.Parameters.Add(":Beschrijving", media.Beschrijving);
                command.Parameters.Add(":Pad", media.Bestand.Pad);
                command.Parameters.Add(":Datum", media.UploadDate);
                command.Parameters.Add(":Verborgen", Convert.ToInt32(media.Verborgen));

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public bool VerwijderMedia(int mediaID)
        {
            try
            {
                string sql = "DELETE FROM MEDIA WHERE MediaID = :MediaID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":MediaID", mediaID);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public int VerkrijgLikes(int mediaID)
        {
            try
            {
                string sql = "SELECT Count(AccountID) AS LIKES FROM STEM WHERE MediaID = :MediaID AND Score = 1";

                //string sql = "SELECT Count(AccountID) FROM STEM WHERE MediaID = :MediaID AND Score = 1";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":MediaID", mediaID);

                OracleDataReader reader = VoerQueryUit(command);

                int likes = Convert.ToInt32(reader["LIKES"]);

                return likes;
            }
            catch
            {
                return -1;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public int VerkrijgDisLikes(int mediaID)
        {
            try
            {
                string sql = "SELECT Count(AccountID) AS DISLIKES FROM STEM WHERE MediaID = :MediaID AND Score = -1";

                //string sql = "SELECT Count(AccountID) FROM STEM WHERE MediaID = :MediaID AND Score = -1";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":MediaID", mediaID);

                OracleDataReader reader = VoerQueryUit(command);

                int dislikes = Convert.ToInt32(reader["DISLIKES"]);

                return dislikes;
            }
            catch
            {
                return -1;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public bool Stem(int accountID, int mediaID, int score)
        {
            string sql = "";

            if(HeeftGestemd(accountID, mediaID))
                sql = "UPDATE SCORE SET Score = :Score, Datum = :Datum WHERE AccountID = :AccountID AND MediaID = :MediaID";
            else
                sql = "INSERT INTO SCORE(AccountID, MediaID, Score, Datum) VALUES (:AccountID, :MediaID, :Score, :Datum)";

            OracleCommand command = MaakOracleCommand(sql);

            command.Parameters.Add(":AccountID", accountID);
            command.Parameters.Add(":MediaID", mediaID);
            command.Parameters.Add(":Score", score);
            command.Parameters.Add(":Datum", DateTime.Now);

            if (VoerNonQueryUit(command))
                return true;
            else
                return false;
        }

        public bool HeeftGestemd(int accountID, int mediaID)
        {
            string sql = "SELECT * FROM SCORE WHERE AccountID = :AccountID AND MediaID = :MediaID";

            OracleCommand command = MaakOracleCommand(sql);

            command.Parameters.Add(":AccountID", accountID);
            command.Parameters.Add(":MediaID", mediaID);

            OracleDataReader reader = VoerQueryUit(command);

            if (reader.HasRows)
                return true;
            else
                return false;
        }

        #endregion

        #region Reactie

        public bool VoegReactieToe(Reactie reactie)
        {
            string sql = "";
            if (reactie.ReactieOp != null)
                sql = "INSERT INTO REACTIE (ReactieID, AccountID, MediaID, ReactieOp, Bericht, Datum) VALUES (:ReactieID, :AccountID, :MediaID, :ReactieOp, :Bericht, :Datum)";
            else
                sql = "INSERT INTO REACTIE (ReactieID, AccountID, MediaID, Bericht, Datum) VALUES (:ReactieID, :AccountID, :MediaID, :Bericht, :Datum)";

            OracleCommand command = MaakOracleCommand(sql);

            command.Parameters.Add(":ReactieID", NieuwID("REACTIE"));
            command.Parameters.Add(":AccountID", reactie.Account.AccountID);
            command.Parameters.Add(":MediaID", reactie.Media.MediaID);
            if(reactie.ReactieOp != null)
                command.Parameters.Add(":ReactieOp", reactie.ReactieOp.ReactieID);
            command.Parameters.Add(":Datum", DateTime.Now);

            if(VoerNonQueryUit(command))
                return true;
            else
                return false;
        }

        #endregion

        #region EmailSimulatie

        public int VerkrijgAccountVerifieerd(string rfid)
        {
            try
            {
                string sql = "SELECT Verifieerd FROM ACCOUNT WHERE RFID = :RFID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":RFID", rfid);

                OracleDataReader reader = VoerQueryUit(command);

                return Convert.ToInt32(reader["Verifieerd"]);
            }
            catch
            {
                return -1;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public bool VerkrijgReserveringBetaald(string rfid, int eventID)
        {
            throw new NotImplementedException();
            return false;
        }

        public bool VerifieerAccount(string rfid)
        {
            throw new NotImplementedException();
            return false;
        }

        public bool BetaalReservering(string rfid, int eventID)
        {
            throw new NotImplementedException();
            return false;
        }

        public List<string> AnnuleerReservering(string rfid, int eventID)
        {
            throw new NotImplementedException();
            return null;
        }

        #endregion

        #region GroepsHoofd

        public List<Groepslid> GroepsledenVanGroepshoofd(string rfid)
        {
            throw new NotImplementedException();
            return null;
        }

        /// <summary>
        /// Misschien een error vanwege te weinig account gegevens.
        /// </summary>
        /// <param name="reserveringID"></param>
        /// <returns></returns>
        public Groepshoofd GroepshoofdReservering(int reserveringID)
        {
            try
            {
                string sql = "SELECT EventID, ACCOUNT.RFID, ACCOUNT.AccountID, Email, Roepnaam, Voornaam, Achternaam, Telefoonnummer, Plaats, Straat, Huisnummer, Verbannen FROM GROEPSHOOFD, ACCOUNT, RESERVERING WHERE RESERVERING.AccountID = ACCOUNT.AccountID AND ACCOUNT.AccountID = GROEPSHOOFD.AccountID AND ReserveringID = :ReserveringID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":ReserveringID", reserveringID);

                OracleDataReader reader = VoerQueryUit(command);

                AccountType type = AccountType.Groepshoofd;
                switch (VerkrijgRol(Convert.ToInt32(reader["AccountID"]), Convert.ToInt32(reader["EventID"])))
                {
                    case "Groepshoofd":
                        type = AccountType.Groepshoofd;
                        break;
                    case "Groepslid":
                        type = AccountType.Groepslid;
                        break;
                    case "Medewerker":
                        type = AccountType.Medewerker;
                        break;
                    case "Beheerder":
                        type = AccountType.Beheerder;
                        break;
                }

                Groepshoofd gh = new Groepshoofd(reader["RFID"].ToString(),
                                                 Convert.ToInt32(reader["AccountID"]),
                                                 reader["Email"].ToString(),
                                                 reader["Roepnaam"].ToString(),
                                                 reader["Voornaam"].ToString(),
                                                 reader["Achternaam"].ToString(),
                                                 type,
                                                 reader["Telefoonnummer"].ToString(),
                                                 reader["Plaats"].ToString(),
                                                 reader["Straat"].ToString(),
                                                 reader["Huisnummer"].ToString(),
                                                 Convert.ToBoolean(reader["Verbannen"]));

                return gh;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public List<int> VerkrijgBeschikbarePlekken(int eventID, string filter)
        {
            try
            {
                // Alle niet gereserveerde plekken // filter en tijd niet door tijdsnood
                string sql = "SELECT PlekID FROM Plek WHERE PlekID NOT IN ( SELECT PlekID FROM Reservering WHERE EventID = :EventID ) AND PlekID IN ( SELECT PlekID FROM Plek WHERE LocatieID = ( SELECT LocatieID FROM Event WHERE EventID = :EventID )) ORDER BY PlekID ASC";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":EventID", eventID);

                OracleDataReader reader = VoerMultiQueryUit(command);


                List<int> plekken = new List<int>();

                while (reader.Read())
                {
                    plekken.Add(Convert.ToInt32(reader["PlekID"]));
                }

                return plekken;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }

        }

        public List<Materiaal> VerkrijgMateriaal(int eventID)
        {
            string sql = "SELECT MateriaalID, Naam, Beschijving, Prijs FROM Materiaal";

            OracleCommand command = MaakOracleCommand(sql);

            List<Materiaal> materialen = new List<Materiaal>();

            OracleDataReader reader = VoerMultiQueryUit(command);

            throw new NotImplementedException();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["MateriaalID"]);
                string naam = reader["Naam"].ToString();
                string beschrijving = reader["Beschrijving"].ToString();
                int prijs = Convert.ToInt32(reader["Prijs"]);

                materialen.Add(new Materiaal(id, naam, beschrijving, prijs));
            }

            Verbinding.Close();

            return materialen;
        }

        public bool WijzigPlekPrijs(int plekID, int prijs)
        {
            try
            {
                string sql = "UPDATE PLEK SET Prijs = :Prijs WHERE PlekID = :PlekID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":Prijs", prijs);
                command.Parameters.Add(":PlekID", plekID);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        #endregion

        #region AndereMethodes

        /////////////////////
        // Andere methodes //
        /////////////////////

        /// <summary>
        /// Zet string om naar AccountType
        /// Meegegeven type moet overeen komen met een AccountType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private AccountType AccountTypeStringNaarEnum(string type)
        {
            AccountType accountType;
            Enum.TryParse(type, out accountType);

            return accountType;
        }

        /// <summary>
        /// Zet string om naar Geslacht
        /// Meegegeven geslacht moet overeen komen met een Geslacht
        /// "Man" of "Vrouw", niet "M" of "V"
        /// </summary>
        /// <param name="geslachtString"></param>
        /// <returns></returns>
        private Geslacht GeslachtStringNaarEnum(string geslachtString)
        {
            Geslacht geslacht;

            Enum.TryParse(geslachtString, out geslacht);

            return geslacht;
        }
        #endregion
    }
}
