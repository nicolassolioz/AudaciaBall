<template>
    <div class="home">
        <router-link to="/gameType" tag="button">New Game</router-link>
        <br /><br/>
        <div id="scoreboard">
            <table id="table" class="table-center">
                    <tr>
                        <th>idGame</th>
                        <th>score red</th>
                        <th>score blue</th>
                        <th>blue team</th>
                        <th>red team</th>
                        <th>date</th>
                    </tr>
                    <tr v-for="info in infos" :key="info">
                        <td>{{info.idGame}}</td>
                        <td>{{info.scoreRed}}</td>
                        <td>{{info.scoreBlue}}</td>
                        <td>{{info.fk_idPlayerRed}}</td>
                        <td>{{info.fk_idPlayerBlue}}</td>
                        <td>{{info.gameDate}}</td>
                    </tr>
            </table>
        </div>
        <br/><br/>
        <router-link to="/managePlayers" tag="button">Manage players</router-link>
        <router-link to="/manageTeams" tag="button">Manage teams</router-link>
    </div>
</template>
<script>
// @ is an alias to /src
import axios from 'axios';

export default {
    name: 'Example component',
    el: "#table",
    data () {
        return {
            infos: null
        }
    },
    mounted () {
        axios
            .get("https://audaciaballapi20200911031401.azurewebsites.net/GetGames")
            .then(response => (this.infos = response.data))
    }
}



</script>
