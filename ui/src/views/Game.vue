<template>
    <div class="about">
        <h1>Game</h1>
        <br /><br />
        <form>
        <table class="table-center">
            <tr style="font-size: 100px;">
                <th colspan="2" style="padding-right: 50px; text-align: center;" id="scoreBlue">
                    <input type="text" id="pointsBlue" :value="scoreBlue"/>
                </th>
                <th colspan="2" style="padding-left: 50px;" id="scoreRed">
                    <input type="text" id="pointsRed" :value="scoreRed"/>
                </th>
            </tr>
            <tr>
                <td><button type="button" @click="addBlue()">+</button></td>
                <td><button type="button" @click="removeBlue()">-</button></td>
                <td><button type="button" @click="addRed()">+</button></td>
                <td><button type="button" @click="removeRed()">+</button></td>
            </tr>
        </table>
        </form>
        <br /><br />
        <router-link to="/endGame">End Game</router-link>
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
                scoreBlue: 0,
                scoreRed: 0
            }
        },
        mounted () {
            axios
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetTeams")
                .then(response => (this.infos = response.data))
        },
        methods: {
            addBlue() {
                var value = parseInt(document.getElementById('pointsBlue').value, 10);
                value = isNaN(value) ? 0 : value;
                if(value == 10)
                    return;
                value++;
                document.getElementById('pointsBlue').value = value;
            },
            addRed() {
                var value = parseInt(document.getElementById('pointsRed').value, 10);
                value = isNaN(value) ? 0 : value;
                if(value == 10)
                    return;
                value++;
                document.getElementById('pointsRed').value = value;
            },
            removeBlue() {
                var value = parseInt(document.getElementById('pointsBlue').value, 10);
                value = isNaN(value) ? 0 : value;
                if(value == 0)
                    return;
                value--;
                document.getElementById('pointsBlue').value = value;
            },
            removeRed() {
                var value = parseInt(document.getElementById('pointsRed').value, 10);
                value = isNaN(value) ? 0 : value;
                if(value == 0)
                    return;
                value--;
                document.getElementById('pointsRed').value = value;
            }
        }
    }



</script>