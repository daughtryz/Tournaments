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
  @reset="onReset"
  v-if="!loading.value"
  class="q-gutter-md"
>
  <q-input
    filled
    v-model="name"
    label="Tournament name"
    hint="Tournament name"
    lazy-rules
    :rules="[ val => val && val.length > 0 || 'Please type something']"
  />

  <q-input
    filled
    v-model="description"
    label="Tournament description"
    lazy-rules
    :rules="[ val => val && val.length > 0 || 'Please type something']"
  />

  <q-input
    filled
    v-model="organizer"
    label="Organizer"
    lazy-rules
    :rules="[ val => val && val.length > 0 || 'Please type something']"
  />

  <q-date
      v-model="startDate"
    />

    <q-date
      v-model="endDate"
    />

    <q-input
        filled
        type="number"
        v-model="teamsInvolved"
        label="Teams Involved"
      />

  <div>
    <q-btn label="Submit" type="submit" color="primary"/>
    <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" />
  </div>
</q-form>

</div>
</template>
  
  <script setup>
    import { api } from 'boot/axios'
    import { useQuasar } from 'quasar'
    import { ref } from 'vue'
    import { useRouter } from 'vue-router'

    const $q = useQuasar()
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
        api.post('/tournaments', {
            name: name.value,
            description: description.value,
            startDate: startDate.value,
            endDate: endDate.value,
            organizer: organizer.value,
            teamsInvolved: teamsInvolved.value
        })
        .then((response) => {
            console.log(response.data)
            loading.value = false;
            router.push({name: 'TournamentPage'})
        })
        .catch((ex) => {
            // $q.notify({
            // color: 'negative',
            // position: 'top',
            // message: 'Loading failed',
            // icon: 'report_problem'
            // })
            console.log(ex);
        })
      }

  </script>
  