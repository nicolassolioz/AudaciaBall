import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
    },
    {
        path: '/addPlayer',
        name: 'addPlayer',
        component: () => import('../views/AddPlayer.vue')
    },
    {
        path: '/addTeam',
        name: 'addTeam',
        component: () => import('../views/AddTeam.vue')
    },
    {
        path: '/choosePlayers',
        name: 'choosePlayers',
        component: () => import('../views/ChoosePlayers.vue')
    },
    {
        path: '/chooseTeams',
        name: 'chooseTeams',
        component: () => import('../views/ChooseTeams.vue')
    },
    {
        path: '/choosePlayers',
        name: 'choosePlayers',
        component: () => import('../views/ChoosePlayers.vue')
    },
    {
        path: '/endGame',
        name: 'endGame',
        component: () => import('../views/EndGame.vue')
    },
    {
        path: '/game',
        name: 'game',
        component: () => import('../views/Game.vue')
    },
    {
        path: '/gameHistory',
        name: 'gameHistory',
        component: () => import('../views/GameHistory.vue')
    },
    {
        path: '/gameType',
        name: 'gameType',
        component: () => import('../views/GameType.vue')
    }
    
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
