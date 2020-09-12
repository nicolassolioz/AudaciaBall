//created by Nicolas Solioz
//last modified 2020-09-12

//This is the business layer

using AudaciaBallAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AudaciaBallAPI.Services;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using System.Net.Http;

namespace AudaciaBallAPI.Controllers
{
    //allow specific url to access the API
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class MssqlController : ApiController
    {
        //use repository to access data layer
        private MssqlRepository mssqlRepository;

        //add name to database
        [System.Web.Http.Route("addPlayer/{name}")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage AddPlayer(string name)
        {
            this.mssqlRepository = new MssqlRepository();
            this.mssqlRepository.AddPlayer(name);

            return new HttpResponseMessage()
            {
                Content = new StringContent("OK")
            };
        }

        //add team to database
        [System.Web.Http.Route("addTeam/{name}/{idPlayer1}/{idPlayer2}")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage AddTeam(string name, int idPlayer1, int idPlayer2)
        {
            this.mssqlRepository = new MssqlRepository();
            this.mssqlRepository.AddTeam(idPlayer1, idPlayer2);
            this.mssqlRepository.AddPlayerTeam(name, this.mssqlRepository.GetLastInsertedTeam());

            return new HttpResponseMessage()
            {
                Content = new StringContent("OK")
            };
        }

        //add game to database
        [System.Web.Http.Route("addGame/{scoreBlue}/{scoreRed}/{idPlayerBlue}/{idPlayerRed}")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage AddGame(int scoreBlue, int scoreRed, int idPlayerBlue, int idPlayerRed)
        {
            this.mssqlRepository = new MssqlRepository();
            this.mssqlRepository.AddGame(scoreBlue, scoreRed, idPlayerBlue, idPlayerRed);

            return new HttpResponseMessage()
            {
                Content = new StringContent("OK")
            };
        }

        //retrieve game history from database
        [System.Web.Http.Route("getGameHistory/{idPlayer}")]
        [System.Web.Http.HttpGet]
        public List<GamePlayer> GetGameHistory(int idPlayer)
        {
            this.mssqlRepository = new MssqlRepository();
            List<GamePlayer> results = this.mssqlRepository.GetGameHistory(idPlayer);

            return results;
        }

        //retrieve games from database
        [System.Web.Http.Route("getGames")]
        [System.Web.Http.HttpGet]
        public List<GamePlayer> GetGames()
        {
            this.mssqlRepository = new MssqlRepository();
            List<GamePlayer> results = this.mssqlRepository.GetGamesPlayers();
            return results;

        }

        //retrieve game statistics from database
        [System.Web.Http.Route("getGamesStats")]
        [System.Web.Http.HttpGet]
        public List<GameStats> GetGamesStats()
        {
            this.mssqlRepository = new MssqlRepository();
            List<GameStats> results = this.mssqlRepository.GetGamesStats();
            return results;

        }

        //retrieve players from database
        [System.Web.Http.Route("getPlayers")]
        [System.Web.Http.HttpGet]
        public List<Player> GetPlayers()
        {
            this.mssqlRepository = new MssqlRepository();
            List<Player> results = this.mssqlRepository.GetPlayers();
            return results;
  
        }

        //retrieve player based on given identifier
        [System.Web.Http.Route("getPlayer/{id}")]
        [System.Web.Http.HttpGet]
        public Player GetPlayer(int id)
        {
            this.mssqlRepository = new MssqlRepository();
            Player result = this.mssqlRepository.getPlayer(id);
            return result;

        }

        //get teams from database
        [System.Web.Http.Route("getTeams")]
        [System.Web.Http.HttpGet]
        public List<Player> GetTeams()
        {
            this.mssqlRepository = new MssqlRepository();
            List<Player> results = this.mssqlRepository.GetTeams();
            return results;

        }

    }
}