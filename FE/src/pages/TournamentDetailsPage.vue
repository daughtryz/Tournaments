<template>
    <TournamentById
    v-bind="tournament" />
</template>
  
  <script setup>
  import TournamentById from 'components/TournamentById.vue'
  import { useRoute } from 'vue-router'
  import { useTournamentStore } from 'src/stores/tournamentsStore'
  
  const tournamentStore = useTournamentStore()

  const route = useRoute();

  const tournament = tournamentStore.getTournamentById(route.params.id)

  </script>
  