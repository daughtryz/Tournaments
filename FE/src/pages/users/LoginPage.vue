<template>
  <div class="q-pa-md" style="display: flex; justify-content: center;">
    <div style="max-width: 600px; width: 100%; padding: 20px;">
      <q-form @submit="onSubmit" @reset="onReset" class="q-gutter-md">
        <q-input filled v-model="userName" label="Username" hint="Username" lazy-rules
          :rules="[val => val && val.length > 0 || 'Please type something']" />

        <q-input filled v-model="password" label="Password" type="password" lazy-rules
          :rules="[val => val && val.length > 0 || 'Please type something']" />

        <div>
          <q-btn label="Submit" type="submit" color="primary" />
          <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" />
        </div>
      </q-form>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { useAuthStore } from 'src/stores/authStore.js'

const userName = ref('')
const password = ref('')
const router = useRouter();
const authStore = useAuthStore();
const loading = ref(false)

const onSubmit = () => {
  loading.value = true
  authStore.login(userName.value, password.value)
}
</script>