<template>
    <TournamentById
    v-bind="tournament" />
</template>
  
  <script setup>
  defineOptions({
    name: 'IndexPage'
  });

  import { ref, onMounted } from 'vue'
  import { api } from 'boot/axios'
  import TournamentById from 'components/TournamentById.vue'
  import { useRoute } from 'vue-router'
  
  const tournament = ref();
  const route = useRoute();

  onMounted(() => {
    console.log(route.params)
      api.get(`/tournaments/${route.params.id}`)
      .then((response) => {
        tournament.value = response.data
        console.log(tournament.value)
      })
      .catch((ex) => {
        console.log(ex)
      })
  })

  </script>
  