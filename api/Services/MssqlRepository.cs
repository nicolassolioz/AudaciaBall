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

        public List<GameStats> GetGamesStats()
        {
            List<GameStats> results = new List<GameStats>();
            List<Player> players = GetPlayers();

            for(int i = 0; i<players.Count; i++)
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

                for(int y = 0;y< gameStats.gamesPlayed; y++)
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

        public string[] GetAllMssqlRows()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (string[])ctx.Cache[CacheKey];
            }

            string[] empty = new string[1];
            empty[0] = "empty";
            return empty;
        }

    }
}