<template>
  <div class="q-pa-md" style="display: flex; justify-content: center;">
    <!-- Loading Screen -->
    <!-- <div v-if="loading.value" class="loading-overlay">
      <q-circular-progress indeterminate rounded size="200px" :thickness="0.2" color="lime" class="q-ma-md" />
    </div> -->

    <q-form class="q-gutter-md" @submit="onSubmit">
      <q-input filled v-model="tournament.name" type="text" label="Tournament name" hint="Tournament name" lazy-rules
        :rules="[val => val && val.length > 0 || 'Please type something']" />

      <q-input filled type="text" v-model="tournament.description" label="Tournament description" lazy-rules
        :rules="[val => val && val.length > 0 || 'Please type something']" />

      <q-input filled type="text" v-model="tournament.organizer" label="Organizer" lazy-rules
        :rules="[val => val && val.length > 0 || 'Please type something']" />

      <q-date v-model="tournament.startDate" mask="YYYY-MM-DD" />

      <q-date v-model="tournament.endDate" mask="YYYY-MM-DD" />

      <q-input filled type="number" v-model="tournament.teamsInvolved" label="Teams Involved" />

      <div>
        <q-btn label="Submit" type="submit" color="primary" />
      </div>
    </q-form>

  </div>
</template>

<script setup>
import { onMounted, onUnmounted, reactive, ref } from 'vue'
import { useRoute } from 'vue-router'
import { useTournamentStore } from 'src/stores/tournamentsStore';

const route = useRoute();
const tournamentStore = useTournamentStore()

const tournament = reactive(tournamentStore.getTournamentById(route.params.id))

const onSubmit = () => {
  const body = {
    name: tournament.name,
    description: tournament.description,
    startDate: tournament.startDate,
    endDate: tournament.endDate,
    organizer: tournament.organizer,
    teamsInvolved: tournament.teamsInvolved
  };

  tournamentStore.editTournament(route.params.id, body)
}

</script>
