<template>
  <q-card class="col-xs-12 col-sm-6 col-md-4 col-lg-3 q-mb-md">
    <q-card-section class="bg-primary text-white">
      <div class="text-h6">Tournament: {{ tournament.name }}</div>
    </q-card-section>
    <q-separator />

    <q-card-section>
      <div>
        <q-icon name="event" />
        <span>Start Date: {{ tournament.startDate }}</span>
      </div>
      <div>
        <q-icon name="event_busy" />
        <span>End Date: {{ tournament.endDate }}</span>
      </div>
      <div>
        <q-icon name="group" />
        <span>Teams Involved: {{ tournament.teamsInvolved }}</span>
      </div>
      <div>
        <q-icon name="person" />
        <span>Organizer: {{ tournament.organizer }}</span>
      </div>
      <div>
        <q-icon name="event_busy" />
        <span>Status: {{ isExpired }}</span>
      </div>
    </q-card-section>

    <q-separator />

    <q-card-actions align="right">
      <q-btn lass="glossy" round color="primary" icon="info" @click="viewDetails"></q-btn>
      <q-btn class="glossy" round color="secondary" icon="edit" @click="editPage" />
      <q-btn class="glossy" round color="deep-orange" icon="delete" @click="deleteTournament" />
    </q-card-actions>
  </q-card>
</template>

<script setup>
import { useRouter } from 'vue-router'
import { computed } from 'vue'
import { useTournamentStore } from 'src/stores/tournamentsStore';

defineOptions({
  name: 'TournamentList'
})

const tournamentStore = useTournamentStore()
const router = useRouter();

const isExpired = computed(() => {
  return Date.now() <= props.tournament.endDate ? 'Active' : 'Expired'
})

const editPage = () => {
  const id = props.tournament.id;
  router.push({ name: 'TournamentEditPage', params: { id } })
}

const viewDetails = () => {
  const id = props.tournament.id;
  router.push({ name: 'TournamentDetailsPage', params: { id } })
}

const deleteTournament = () => {
  const id = props.tournament.id;
  tournamentStore.deleteTournament(id)
}

const props = defineProps({
  tournament: {
    type: Object,
    required: true
  }
})
</script>