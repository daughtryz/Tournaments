import { defineStore } from 'pinia'
import { api } from 'src/axios'

export const useTeamStore = defineStore("teamsStore", {
    state() {
        return {
            teams: []
        }
    },
    actions: {
        getTeams() {
            api.get('/teams')
                .then((response) => {
                    this.teams = response.data
                })
                .catch((ex) => {
                    this.router.push({ name: 'MainPage' })
                    console.log(ex)
                })
        },
        init() {
            this.getTeams()
        }
    },
})