<template>
    <div class="container">
        <h2 class="item_title">Clientes compras Productos diferentes Gamas</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Codigo Cliente</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Telefono</th>
                    <th scope="col">Ciudad</th>
                    <th scope="col">Codigo Rep-Ventas</th>
                    <th scope="col">Gamas Productos</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(val, key) in clientesProductosGamasList" :key="key">
                    <td>{{ val.codigoCliente }}</td>
                    <td>{{ val.nombreCliente }}</td>
                    <td>{{ val.telefono }}</td>
                    <td>{{ val.ciudad }}</td>
                    <td>{{ val.codigoEmpleadoRepVentas }}</td>
                    <td>
                        <span v-for="(gama, index) in val.gamaCompradas" :key="index">
                            {{ gama.gama }}
                            {{ gama.descripcionTexto }}
                            <span v-if="index < val.gamaCompradas.length - 1">, </span>
                        </span>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';

export default {
    data() {
        return {
            clientesProductosGamasList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    mounted() {
        this.listClientesProductosGamas();
    },
    methods: {
        listClientesProductosGamas() {
            axios.get(this.API_IIS + '/api/GamaProducto/GamasCompradas', { withCredentials: true })
                .then(response => {
                    this.clientesProductosGamasList = response.data;
                })
                .catch(error => {
                    console.log("Error al mostrar la lista de ClientesProductosGamas ", error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de ClientesProductosGamas. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped>
/* Estilos específicos del componente si es necesario */
</style>