<template>
    <div class="about">
        <h1>ManagePlayers</h1>
        <router-link to="/addPlayer" tag="button">Add players</router-link>
        <br /><br />
        <div id="playerTable">
            <table id="table" class="table-center">
                <tr>
                    <th>idPlayer</th>
                    <th>Name</th>
                    <th>Game History</th>
                </tr>
                <tr v-for="info in infos" :key="info">
                    <td>{{info.idPlayer}}</td>
                    <td>{{info.name}}</td>
                    <td><router-link to="/gameHistory" tag="button">(?)</router-link></td>
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
            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetPlayers")
                .then(response => (this.infos = response.data))
        }
    }

</script>
