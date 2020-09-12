<!-- Created by Nicolas Solioz -->
<!-- Last edited 2020-09-12 -->

<!-- choose if you want to play 1v1 (player vs player) or 2v2 (team vs team) -->
<template>
    <div class="about">
        <h1>Game type</h1>
        <br />
        <router-link to="/choosePlayers" tag="button" class="baseButton">1 vs 1</router-link>
        <br /><br />
        <router-link to="/chooseTeams" tag="button" class="baseButton">2 vs 2</router-link>
        <br />
    </div>
</template>
