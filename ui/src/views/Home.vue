<!-- Created by Nicolas Solioz -->
<!-- Last edited 2020-09-12 -->
<template>
    <div class="home">
        <router-link to="/gameType" tag="button" class="newButton">New Game</router-link>
        <br /><br/>
        <router-link to="/totalGameHistory" tag="button" class="baseButton">See all games played</router-link>
        <router-link to="/managePlayers" tag="button" class="baseButton">Manage players</router-link>
        <router-link to="/manageTeams" tag="button" class="baseButton">Manage teams</router-link>
        <br /><br />
        <div id="loader" class="table-center"></div>
        <div id="scoreboard">
            <br />
            <div style="overflow-x:auto;">
                <table id="table" class="table-center">
                        <tr>
                            <th>Team/Player Name</th>
                            <th>Games Played</th>
                            <th>Wins</th>
                            <th>Losses</th>
                            <th>Ties</th>
                            <th>Win Ratio</th>
                            <th>Goals scored</th>
                            <th>Goals against</th>
                            <th>Goal difference</th>
                        </tr>
                        <tr v-for="info in infos" :key="info">
                            <td>{{info.playerName}}</td>
                            <td>{{info.gamesPlayed}}</td>
                            <td>{{info.wins}}</td>
                            <td>{{info.losses}}</td>
                            <td>{{info.ties}}</td>
                            <td>{{getWinRatio(info.gamesPlayed, info.wins)}}</td>
                            <td>{{info.gf}}</td>
                            <td>{{info.ga}}</td>
                            <td>{{info.gf-info.ga}}</td>
                        </tr>
                </table>
            </div>
        </div>
        <br/><br/>
    </div>
</template>
<script>
// @ is an alias to /src
import axios from 'axios';

export default {
    data () {
        return {
            infos: null,
            playerName: null
        }
    },
    mounted () {
        //hide table and wait for API to return data and then hide loader
        //get statistics from API
        document.getElementById("scoreboard").hidden = true;
        axios
            .get("https://audaciaballapi20200911031401.azurewebsites.net/GetGamesStats")
            .then((response) => {
                this.infos = response.data;
                document.getElementById("loader").hidden = true;
                document.getElementById("scoreboard").hidden = false;
            })
    },
    methods: {
        getWinRatio(totalGames, wins) {
            if(totalGames == 0)
                return 0;
            else
                return Math.round(wins/totalGames*100)/100;
        }
    }
}



</script>
