<template>
  <div id="app">
    <!-- Mostrar SignUp solo en la ruta /signup -->
    <router-view v-if="!loggedIn && $route.name === 'SignUp'" @registration-success="redirectToSignIn" />

    <!-- Mostrar SignIn solo en la ruta /signin -->
    <router-view v-if="!loggedIn && $route.name === 'SignIn'" @authentication-success="redirectToHome" />

    <!-- Mostrar HomePage, MainHeader y SidebarMenu solo si el usuario está autenticado y en la ruta /home -->
    <div v-if="loggedIn && $route.name === 'Home'">
      <MainHeader />
      <div class="content">
        <SidebarMenu />
        <HomePage />
      </div>
    </div>
  </div>
</template>

<script>
import { ref, onMounted, onBeforeUnmount } from 'vue';
import { useRoute } from 'vue-router';
import MainHeader from './components/MainHeader.vue';
import SidebarMenu from './components/SidebarMenu.vue';
import HomePage from './components/HomePage.vue';
import Swal from 'sweetalert2';
import VueCookies from 'vue-cookies';
import router from './Router/index.js';

export default {
  name: 'App',
  setup() {
    const loggedIn = ref(false);
    const route = useRoute();

    // Verificar periódicamente si el usuario tiene un token de acceso válido almacenado en la cookie
    const tokenCheckInterval = setInterval(checkAccessToken, 5000);

    function checkAccessToken() {
      // Verificar si la ruta actual es "Home"
      if (route.name === 'Home') {
        const accessToken = VueCookies.get('access_token');
        //console.log('Token de acceso:', accessToken);

        if (!accessToken) {
          // Si el token no está presente, redirigir al usuario a iniciar sesión
          console.log('La sesion ha expirado');
          Swal.fire({
            icon: 'warning',
            title: 'Token expirado',
            text: 'Tu token ha expirado. Por favor, inicia sesión de nuevo.',
            timer: 3000,
            timerProgressBar: true,
            showConfirmButton: true
          }).then(() => {
            redirectToSignIn();
          });
          return;
        }

        // Si el token está presente, verificar si ha expirado
        const tokenExpirationTime = VueCookies.get('access_token_expiration');
        const currentTime = new Date().getTime() / 1000;
        if (tokenExpirationTime && currentTime > tokenExpirationTime) {
          // El token ha expirado, mostrar la alerta de sesión expirada
          console.log('El token ha expirado');
          Swal.fire({
            icon: 'warning',
            title: 'Token expirado',
            text: 'Tu token ha expirado. Por favor, inicia sesión de nuevo.',
            timer: 3000,
            timerProgressBar: true,
            showConfirmButton: true
          }).then(() => {
            redirectToSignIn();
          });
        } else {
          // El token está presente y no ha expirado, el usuario está autenticado
          console.log('El token está presente y no ha expirado');
          loggedIn.value = true;
        }
      }
    }

    function redirectToSignIn() {
      loggedIn.value = false;
      router.push({ name: 'SignIn' });
    }

    onBeforeUnmount(() => {
      clearInterval(tokenCheckInterval);
    });

    onMounted(() => {
      checkAccessToken();
    });

    return { loggedIn };
  },
  methods: {
    redirectToHome() {
      this.loggedIn = true;
      router.push({ name: 'Home' });
    }
  },
  watch: {
    // Observa la ruta actual para redirigir al usuario si intenta acceder a la página de inicio de sesión
    '$route'(to) {
      if (to.name === 'SignIn' && this.loggedIn) {
        router.push({ name: 'Home' });
      }
    }
  },
  components: {
    MainHeader,
    SidebarMenu,
    HomePage
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.content {
  display: flex;
}
</style>
