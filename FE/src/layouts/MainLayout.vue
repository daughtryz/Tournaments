<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn flat dense round icon="menu" aria-label="Menu" @click="toggleLeftDrawer" />

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

        <NavBar />
      </q-toolbar>
    </q-header>

    <q-drawer v-model="leftDrawerOpen" show-if-above bordered>
      <q-list>
        <q-item-label header>
          Tournaments Section
        </q-item-label>

        <EssentialLink v-for="link in linksList" :key="link.title" v-bind="link" />
      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import EssentialLink from 'components/EssentialLink.vue'
import NavBar from 'src/components/NavBar.vue';

defineOptions({
  name: 'MainLayout'
})

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

const leftDrawerOpen = ref(false)

function toggleLeftDrawer() {
  leftDrawerOpen.value = !leftDrawerOpen.value
}
</script>
