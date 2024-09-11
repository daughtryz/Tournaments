<template>
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
</script>