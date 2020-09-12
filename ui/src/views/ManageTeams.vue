<!-- Created by Nicolas Solioz -->
<!-- Last edited 2020-09-12 -->
<template>
    <div class="about">
        <h1>Manage Teams</h1>
        <router-link to="/addTeam" tag="button" class="baseButton">Add team</router-link>
        <br /><br />
        <div id="loader" class="table-center"></div>
        <div id="teamTable" style="overflow-x:auto;">
            <table id="table" class="table-center">
                <tr>
                    <th>idPlayer</th>
                    <th>Name</th>
                    <th>Game History</th>
                </tr>
                <tr v-for="info in infos" :key="info">
                    <td>{{info.idPlayer}}</td>
                    <td>{{info.name}}
                    <td><router-link :to="'/gameHistory/' + info.idPlayer" tag="button" class="baseButton">?</router-link></td>
                </tr>
            </table>
        </div>
    </div>
</template>
<script>
    // @ is an alias to /src
    import axios from 'axios';

    export default {
        data () {
            return {
                infos: null
            }
        },
        mounted () {
            //hide table and wait for API to return data and then hide loader
            //get teams from API
            document.getElementById("teamTable").hidden = true;
            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetTeams")
                .then((response) => {
                    this.infos = response.data;
                    document.getElementById("loader").hidden = true;
                    document.getElementById("teamTable").hidden = false;
                })
        }
    }

</script>