<template>
    <div class="container">
        <h2 class='item_title'>Clientes Cantidad de Pedidos</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Codigo Cliente</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Cantidad Pedidos</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(cliente, index) in clientesPedidosList" :key="index">
                    <td>{{ cliente.codigoCliente }}</td>
                    <td>{{ cliente.nombreCliente }}</td>
                    <td>{{ cliente.cantidadPedidos }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';

export default {
    name: 'ClientesPedidos',
    data() {
        return {
            clientesPedidosList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    created() {
        this.listClientesPedidos();
    },
    methods: {
        listClientesPedidos() {
            axios.get(this.API_IIS + '/api/Cliente/ClientesPedidos', { withCredentials: true })
                .then(response => {
                    this.clientesPedidosList = response.data;
                })
                .catch(error => {
                    console.log("Error al mostrar la lista de ClientesPedidos ", error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de ClientesPedidos. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped>
/* Agrega estilos CSS si es necesario */
</style>