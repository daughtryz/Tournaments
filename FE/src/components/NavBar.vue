<template>
    <div class="main-nav">
        <q-btn flat @click="goToHomepage" label="HOMEPAGE" />
        <q-btn flat @click="goToTournamentsPage" label="Tournaments" />
        <q-btn flat @click="goToTeamsPage" label="Teams" />
    </div>
    <div v-if="authStore.user.username" class="username">
        Welcome {{ authStore.user.username }}
    </div>
    <q-btn v-if="!authStore.user.accessToken" flat @click="loginPage" label="Login" />
    <q-btn v-if="!authStore.user.accessToken" flat @click="register" label="Register" />
    <q-btn v-if="authStore.user.accessToken" flat @click="logout" label="Logout" />
</template>

<script setup>
import { useAuthStore } from 'src/stores/authStore.js'
import { useRouter } from 'vue-router';

const authStore = useAuthStore()
const router = useRouter()

const register = () => {
    router.push({ name: 'RegisterPage' })
}
const loginPage = () => {
    router.push({ name: 'LoginPage' })
}
const logout = () => {
    authStore.logout()
    router.push({ name: 'MainPage' })
}
const goToTournamentsPage = () => {
    router.push({ name: 'TournamentPage' })
}

const goToTeamsPage = () => {
    router.push({ name: 'TeamPage' })
}

const goToHomepage = () => {
    router.push({ name: 'MainPage' })
}
</script>

<style>
.main-nav {
    display: flex;
    justify-content: left;
    float: left;
}
</style>