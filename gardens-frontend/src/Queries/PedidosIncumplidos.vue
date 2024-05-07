<template>
    <div class="container">
        <h2 class="item_title">Informacion Pedidios Incumplidos</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Código Pedido</th>
                    <th scope="col">Fecha Esperada</th>
                    <th scope="col">Fecha Entrega</th>
                    <th scope="col">Codigo Cliente</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(pedido, index) in pedidosIncumplidosList" :key="index">
                    <td>{{ pedido.codigoPedido }}</td>
                    <td>{{ pedido.fechaEsperada }}</td>
                    <td>{{ pedido.fechaEntrega }}</td>
                    <td>{{ pedido.codigoCliente }}</td>
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
            pedidosIncumplidosList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    mounted() {
        this.listPedidosIncumplidos();
    },
    methods: {
        listPedidosIncumplidos() {
            axios.get(this.API_IIS + '/api/Pedido/PedidosIncumplidos', { withCredentials: true })
                .then(response => {
                    this.pedidosIncumplidosList = response.data;
                })
                .catch(error => {
                    console.log("Error al mostrar la lista de PedidosIncumplidos ", error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de PedidosIncumplidos. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped></style>