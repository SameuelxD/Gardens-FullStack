// main.js
import { createApp } from 'vue';
import App from './App.vue';
import router from './Router/index.js'; // Importamos el enrutador desde su ubicación

const app = createApp(App);

app.use(router);

app.mount('#app');
