import './assets/main.scss'

import { createApp } from 'vue'
import App from './App.vue'
import Loader from './components/Loader.vue';

const app = createApp(App);
app.component('loader', Loader);
app.mount('#app');
