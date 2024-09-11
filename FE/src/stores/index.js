import { store } from 'quasar/wrappers'
import { createPinia } from 'pinia'
import { markRaw } from 'vue'
import route from 'src/router/index.js'

/*
 * If not building with SSR mode, you can
 * directly export the Store instantiation;
 *
 * The function below can be async too; either use
 * async/await or return a Promise which resolves
 * with the Store instance.
 */
const Router = route()

export default store((/* { ssrContext } */) => {
  const pinia = createPinia()
  pinia.use(({ store }) => {
    store.router = markRaw(Router)
  })
  // You can add Pinia plugins here
  // pinia.use(SomePiniaPlugin)
  return pinia
})
