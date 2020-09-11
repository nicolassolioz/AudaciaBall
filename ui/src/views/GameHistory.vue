<template>
    <div class="home">
        <h1>Game History of {{player.name}}</h1>
        <div id="scoreboard">
            <table id="table" class="table-center">
                <tr>
                    <th>idGame</th>
                    <th>score red</th>
                    <th>score blue</th>
                    <th>blue team</th>
                    <th>red team</th>
                    <th>date</th>
                </tr>
                <tr v-for="info in infos" :key="info">
                    <td>{{info.idGame}}</td>
                    <td>{{info.scoreRed}}</td>
                    <td>{{info.scoreBlue}}</td>
                    <td>{{info.fk_idPlayerRed}}</td>
                    <td>{{info.fk_idPlayerBlue}}</td>
                    <td>{{info.gameDate}}</td>
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
                player: null
            }
        },
        mounted () {
            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetGameHistory/" + this.$route.params.id)
                .then(response => (this.infos = response.data))

            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetPlayer/" + this.$route.params.id)
                .then(response => (this.player = response.data))
        }
    }

</script>
