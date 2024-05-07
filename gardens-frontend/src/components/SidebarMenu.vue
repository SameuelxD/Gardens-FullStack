<template>
    <div class="sidebar-container">
        <!-- Botón de hamburguesa -->
        <button class="hamburger" @click="toggleMenu" v-if="!isMenuVisible">
            <FontAwesomeIcon :icon="['fas', 'bars']" class="icon" />
        </button>

        <!-- Menú lateral -->
        <aside class="sidebar" :class="{ 'show-menu': isMenuVisible }">
            <div class="sidebar-title">
                <div class="sidebar-brand">
                    <FontAwesomeIcon :icon="['fas', 'shopping-cart']" class="icon_header" /> PLATFORM
                </div>
            </div>

            <ul class="sidebar-list">
                <!-- Contenido del menú aquí -->
                <li class="sidebar-list-item">
                    <a href="#">
                        <FontAwesomeIcon :icon="['fas', 'th-large']" class="icon" /> Dashboard
                    </a>
                </li>
                <li class="sidebar-list-item">
                    <a href="#">
                        <FontAwesomeIcon :icon="['fas', 'archive']" class="icon" /> Products
                    </a>
                </li>
                <li class="sidebar-list-item">
                    <a href="#">
                        <FontAwesomeIcon :icon="['fas', 'th']" class="icon" /> Categories
                    </a>
                </li>
                <li class="sidebar-list-item">
                    <a href="#">
                        <FontAwesomeIcon :icon="['fas', 'users']" class="icon" /> Customers
                    </a>
                </li>
                <li class="sidebar-list-item">
                    <a href="#">
                        <FontAwesomeIcon :icon="['fas', 'list']" class="icon" /> Inventory
                    </a>
                </li>
                <li class="sidebar-list-item">
                    <a href="#">
                        <FontAwesomeIcon :icon="['fas', 'chart-bar']" class="icon" /> Reports
                    </a>
                </li>
                <li class="sidebar-list-item">
                    <a href="#">
                        <FontAwesomeIcon :icon="['fas', 'cogs']" class="icon" /> Setting
                    </a>
                </li>
            </ul>
        </aside>

        <!-- Botón de cerrar -->
        <button class="close-btn" @click="toggleMenu" v-if="isMenuVisible">
            <FontAwesomeIcon :icon="['fas', 'times']" class="icon" />
        </button>
    </div>
</template>

<script>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

export default {
    components: {
        FontAwesomeIcon
    },
    data() {
        return {
            isMenuVisible: false
        };
    },
    methods: {
        toggleMenu() {
            this.isMenuVisible = !this.isMenuVisible;
        }
    }
};
</script>

<style scoped>
/* Estilos generales */
.sidebar-container {
    position: relative;
    display: flex;
}

/* Estilos del menú lateral */
.sidebar {
    position: fixed;
    top: 0;
    left: 0;
    bottom: 0;
    width: 250px;
    background-color: #fff;
    overflow-y: auto;
    transition: transform 0.3s ease;
    transform: translateX(-100%);
    z-index: 1000;
}

.show-menu {
    transform: translateX(0);
}

.sidebar-title {
    padding: 20px;
    border-bottom: 1px solid #ddd;
}

.sidebar-list {
    padding: 0;
    margin: 0;
    list-style-type: none;
}

.sidebar-list-item {
    padding: 15px 20px;
    border-bottom: 1px solid #ddd;
}

.sidebar-list-item:last-child {
    border-bottom: none;
}

.sidebar-brand {
    display: flex;
    align-items: center;
}

.sidebar-brand .icon_header {
    margin-right: 10px;
}

.icon {
    font-size: 18px;
    margin-right: 10px;
}

.sidebar-list-item a {
    display: flex;
    align-items: center;
    color: #333;
    text-decoration: none;
}

.sidebar-list-item a:hover {
    background-color: #f5f5f5;
}

/* Estilos del botón de hamburguesa */
.hamburger {
    position: fixed;
    top: 20px;
    left: 20px;
    z-index: 1100;
    background-color: transparent;
    border: none;
    cursor: pointer;
}

/* Estilos del botón de cerrar */
.close-btn {
    position: fixed;
    top: 20px;
    left: 250px;
    z-index: 1100;
    background-color: transparent;
    border: none;
    cursor: pointer;
}
</style>