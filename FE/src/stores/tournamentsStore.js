import { defineStore } from 'pinia'
import { api } from 'src/axios'

export const useTournamentStore = defineStore('tournamentsStore', {
    state() {
        return {
            tournaments: []
        }
    },
    actions: {
        getTournaments() {
            api.get('/tournaments')
                .then((response) => {
                    console.log(response)
                    this.tournaments = response.data
                })
                .catch((ex) => {
                    if (ex.response.status == 401) {
                        this.router.push({ name: 'NotAuhorized' })
                    }
                })
        },
        getTournamentById(tournamentId) {
            console.log('in the get tournamned id pinia')
            let result = this.tournaments.find(x => x.id === tournamentId)
            console.log(result)
            return result
        },
        editTournament(id, body) {
            api.put(`/tournaments/${id}`, body)
                .then((response) => {
                    this.router.push({ name: 'TournamentPage' })
                })
                .catch((ex) => {
                    console.log(ex);
                })
        },
        createTournament(tournament) {
            api.post('/tournaments', tournament)
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
