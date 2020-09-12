<!-- Created by Nicolas Solioz -->
<!-- Last edited 2020-09-12 -->
<template>
    <div class="about">
        <h1>Game</h1>
        <br /><br />
        <form @submit.stop.prevent="addGame()">
            <table class="table-center">
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <h1 style="text-align:center;">Blue team</h1>
                    </td>
                    <td colspan="2" style="text-align: center;">
                        <h1>Red team</h1>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" id="pointsBlue">
                        <input type="text" id="scoreBlue" :value="scoreBlue" disabled="disabled" style="text-align: center; font-size:30px; width:50px"/>
                    </td>
                    <td colspan="2" id="pointsRed">
                        <input type="text" id="scoreRed" :value="scoreRed" disabled="disabled" style="text-align: center; font-size:30px; width:50px"/>
                    </td>
                </tr>
                <tr>
                    <td><button type="button" @click="addBlue()" class="baseButton">+</button></td>
                    <td><button type="button" @click="removeBlue()" class="baseButton">-</button></td>
                    <td><button type="button" @click="addRed()" class="baseButton">+</button></td>
                    <td><button type="button" @click="removeRed()" class="baseButton">-</button></td>
                </tr>
            </table>

            <br />
            <button class="baseButton">End game</button>
            <router-link to="/" tag="button" class="baseButton">Quit game</router-link>
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
                scoreBlue: 0,
                scoreRed: 0
            }
        },
        mounted () {
            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetTeams")
                .then(response => (this.infos = response.data))

            this.scoreBlue = this.$route.params.scoreBlue;
            this.scoreRed = this.$route.params.scoreRed;
        },
        methods: {
            //add point to blue
            addBlue() {
                var value = parseInt(document.getElementById('scoreBlue').value, 10);
                value = isNaN(value) ? 0 : value;
                if(value == 10)
                    return;
                value++;
                document.getElementById('scoreBlue').value = value;
            },

            //add point to red
            addRed() {
                var value = parseInt(document.getElementById('scoreRed').value, 10);
                value = isNaN(value) ? 0 : value;
                if(value == 10)
                    return;
                value++;
                document.getElementById('scoreRed').value = value;
            },

            //remove point from blue
            removeBlue() {
                var value = parseInt(document.getElementById('scoreBlue').value, 10);
                value = isNaN(value) ? 0 : value;
                if(value == 0)
                    return;
                value--;
                document.getElementById('scoreBlue').value = value;
            },

            //remove point from red
            removeRed() {
                var value = parseInt(document.getElementById('scoreRed').value, 10);
                value = isNaN(value) ? 0 : value;
                if(value == 0)
                    return;
                value--;
                document.getElementById('scoreRed').value = value;
            },

            //insert game via API
            addGame() {
                var scoreBlue = document.getElementById("scoreBlue").value;
                var scoreRed = document.getElementById("scoreRed").value;
                var idPlayerBlue = this.$route.params.idPlayerBlue;
                var idPlayerRed = this.$route.params.idPlayerRed;

                axios
                    .get("https://audaciaballapi20200911031401.azurewebsites.net/AddGame/"+scoreBlue+"/"+scoreRed+"/"+idPlayerBlue+"/"+idPlayerRed)
                    .then(response => {
                        window.location.href = '/EndGame/'+scoreBlue+'/'+scoreRed+'/'+idPlayerBlue+'/'+idPlayerRed;
                        console.log(response);
                    })
            }
        }
    }
</script>