<template>
    <div class="about">
        <h1>Add team</h1>
        <br />
        <form @submit.stop.prevent="addTeam()">
            <table class="table-center">
                <tr>
                    <td>
                        <label>Team name:</label>
                    </td>
                    <td>
                        <input type="text" id="teamName" required>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Player 1:</label>
                    </td>
                    <td>
                        <select id="player1">
                            <option v-for="info in infos" :key="info" :value="info.idPlayer">{{info.name}}</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Player 2:</label>
                    </td>
                    <td>
                        <select id="player2">
                            <option v-for="info in infos" :key="info" :value="info.idPlayer">{{info.name}}</option>
                        </select>
                    </td>
                </tr>
            </table>

            <br />
            <button class="baseButton">Save</button>
        </form>
    </div>
</template>
<script>
    // @ is an alias to /src
    import axios from 'axios';

    export default {
        data () {
            return {
                selected_player: null,
                infos: null
            }
        },
        mounted () {
            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetPlayers")
                .then(response => (this.infos = response.data))
        },
        methods: {
            addTeam() {
                var teamName = document.getElementById("teamName").value;
                var player1 = document.getElementById("player1").value;
                var player2 = document.getElementById("player2").value;

                if(player1 == player2)
                {
                    alert("You can not have two of the same players on a single team.");
                    return;
                }

                axios
                    .get("https://audaciaballapi20200911031401.azurewebsites.net/AddTeam/"+teamName+"/"+player1+"/"+player2)
                    .then(response => {
                        window.location.href = '/manageTeams';
                        console.log(response);
                    })
            }
        }
    }
</script>
