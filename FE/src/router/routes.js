import { api } from 'src/axios.js'
import { ref } from 'vue'

const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', name: 'MainPage', component: () => import('pages/IndexPage.vue'), },
      { path: '/error', name: 'NotFound', component: () => import('pages/ErrorNotFound.vue'), },
      { path: 'tournaments', name: 'TournamentPage', component: () => import('pages/TournamentPage.vue') },
      { path: 'tournaments/create', component: () => import('pages/CreateTournamentPage.vue') },
      {
        path: 'tournaments/:id',
        name: 'TournamentDetailsPage',
        component: () => import('pages/TournamentDetailsPage.vue'),
        props: route => ({ ...route.params, id: route.params.id })
      },
      { path: 'tournaments/edit/:id', name: 'TournamentEditPage', component: () => import('pages/TournamentEditPage.vue') },
      { path: 'register', name: 'RegisterPage', component: () => import('pages/users/RegisterPage.vue') },
      { path: 'login', name: 'LoginPage', component: () => import('pages/users/LoginPage.vue') },
      { path: 'teams', name: 'TeamPage', component: () => import('pages/teams/TeamsPage.vue') },
      { path: '/notauthorized', name: 'NotAuhorized', component: () => import('pages/NotAuthorized.vue'), },
    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue')
  }
]

export default routes
