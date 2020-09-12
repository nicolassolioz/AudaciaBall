<!-- Created by Nicolas Solioz -->
<!-- Last edited 2020-09-12 -->
<template>
    <div class="about">
        <h1>Choose teams</h1>
        <br />
        <form @submit.stop.prevent="launchGame()">
            <table class="table-center">
                <tr>
                    <td>
                        <label>Blue team:</label>
                    </td>
                    <td>
                        <select id="playerBlue">
                            <option v-for="info in infos" :key="info" :value="info.idPlayer">{{info.name}}</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Red team:</label>
                    </td>
                    <td>
                        <select id="playerRed">
                            <option v-for="info in infos" :key="info" :value="info.idPlayer">{{info.name}}</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Start score blue</label>
                    </td>
                    <td>
                        <select id="startScoreBlue">
                            <option value="0">0</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Start score red</label>
                    </td>
                    <td>
                        <select id="startScoreRed">
                            <option value="0">0</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                        </select>
                    </td>
                </tr>
            </table>
            <br />
            <button class="baseButton">Go!</button>
        </form>


        <br /><br />

    </div>
</template>
<script>
    // @ is an alias to /src
    import axios from 'axios';

    export default {
        data () {
            return {
                infos: null,
                startScoreBlue: 0,
                startScoreRed: 0
            }
        },
        mounted () {
            //get all players that are a team with API
            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetTeams")
                .then(response => (this.infos = response.data))
        },
        methods: {
            launchGame() {
                var playerBlue = document.getElementById("playerBlue").value;
                var playerRed = document.getElementById("playerRed").value;
                var startScoreBlue = document.getElementById("startScoreBlue").value;
                var startScoreRed = document.getElementById("startScoreRed").value;

                //check that the teams are not the same
                if (playerBlue == playerRed) {
                    alert("You can't play against yourself, silly!");
                    return;
                }
                //open game vue with desired parameters
                window.location.href = '/Game/'+startScoreBlue+'/'+startScoreRed+'/'+playerBlue+'/'+playerRed;
            }
        }
    }



</script>