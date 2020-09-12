<template>
    <div class="about">
        <h1>{{winner}}</h1>
        <br />
        <router-link :to="'/game/0/0/'+this.$route.params.idPlayerBlue+'/'+this.$route.params.idPlayerRed" tag="button" class="baseButton">Play again !</router-link>
        <br />
        <router-link to="/" tag="button" class="baseButton">Finish playing</router-link>
    </div>
</template>
<script>
    // @ is an alias to /src
    //import axios from 'axios';

    export default {
        data () {
            return {
                winner: null
            }
        },
        mounted () {
            var scoreBlue = this.$route.params.scoreBlue;
            var scoreRed = this.$route.params.scoreRed;

            if(scoreBlue>scoreRed)
            {
                this.winner = "The blue team won!";
            }
            if(scoreRed>scoreBlue)
            {
                this.winner = "The red team won!";
            }
            if(scoreRed==scoreBlue)
            {
                this.winner = "It's a tie!";
            }
        },
        methods: {

        }
    }
</script>