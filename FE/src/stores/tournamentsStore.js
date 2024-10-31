import { defineStore } from 'pinia'
import { api } from 'src/axios'
import { useAuthStore } from './authStore'

export const useTournamentStore = defineStore('tournamentsStore', {
    state() {
        return {
            tournaments: []
        }
    },
    actions: {
        getTournaments() {
            const authStore = useAuthStore()
            const headers = { 'Authorization': `Bearer ${authStore.user.accessToken}` };
            api.get('/tournaments', { headers })
                .then((response) => {
                    this.tournaments = response.data
                })
                .catch((ex) => {
                    this.router.push({ name: 'MainPage' })
                    console.log(ex)
                })
        },
        getTournamentById(tournamentId) {
            console.log('in the get tournamned id pinia')
            let result = this.tournaments.find(x => x.id === tournamentId)
            console.log(result)
            return result
        },
        editTournament(id, body) {
            const authStore = useAuthStore()
            const headers = { 'Authorization': `Bearer ${authStore.user.accessToken}` };
            api.put(`/tournaments/${id}`, body, { headers })
                .then((response) => {
                    this.router.push({ name: 'TournamentPage' })
                })
                .catch((ex) => {
                    console.log(ex);
                })
        },
        createTournament(tournament) {
            const authStore = useAuthStore()
            const headers = { 'Authorization': `Bearer ${authStore.user.accessToken}` };
            api.post('/tournaments', tournament, { headers })
                .then((response) => {
                    this.router.push({ name: 'TournamentPage' })
                })
                .catch((ex) => {
                    console.log(ex);
                })
        },
        deleteTournament(id) {
            const authStore = useAuthStore()
            const headers = { 'Authorization': `Bearer ${authStore.user.accessToken}` };
            api.delete(`/tournaments/${id}`, { headers })
                .then((response) => {
                    const currentTournamentIndex = this.tournaments.findIndex(x => x.id === id)
                    this.tournaments.splice(currentTournamentIndex, 1)
                })
                .catch((ex) => {
                    console.log(ex);
                })
        },
        init() {
            this.getTournaments()
        }
    }
})
