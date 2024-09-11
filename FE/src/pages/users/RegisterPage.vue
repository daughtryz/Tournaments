<template>
  <div class="q-pa-md" style="max-width: 400px">
    <q-form @submit="onSubmit" @reset="onReset" class="q-gutter-md">
      <q-input filled v-model="user.userName" label="Username" hint="Username" lazy-rules
        :rules="[val => val && val.length > 0 || 'Please type something']" />

      <q-input filled v-model="user.email" label="Email" lazy-rules
        :rules="[val => val && val.length > 0 || 'Please type something']" />

      <q-input filled v-model="user.password" type="password" label="Password" lazy-rules
        :rules="[val => val && val.length > 0 || 'Please type something']" />

      <q-input filled v-model="user.confirmPassword" type="password" label="Confirm Password" lazy-rules
        :rules="[val => val && val.length > 0 || 'Please type something']" />

      <div>
        <q-btn label="Submit" type="submit" color="primary" />
        <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>

  </div>
</template>

<script setup>
import { reactive } from 'vue'
import { useAuthStore } from 'src/stores/authStore';

const authStore = useAuthStore()

const user = reactive({
  userName: '',
  email: '',
  password: '',
  confirmPassword: ''
})

const onSubmit = () => {
  authStore.register(user)
}

</script>