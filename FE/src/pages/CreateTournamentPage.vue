<template>
  <div class="q-pa-md" style="max-width: 400px">

    <q-form @submit="onSubmit" @reset="onReset" class="q-gutter-md">
      <q-input filled v-model="tournament.name" label="Tournament name" hint="Tournament name" lazy-rules
        :rules="[val => val && val.length > 0 || 'Please type something']" />

      <q-input filled v-model="tournament.description" label="Tournament description" lazy-rules
        :rules="[val => val && val.length > 0 || 'Please type something']" />

      <q-input filled v-model="tournament.organizer" label="Organizer" lazy-rules
        :rules="[val => val && val.length > 0 || 'Please type something']" />

      <q-date v-model="tournament.startDate" />

      <q-date v-model="tournament.endDate" />

      <q-input filled type="number" v-model="tournament.teamsInvolved" label="Teams Involved" />

      <div>
        <q-btn label="Submit" type="submit" color="primary" />
        <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>

  </div>
</template>

<script setup>
import { reactive } from 'vue'
import { useTournamentStore } from 'src/stores/tournamentsStore'

const tournamentStore = useTournamentStore()

const tournament = reactive({
  name: '',
  description: '',
  startDate: '',
  endDate: '',
  organizer: '',
  teamsInvolved: ''
})

const onSubmit = () => {
  tournamentStore.createTournament(tournament)
}

</script>