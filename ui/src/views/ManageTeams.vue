<template>
    <div class="about">
        <h1>Manage Teams</h1>
        <router-link to="/addTeam" tag="button">Add team</router-link>
        <br /><br />
        <div id="teamTable">
            <table id="table" class="table-center">
                <tr>
                    <th>idPlayer</th>
                    <th>Name</th>
                    <th>Game History</th>
                </tr>
                <tr v-for="info in infos" :key="info">
                    <td>{{info.idPlayer}}</td>
                    <td>{{info.name}}
                    <td><router-link :to="'/gameHistory/' + info.idPlayer" tag="button">(?)</router-link></td>
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
        el: "#teamTable",
        data () {
            return {
                infos: null
            }
        },
        mounted () {
            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetTeams")
                .then(response => (this.infos = response.data))
        }
    }

</script>