import { defineStore } from 'pinia'
import { ref } from 'vue'
import { api } from 'boot/axios'

export const useAuthStore = defineStore('auth', () => {
  const token = ref(localStorage.getItem('user')); 
  const isAuthenticated = ref(!!token.value);
  const username = ref(null)

  const login = (userName, password) => {
    const user = ref()

    api.post('auth/login', {
      userName: userName.value,
      password: password.value
    })
    .then((response) => {
      user.value = response.data.access_token
      localStorage.setItem('user', user.value)
      username.value = response.data.username
      isAuthenticated.value = true;
    })
    .catch((ex) => {
      console.log(ex);
    })
  }

  const logout = () => {
    localStorage.removeItem('user');
    isAuthenticated.value = false;
  }

  return { isAuthenticated, login, logout, username }
})
