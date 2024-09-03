<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="toggleLeftDrawer"
        />

        <q-toolbar-title>
          Tournaments App
        </q-toolbar-title>

          <!-- <q-toolbar-title v-if="authStore.username">
          Welcome, {{ authStore.username }}
          </q-toolbar-title> -->

          <!-- <q-tabs
          v-if="authStore.username"
        v-model="authStore.username"
        shrink>
      <q-tab
        v-for="tab in tabs"
        :key="tab.username"
        :name="tab.username"
        :label="tab.username"
      />
    </q-tabs> -->

        <q-btn v-if="!authStore.isAuthenticated" flat @click="loginPage" label="Login" />
        <q-btn v-if="!authStore.isAuthenticated" flat @click="register" label="Register" />
        <q-btn v-if="authStore.isAuthenticated" flat @click="logout" label="Logout" />
      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      show-if-above
      bordered
    >
      <q-list>
        <q-item-label
          header
        >
          Tournaments Section
        </q-item-label>

        <EssentialLink
          v-for="link in linksList"
          :key="link.title"
          v-bind="link"
        />
      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script setup>
import { ref, onMounted, onUpdated } from 'vue'
import { useRouter } from 'vue-router'
import EssentialLink from 'components/EssentialLink.vue'
import { useAuthStore } from 'src/stores/authStore.js'

defineOptions({
  name: 'MainLayout'
})
const router = useRouter();

const linksList = [
  {
    title: 'Main Page',
    icon: 'school',
    link: '/'
  },
  {
    title: 'Incoming Tournaments',
    icon: 'school',
    link: '/tournaments'
  }
]

const token = ref(localStorage.getItem('user'))
const hasToken = ref(false)

// onUpdated(() => {
//   //console.log('isAuthenticated is ' + authStore.isAuthenticated)
//   console.log('onUpdated: token' + token)
//   console.log('onUpdated: hasToken is ' + hasToken.value)
//   if(token.value) {
//     hasToken.value = true;
//   } else {
//     hasToken.value = false;
//   }
// })

onMounted(() => {
  console.log(authStore.isAuthenticated.value)
})
  
// const tabs = ref([
//       { name: 'tab1', label: authStore.username || 'Profile' },
//       { name: 'tab2', label: 'Settings' },
//       { name: 'tab3', label: 'Notifications' },
//     ]);

const authStore = useAuthStore()

const register = () => {
  router.push({name: 'RegisterPage'})
}
const loginPage = () => {
  router.push({name: 'LoginPage'})
}
const logout = () => {
  authStore.logout();
  token.value = null
  router.push({name: 'MainPage'})
}
const leftDrawerOpen = ref(false)

function toggleLeftDrawer () {
  leftDrawerOpen.value = !leftDrawerOpen.value
}
</script>
