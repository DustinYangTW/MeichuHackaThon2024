import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

/* import the fontawesome core */
import { library } from '@fortawesome/fontawesome-svg-core';

/* import font awesome icon component */
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

/* import specific icons */
import {
  faArrowsDownToLine, faArrowsTurnRight, faUserPlus, faCaretDown, faBars, faUpload, faCopy, faMagnifyingGlass, faShoePrints, faBicycle, faBus, faForwardStep, faBackwardStep
} from '@fortawesome/free-solid-svg-icons';

/* add icons to the library */
library.add(faArrowsDownToLine, faArrowsTurnRight, faUserPlus, faCaretDown, faBars, faUpload, faCopy, faMagnifyingGlass, faShoePrints, faBicycle, faBus, faForwardStep, faBackwardStep);

const app = createApp(App)

app.use(createPinia())
app.use(router)
app.component('font-awesome-icon', FontAwesomeIcon);
app.mount('#app')
