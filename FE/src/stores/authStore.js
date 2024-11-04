import { defineStore } from 'pinia'
import { api } from 'src/axios'

export const useAuthStore = defineStore('auth', {
  state() {
    return {
      user: {
        loggedIn: false,
        accessToken: localStorage.getItem('user') ?? null
      }
    }
  },
  actions: {
    login(username, password) {
      api.post('auth/login', {
        username: username,
        password: password
      }).then((response) => {
        console.log(response)
        if (!this.user.accessToken) {
          this.user.accessToken = response.data.access_token
          this.user.username = response.data.username
          localStorage.setItem('user', response.data.access_token)
          localStorage.setItem('expires_at', response.data.expires_at)
          this.user.loggedIn = true
          this.router.push({ name: 'MainPage' })
        }
      })
        .catch((ex) => {
          console.log(ex);
        })
    },
    logout() {
      this.user = {}
      localStorage.removeItem('user')
      localStorage.removeItem('expires_at')
    },
    register(user) {
      api.post('auth/register', user)
        .then((response) => {
          console.log(response.data)
          this.router.push({ name: 'LoginPage' })
        })
        .catch((ex) => {
          console.log(ex);
        })
    }
  }
})
