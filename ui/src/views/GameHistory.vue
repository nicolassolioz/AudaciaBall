<!-- Created by Nicolas Solioz -->
<!-- Last edited 2020-09-12 -->
<template>
    <div class="home">
        <h1>Game History of {{player.name}}</h1>
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
        data () {
            return {
                infos: null,
                player: null
            }
        },
        mounted () {
            //get games played by the player in url
            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetGameHistory/" + this.$route.params.id)
                .then((response) => {
                    this.infos = response.data;

                })

            //get player in url
            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetPlayer/" + this.$route.params.id)
                .then((response) => {
                    this.player = response.data;

            })
        }
    }

</script>
