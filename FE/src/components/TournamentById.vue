<template>
  <q-item>
    <q-item-section>
      <q-item-label>{{ tournament.name }}</q-item-label>
      <q-item-label caption>{{ tournament.description }}</q-item-label>
    </q-item-section>
  </q-item>
</template>

<script setup>
defineOptions({
  name: 'TournamentById'
})

const props = defineProps({
  tournament: {
    type: Object,
    required: true
  }
})

</script>