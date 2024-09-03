<template>
    <div class="q-pa-md" style="max-width: 400px">
    <q-form
      @submit="onSubmit"
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
        v-model="email"
        label="Email"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Please type something']"
      />

        <q-input
        filled
        v-model="password"
        label="password"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Please type something']"
      />

      <q-input
        filled
        v-model="confirmPassword"
        label="confirmPassword"
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
        import { api } from 'boot/axios'
        import { useQuasar } from 'quasar'
        import { ref } from 'vue'
        import { useRouter } from 'vue-router'
    
        const $q = useQuasar()
        const userName = ref(null)
        const email = ref(null)
        const password = ref(null)
        const confirmPassword = ref(null)
        const router = useRouter();

        const onSubmit = () => {
            //loading.value = true;
            api.post('auth/register', {
                userName: userName.value,
                email: email.value,
                password: password.value,
                confirmPassword: confirmPassword.value
            })
            .then((response) => {
                console.log(response.data)
                //loading.value = false;
                router.push({name: 'LoginPage'})
            })
            .catch((ex) => {
                console.log(ex);
            })
          }
    
      </script>    