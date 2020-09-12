//created by Nicolas Solioz
//last modified 2020-09-12

//this is the data layer where we access directly the database with our saved connection string in web.config

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AudaciaBallAPI.Models;

namespace AudaciaBallAPI.Services
{
    public class MssqlRepository
    {
        private const string CacheKey = "MssqlStore";

        public MssqlRepository()
        {

        }

        //getPlayerName from database, used with GamePlayer lists in order to return the name of the player with the games, 
        //this means we don't have to consume an extra API query on the front end
        public string getPlayerName(int id)
        {
            string playerName = "";
            var dataTable = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Player Where idPlayer = @uid";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@uid", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            playerName = (string)dr["playerName"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return playerName;
        }

        //retrieve player from database based on given identifier (idPlayer)
        public Player getPlayer(int id)
        {
            Player player = new Player();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Player Where idPlayer = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            player = new Player();
                            player.idPlayer = (int)dr["idPlayer"];
                            player.name = (string)dr["playerName"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return player;
        }

        //get all games and the name of their players based on the given parameter (idPlayer
        public List<GamePlayer> GetGameHistory(int idPlayer)
        {
            var ctx = HttpContext.Current;
            List<GamePlayer> results = new List<GamePlayer>();

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Game Where fk_idPlayerBlue = @idPlayer OR fk_idPlayerRed = @idPlayer ORDER BY gameDate DESC";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idPlayer", idPlayer);

                    cn.Open();
                    if (cn.State == ConnectionState.Closed)
                    { return null; }
                    else
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        { return null; }
                        else
                        {
                            while (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    GamePlayer gamePlayer = new GamePlayer();
                                    gamePlayer.idGame = (int)dr["idGame"];
                                    gamePlayer.scoreBlue = (int)dr["scoreBlue"];
                                    gamePlayer.scoreRed = (int)dr["scoreRed"];
                                    gamePlayer.gameDate = (DateTime)dr["gameDate"];
                                    gamePlayer.fk_idPlayerBlue = (int)dr["fk_idPlayerBlue"];
                                    gamePlayer.fk_idPlayerRed = (int)dr["fk_idPlayerRed"];
                                    gamePlayer.namePlayerBlue = (string)getPlayerName((int)dr["fk_idPlayerBlue"]);
                                    gamePlayer.namePlayerRed = (string)getPlayerName((int)dr["fk_idPlayerRed"]);

                                    results.Add(gamePlayer);
                                }
                                dr.NextResult();
                            }
                            if (!dr.IsClosed)
                            { dr.Close(); }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        //get all games from database
        public List<Game> GetGames()
        {
            var ctx = HttpContext.Current;
            List<Game> results = new List<Game>();

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Game ORDER BY date DESC";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    if (cn.State == ConnectionState.Closed)
                    { return null; }
                    else
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        { return null; }
                        else
                        {
                            while (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Game game = new Game();
                                    game.idGame = (int)dr["idGame"];
                                    game.scoreBlue = (int)dr["scoreBlue"];
                                    game.scoreRed = (int)dr["scoreRed"];
                                    game.gameDate = (DateTime)dr["gameDate"];
                                    game.fk_idPlayerBlue = (int)dr["fk_idPlayerBlue"];
                                    game.fk_idPlayerRed = (int)dr["fk_idPlayerRed"];

                                    results.Add(game);
                                }
                                dr.NextResult();
                            }
                            if (!dr.IsClosed)
                            { dr.Close(); }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        //Get all games and their players
        public List<GamePlayer> GetGamesPlayers()
        {
            var ctx = HttpContext.Current;
            List<GamePlayer> results = new List<GamePlayer>();

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Game ORDER BY gameDate DESC";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    if (cn.State == ConnectionState.Closed)
                    { return null; }
                    else
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        { return null; }
                        else
                        {
                            while (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    GamePlayer gamePlayer = new GamePlayer();
                                    gamePlayer.idGame = (int)dr["idGame"];
                                    gamePlayer.scoreBlue = (int)dr["scoreBlue"];
                                    gamePlayer.scoreRed = (int)dr["scoreRed"];
                                    gamePlayer.gameDate = (DateTime)dr["gameDate"];
                                    gamePlayer.fk_idPlayerBlue = (int)dr["fk_idPlayerBlue"];
                                    gamePlayer.fk_idPlayerRed = (int)dr["fk_idPlayerRed"];
                                    gamePlayer.namePlayerBlue = getPlayerName((int)dr["fk_idPlayerBlue"]);
                                    gamePlayer.namePlayerRed = getPlayerName((int)dr["fk_idPlayerRed"]);

                                    results.Add(gamePlayer);
                                }
                                dr.NextResult();
                            }
                            if (!dr.IsClosed)
                            { dr.Close(); }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        public List<Player> GetAllPlayers()
        {
            var ctx = HttpContext.Current;
            List<Player> results = new List<Player>();

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Player";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    if (cn.State == ConnectionState.Closed)
                    { return null; }
                    else
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        { return null; }
                        else
                        {
                            while (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Player player = new Player();
                                    player.idPlayer = (int)dr["idPlayer"];
                                    player.name = (string)dr["playerName"];

                                    results.Add(player);
                                }
                                dr.NextResult();
                            }
                            if (!dr.IsClosed)
                            { dr.Close(); }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        //get all players from database
        public List<Player> GetPlayers()
        {
            var ctx = HttpContext.Current;
            List<Player> results = new List<Player>();

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Player WHERE fk_idTeam IS NULL";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    if (cn.State == ConnectionState.Closed)
                    { return null; }
                    else
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        { return null; }
                        else
                        {
                            while (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Player player = new Player();
                                    player.idPlayer = (int)dr["idPlayer"];
                                    player.name = (string)dr["playerName"];

                                    results.Add(player);
                                }
                                dr.NextResult();
                            }
                            if (!dr.IsClosed)
                            { dr.Close(); }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        //get all teams from database
        public List<Player> GetTeams()
        {
            var ctx = HttpContext.Current;
            List<Player> results = new List<Player>();

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * From T_Player WHERE fk_idTeam IS NOT NULL";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    if (cn.State == ConnectionState.Closed)
                    { return null; }
                    else
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        { return null; }
                        else
                        {
                            while (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Player player = new Player();
                                    player.idPlayer = (int)dr["idPlayer"];
                                    player.name = (string)dr["playerName"];

                                    results.Add(player);
                                }
                                dr.NextResult();
                            }
                            if (!dr.IsClosed)
                            { dr.Close(); }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        //add a team to the database
        public void AddTeam(int idPlayer1, int idPlayer2)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO T_Team (fk_idPlayer1, fk_idPlayer2) VALUES (@idPlayer1, @idPlayer2)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idPlayer1", idPlayer1);
                    cmd.Parameters.AddWithValue("@idPlayer2", idPlayer2);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();


                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //get game statistics from database
        public List<GameStats> GetGamesStats()
        {
            List<GameStats> results = new List<GameStats>();
            List<Player> players = GetAllPlayers();

            for (int i = 0; i < players.Count; i++)
            {
                //variables used to count victories/losses
                int wins = 0;
                int losses = 0;
                int ties = 0;

                //save player name
                GameStats gameStats = new GameStats();
                gameStats.idPlayer = players[i].idPlayer;
                gameStats.playerName = players[i].name;

                //loop through game history of player
                List<GamePlayer> playedGames = GetGameHistory(players[i].idPlayer);
                if (playedGames == null)
                    gameStats.gamesPlayed = 0;
                else
                    gameStats.gamesPlayed = playedGames.Count;

                for (int y = 0; y < gameStats.gamesPlayed; y++)
                {
                    int gf = 0;
                    int ga = 0;
                    //checkTeam
                    if (playedGames[y].fk_idPlayerBlue == players[i].idPlayer)
                    {
                        //player was on blue team
                        gf += playedGames[y].scoreBlue;
                        ga += playedGames[y].scoreRed;
                        if (gf > ga)
                            wins++;
                        if (ga > gf)
                            losses++;
                        if (gf == ga)
                            ties++;
                    }
                    else
                    {
                        //player was on red team
                        gf += playedGames[y].scoreRed;
                        ga += playedGames[y].scoreBlue;
                        if (gf > ga)
                            wins++;
                        if (ga > gf)
                            losses++;
                        if (gf == ga)
                            ties++;
                    }
                    gameStats.gf += gf;
                    gameStats.ga += ga;
                }
                gameStats.wins = wins;
                gameStats.losses = losses;
                gameStats.ties = ties;
                results.Add(gameStats);
            }

            return results;
        }

        //add game to database
        public void AddGame(int scoreBlue, int scoreRed, int idPlayerBlue, int idPlayerRed)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;
            DateTime today = DateTime.Now;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO T_Game (scoreBlue, scoreRed, fk_idPlayerBlue, fk_idPlayerRed, gameDate) VALUES (@scoreBlue, @scoreRed, @idPlayerBlue, @idPlayerRed, @gameDate)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@scoreBlue", scoreBlue);
                    cmd.Parameters.AddWithValue("@scoreRed", scoreRed);
                    cmd.Parameters.AddWithValue("@idPlayerBlue", idPlayerBlue);
                    cmd.Parameters.AddWithValue("@idPlayerRed", idPlayerRed);
                    cmd.Parameters.AddWithValue("@gameDate", today);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();


                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //retrieve the last inserted team in the database
        public int GetLastInsertedTeam()
        {
            var ctx = HttpContext.Current;
            int idTeam = 0;

            var dataTable = new DataTable();


            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 1 T_Team.idTeam FROM T_Team ORDER BY T_Team.idTeam DESC";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            idTeam = (int)dr["idTeam"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return idTeam;
        }

        //add a player to the database
        public void AddPlayer(string name)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO T_Player (playerName) VALUES (@name)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", name);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //add a team to the database
        public int AddPlayerTeam(string name, int idTeam)
        {
            int result = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO T_Player (playerName, fk_idTeam) VALUES (@name, @idTeam)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@idTeam", idTeam);

                    cn.Open();
                    result = cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return 1;
        }

        //add a team to the database
        public string emptyDatabase()
        {
            string result = "not finished";
            //remove constraints
            removeConstraintTeam();
            removeConstraintGame();
            removeConstraintPlayer();

            //empty tables
            deleteTeams();
            deleteGames();
            deletePlayers();

            return result;
        }

        public void deleteTeams()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM T_Team WHERE idTeam<10000";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deletePlayers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM T_Player WHERE idPlayer<10000";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteGames()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM T_Game WHERE idGame<10000;";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void removeConstraintPlayer()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "ALTER TABLE T_Player NOCHECK CONSTRAINT ALL;";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void removeConstraintTeam()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "ALTER TABLE T_Team NOCHECK CONSTRAINT ALL;";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void removeConstraintGame()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "ALTER TABLE T_Game NOCHECK CONSTRAINT ALL;";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void initDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlDatabase"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query =
                        "CREATE TABLE T_Player (idPlayer int IDENTITY(1,1) NOT NULL PRIMARY KEY,playerName varchar(255) NOT NULL,fk_idTeam int);" +

                        "CREATE TABLE T_Team(idTeam int IDENTITY(1, 1) NOT NULL PRIMARY KEY,fk_idPlayer1 int NOT NULL,fk_idPlayer2 int NOT NULL," +
                        "FOREIGN KEY(fk_idPlayer1) REFERENCES T_Player(idPlayer),FOREIGN KEY(fk_idPlayer2) REFERENCES T_Player(idPlayer));" +

                        "CREATE TABLE T_Game(idGame int IDENTITY(1, 1) NOT NULL PRIMARY KEY,scoreBlue int NOT NULL,scoreRed int NOT NULL," +
                        "fk_idPlayerBlue int NOT NULL,fk_idPlayerRed int NOT NULL,gameDate DateTime NOT NULL," +
                        "FOREIGN KEY(fk_idPlayerBlue) REFERENCES T_Player(idPlayer)," +
                        "FOREIGN KEY(fk_idPlayerRed) REFERENCES T_Player(idPlayer));" +

                        "ALTER TABLE T_Player ADD fk_idTeam int;" +
                        "ALTER TABLE T_Player ADD CONSTRAINT fk_idTeam FOREIGN KEY(fk_idTeam) REFERENCES T_Team(idTeam);";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}