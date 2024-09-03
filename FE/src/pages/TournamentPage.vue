<template>
  <q-page padding>
    <q-btn to="tournaments/create" round>
      <q-avatar size="42px">
        <img src="create.png">
      </q-avatar>
    </q-btn>
    <div class="q-pa-md">
      <q-list>
        <q-item-label
          header
        >
          Tournaments
        </q-item-label>
          <TournamentList
              v-for="tournament in data"
              :key="tournament.name"
              v-bind="tournament"
          />
      </q-list>
  </div>
  </q-page>
</template>

<script setup>

import { ref, onMounted } from 'vue'
import axios, { api } from 'boot/axios'
import { useQuasar } from 'quasar'
import { useRouter } from 'vue-router'
import TournamentList from 'components/TournamentList.vue'

const $q = useQuasar()

  const data = ref()
  const router = useRouter();

  onMounted(() => {
    console.log('In the mount')
    console.log(axios);
      api.get('/tournaments')
      .then((response) => {
        data.value = response.data
        console.log(response.data.status)
      })
      .catch((ex) => {
        router.push({ name: 'MainPage' })
        console.log(ex)
      })
})

</script>