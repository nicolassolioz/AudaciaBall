<!-- Created by Nicolas Solioz -->
<!-- Last edited : 2020-09-12 -->
<template>
    <div class="about">
        <h1>Add player</h1>
        <br />
        <form @submit.stop.prevent="addPlayer()">
            <table class="table-center">
                <tr>
                    <td>Player Name</td>
                    <td>
                        <input type="text" id="playerName" required>
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
        methods: {
            //call API to add player on database
            addPlayer() {
                var playerName = document.getElementById("playerName").value;

                axios
                    .get("https://audaciaballapi20200911031401.azurewebsites.net/AddPlayer/"+playerName)
                    .then(response => {
                        window.location.href = '/managePlayers';
                        console.log(response);
                    })
            }
        }
    }
</script>
