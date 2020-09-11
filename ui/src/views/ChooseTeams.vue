<template>
    <div class="about">
        <h1>Choose team</h1>
        <br />
        <select>
            <option v-for="info in infos" :key="info">{{info.name}}</option>
        </select>
        <br /><br />
        <router-link to="/game">Go !</router-link>
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
                .get("https://audaciaballapi20200911031401.azurewebsites.net/GetTeams")
                .then(response => (this.infos = response.data))
        }
    }



</script>