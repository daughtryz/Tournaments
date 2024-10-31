<template>
  <q-page padding>
    <q-btn to="tournaments/create" round>
      <q-avatar size="42px">
        <img src="create.png">
      </q-avatar>
    </q-btn>
    <div class="q-pa-md">
      <q-list>
        <q-item-label header>
          Tournaments
        </q-item-label>
        <div class="q-pa-md row items-start q-gutter-md">
          <TournamentList v-for="tournament in tournamentStore.tournaments" :key="tournament.name"
            :tournament="tournament" />
        </div>
      </q-list>
    </div>
  </q-page>
</template>

<script setup>
import TournamentList from 'components/TournamentList.vue'
import { useTournamentStore } from 'src/stores/tournamentsStore';
import { onMounted } from 'vue';

const tournamentStore = useTournamentStore()

onMounted(() => {
  tournamentStore.init()
})
</script>