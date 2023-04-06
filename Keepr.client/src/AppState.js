import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  // all keeps
  keeps: [],

  // active keep that was clicked on
  keep: null,


  // vault page I  am currently on....
  vault: null,
  keepsInVault: [],

  profile: null,

  // used for the logged in user
  accountKeeps: [],
  accountVaults: [],

  // used for the other visited profile
  profileKeeps: [],
  profileVaults: [],
})
