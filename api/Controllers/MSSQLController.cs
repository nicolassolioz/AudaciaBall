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
    [EnableCors(origins: "https://audaciaballui.herokuapp.com", headers: "*", methods: "*")]
    public class MssqlController : ApiController
    {
        private MssqlRepository mssqlRepository;

        [System.Web.Http.Route("test")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Test()
        {
            this.mssqlRepository = new MssqlRepository();
            List<Player> results = this.mssqlRepository.GetPlayers();
            string playerNames = "";
            foreach (Player player in results)
            {
                playerNames += player.name + ' ';
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(playerNames)
            };
        }


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

        [System.Web.Http.Route("getGameHistory/{idPlayer}")]
        [System.Web.Http.HttpGet]
        public List<Game> GetGameHistory(int idPlayer)
        {
            this.mssqlRepository = new MssqlRepository();
            List<Game> results = this.mssqlRepository.GetGameHistory(idPlayer);

            return results;
        }

        [System.Web.Http.Route("getGames")]
        [System.Web.Http.HttpGet]
        public List<Game> GetGames()
        {
            this.mssqlRepository = new MssqlRepository();
            List<Game> results = this.mssqlRepository.GetGames();
            return results;

        }

        [System.Web.Http.Route("getPlayers")]
        [System.Web.Http.HttpGet]
        public List<Player> GetPlayers()
        {
            this.mssqlRepository = new MssqlRepository();
            List<Player> results = this.mssqlRepository.GetPlayers();
            return results;
  
        }

        [System.Web.Http.Route("getPlayer/{id}")]
        [System.Web.Http.HttpGet]
        public Player GetPlayer(int id)
        {
            this.mssqlRepository = new MssqlRepository();
            Player result = this.mssqlRepository.getPlayer(id);
            return result;

        }

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