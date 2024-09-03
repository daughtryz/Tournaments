<template>
    <div class="q-pa-md" style="max-width: 400px">
    <!-- Loading Screen -->
<div v-if="loading">
    <div class="q-gutter-md row">
      <q-spinner
        color="primary"
        size="3em"
        :thickness="2"
      />
    </div>
</div>

    <q-form
      @submit="onSubmit"
      v-else
      @reset="onReset"
      class="q-gutter-md"
    >
      <q-input
        filled
        v-model="userName"
        label="Username"
        hint="Username"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Please type something']"
      />

        <q-input
        filled
        v-model="password"
        label="Password"
        type="password"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Please type something']"
      />
    
      <div>
        <q-btn label="Submit" type="submit" color="primary"/>
        <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>
    
    </div>
    </template>
      
<script setup>
        import { ref } from 'vue'
        import { useRouter } from 'vue-router'
        import { useAuthStore } from 'src/stores/authStore.js'

        const userName = ref(null)
        const password = ref(null)
        const router = useRouter();
        const authStore = useAuthStore();
        const loading = ref(false)
        
        const onSubmit = () => {
            loading.value = true
            setTimeout(() => {
                console.log("Delayed for 5 seconds.");
                authStore.login(userName, password)
                loading.value = false
                router.push({name: 'MainPage'})
            }, 3000);
            //authStore.login(userName, password)
        }
</script>    