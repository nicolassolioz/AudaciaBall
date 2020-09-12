<!-- Created by Nicolas Solioz -->
<!-- Last edited 2020-09-12 -->
<template>
    <div class="home">
        <h1>All games played</h1>
        <div id="loader" class="table-center"></div>
        <div id="scoreboard" style="overflow-x:auto;">
            <table id="table" class="table-center">
                <tr>
                    <th>Game ID</th>
                    <th>Blue Score</th>
                    <th>Red Score</th>
                    <th>Blue Team</th>
                    <th>Red Team</th>
                    <th>Date</th>
                </tr>
                <tr v-for="info in infos" :key="info">
                    <td>{{info.idGame}}</td>
                    <td>{{info.scoreBlue}}</td>
                    <td>{{info.scoreRed}}</td>
                    <td>{{info.namePlayerBlue}}</td>
                    <td>{{info.namePlayerRed}}</td>
                    <td>{{info.gameDate.split('T')[0]}}</td>
                </tr>
            </table>
        </div>
        <br/><br/>
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
                infos: null,
                playerName: null
            }
        },
        mounted () {
            //hide table and wait for API to return data and then hide loader
            //get games from API
            document.getElementById("scoreboard").hidden = true;
            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetGames")
                .then((response) => {
                    this.infos = response.data;
                    document.getElementById("loader").hidden = true;
                    document.getElementById("scoreboard").hidden = false;
                })

        }
    }



</script>
