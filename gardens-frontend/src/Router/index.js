// ./Router/index.js
import { createRouter, createWebHistory } from 'vue-router';
import SignUp from '../SignUp/SignUp.vue';
import SignIn from '../SignIn/SignIn.vue';
import MainHeader from '../components/MainHeader.vue';
import HomePage from '../components/HomePage.vue';
import SidebarMenu from '../components/SidebarMenu.vue';

const routes = [
    { path: '/', redirect: 'signup' },
    { path: '/signup', name: 'SignUp', component: SignUp },
    { path: '/signin', name: 'SignIn', component: SignIn },
    {
        path: '/home',
        name: 'Home',
        components: {
            default: HomePage,
            header: MainHeader,
            sidebar: SidebarMenu
        },
        meta: {
            requireAuth: true
        }
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;