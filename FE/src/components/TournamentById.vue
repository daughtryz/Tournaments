<template>
    <q-item> 
      <q-item-section>
        <q-item-label>{{ props.name }}</q-item-label>
        <q-item-label caption>{{ props.description }}</q-item-label>
      </q-item-section>
    </q-item>
  </template>
  
  <script setup>
import { ref, onMounted } from 'vue'

  defineOptions({
    name: 'TournamentById'
  })

  onMounted(() => {
    console.log('props in the TournamentById' + props);
  })

  const props = defineProps({
    name: {
      type: String,
      required: true
    },
    id: {
      type: String,
      required: true
    },
    description: {
      type: String,
      default: ''
    },
    organizer: {
      type: String,
      default: ''
    },
    startDate: {
      type: Date,
      default: '#'
    },
    endDate: {
      type: Date,
      default: '#'
    },
    teamsInvolved: {
      type: Number,
      default: 0
    }
  })

  </script>
  