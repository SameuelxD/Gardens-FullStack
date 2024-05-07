<template>
    <div class="container">
        <h2 class="item_title">Pedidos Estados</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Estado</th>
                    <th scope="col">Cantidad de Pedidos</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(pedido, index) in pedidosEstadosList" :key="index">
                    <td>{{ pedido.estado }}</td>
                    <td>{{ pedido.cantidadPedidos }}</td>
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
            pedidosEstadosList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    created() {
        this.listPedidosEstados();
    },
    methods: {
        listPedidosEstados() {
            axios.get(this.API_IIS + '/api/Pedido/PedidosEstados', { withCredentials: true })
                .then(response => {
                    this.pedidosEstadosList = response.data;
                })
                .catch(error => {
                    console.error('Error al mostrar la lista de PedidosEstados', error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de PedidosEstados. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped></style>