import { defineStore } from 'pinia'
import { api } from 'src/axios'
import { useAuthStore } from './authStore'

const authStore = useAuthStore()
const headers = { 'Authorization': `Bearer ${authStore.user.accessToken}` };

export const useTournamentStore = defineStore('tournamentsStore', {
    state() {
        return {
            tournaments: []
        }
    },
    actions: {
        getTournaments() {
            console.log(authStore.user.accessToken)
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
            api.put(`/tournaments/${id}`, body, { headers })
                .then((response) => {
                    this.router.push({ name: 'TournamentPage' })
                })
                .catch((ex) => {
                    console.log(ex);
                })
        },
        createTournament(tournament) {
            api.post('/tournaments', tournament, { headers })
                .then((response) => {
                    this.router.push({ name: 'TournamentPage' })
                })
                .catch((ex) => {
                    console.log(ex);
                })
        },
        deleteTournament(id) {
            api.delete(`/tournaments/${id}`, { headers })
                .then((response) => {
                    this.router.push({ name: 'MainPage' })
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