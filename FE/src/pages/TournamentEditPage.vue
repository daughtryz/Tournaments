<template>
    <div class="q-pa-md" style="max-width: 400px">
<!-- Loading Screen -->
<div v-if="loading.value" class="loading-overlay">
  <q-circular-progress
    indeterminate
    rounded
    size="200px"
    :thickness="0.2"
    color="lime"
    class="q-ma-md"
  />
</div>

<q-form
  @submit="onSubmit"
  v-if="!loading.value"
  class="q-gutter-md"
>
  <q-input
    filled
    v-model="name"
    type="text"
    label="Tournament name"
    hint="Tournament name"
    lazy-rules
    :rules="[ val => val && val.length > 0 || 'Please type something']"
  />

  <q-input
    filled
    type="text"
    v-model="description"
    label="Tournament description"
    lazy-rules
    :rules="[ val => val && val.length > 0 || 'Please type something']"
  />

  <q-input
    filled
    type="text"
    v-model="organizer"
    label="Organizer"
    lazy-rules
    :rules="[ val => val && val.length > 0 || 'Please type something']"
  />

  <q-date
      v-model="startDate"
      mask="YYYY-MM-DD"
    />

    <q-date
        v-model="endDate"
        mask="YYYY-MM-DD"
    />

    <q-input
        filled
        type="number"
        v-model="teamsInvolved"
        label="Teams Involved"
      />

  <div>
    <q-btn label="Submit" type="submit" color="primary"/>
  </div>
</q-form>

</div>
</template>
  
  <script setup>
  import { ref, onMounted } from 'vue'
  import { api } from 'boot/axios'
  import { useRouter, useRoute } from 'vue-router'
  
    const tournament = ref();
    const route = useRoute();

    const loading = ref(false);
    const name = ref(null)
    const description = ref(null)
    const startDate = ref(null)
    const endDate = ref(null)
    const organizer = ref(null)
    const teamsInvolved = ref(0)
    const router = useRouter();

    const onSubmit = () => {
        loading.value = true;
        const body = {
            name: name.value,
            description: description.value,
            startDate: startDate.value,
            endDate: endDate.value,
            organizer: organizer.value,
            teamsInvolved: teamsInvolved.value
        };

        api.put(`/tournaments/${route.params.id}`, body)
        .then((response) => {
            console.log(response.data)
            loading.value = false;
            router.push({name: 'TournamentPage'})
        })
        .catch((ex) => {
            console.log(ex);
        })
      }

  onMounted(() => {
    console.log(route.params)
      api.get(`/tournaments/${route.params.id}`)
      .then((response) => {
        tournament.value = response.data
        name.value = tournament.value.name;
        description.value = tournament.value.description;
        startDate.value = tournament.value.startDate;
        endDate.value = tournament.value.endDate;
        teamsInvolved.value = tournament.value.teamsInvolved;
        organizer.value = tournament.value.organizer;
        console.log(tournament.value)
      })
      .catch((ex) => {
        console.log(ex)
      })
  })

  </script>
  