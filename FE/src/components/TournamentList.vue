<template>
  <q-card class="full-height">
    <q-card-section class="bg-primary text-white">
      <div class="text-h6 ellipsis">Tournament: {{ tournament.name }}</div>
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
    <q-card-actions align="right" class="q-pt-none q-mt-auto">
      <q-btn lass="glossy" round color="primary" icon="info" @click="viewDetails"></q-btn>
      <q-btn class="glossy" round color="secondary" icon="edit" @click="editPage" />

      <q-btn @click="modals.deleteTournament = !modals.deleteTournament" class="glossy" round color="deep-orange"
        icon="delete" />
      <DeleteTournamentModal :id="tournament.id" v-if="modals.deleteTournament" v-model="modals.deleteTournament" />
    </q-card-actions>
  </q-card>
</template>

<script setup>
import { useRouter } from 'vue-router'
import { computed, reactive } from 'vue'
import DeleteTournamentModal from './DeleteTournamentModal.vue';

defineOptions({
  name: 'TournamentList'
})

const router = useRouter();
const modals = reactive({
  deleteTournament: false
})

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

const props = defineProps({
  tournament: {
    type: Object,
    required: true
  }
})
</script>

<style scoped>
.full-height {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  min-height: 250px;
  /* Set a minimum height to ensure uniformity */
}

.ellipsis {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.q-card-section {
  flex-grow: 1;
}
</style>