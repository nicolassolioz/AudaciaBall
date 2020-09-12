<template>
    <div class="about">
        <h1>ManagePlayers</h1>
        <router-link to="/addPlayer" tag="button" class="baseButton">Add players</router-link>
        <br /><br />
        <div id="loader" class="table-center"></div>
        <div id="playerTable" style="overflow-x:auto">
            <table id="table" class="table-center">
                <tr>
                    <th>idPlayer</th>
                    <th>Name</th>
                    <th>Game History</th>
                </tr>
                <tr v-for="info in infos" :key="info">
                    <td>{{info.idPlayer}}</td>
                    <td>{{info.name}}</td>
                    <td><router-link :to="'/gameHistory/' + info.idPlayer" tag="button" style="width:auto;" class="baseButton">?</router-link></td>
                </tr>
            </table>
        </div>
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
            document.getElementById("playerTable").hidden = true;
            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetPlayers")
                .then((response) => {
                    this.infos = response.data;
                    document.getElementById("loader").hidden = true;
                    document.getElementById("playerTable").hidden = false;
                })
        }
    }

</script>
