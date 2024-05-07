<template>
    <header class="header">
        <div class="header-left">
            <font-awesome-icon :icon="['fas', 'search']" class="icon" />
        </div>
        <div class="header-right">
            <a href="#">
                <font-awesome-icon :icon="['fas', 'bell']" class="icon" />
            </a>
            <a href="#">
                <font-awesome-icon :icon="['fas', 'envelope']" class="icon" />
            </a>
            <a href="#">
                <font-awesome-icon :icon="['fas', 'user-circle']" class="icon" />
            </a>
        </div>
    </header>
</template>

<script>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { fas } from '@fortawesome/free-solid-svg-icons';

// Agregar los iconos al "library"
library.add(fas);

export default {
    components: {
        FontAwesomeIcon
    },
    methods: {
        openSidebar() {
            // Aquí implementas la lógica para abrir la barra lateral
            // Emites un evento "open-sidebar" para que el componente padre lo maneje
            this.$emit('open-sidebar');
        }
    }
}
</script>

<style scoped>
.header {
    display: flex;
    justify-content: flex-end;
    /* Cambiando de space-between a flex-end para alinear los iconos a la derecha */
    align-items: center;
    padding: 0 20px;
    background-color: #ffffff;
    border-bottom: 1px solid #dddddd;
}

.icon {
    font-size: 24px;
    color: #000000;
}

.header-right a {
    margin-left: 10px;
}

.header-right a:hover {
    text-decoration: none;
}
</style>
